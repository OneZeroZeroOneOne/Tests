using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Tests.Bll.Services.NotificationSenderTarget;
using Tests.Bll.Template;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
using Tests.Utilities;
using Tests.Utilities.Exceptions;

namespace Tests.Bll.Services
{
    public class QuizService
    {
        private readonly MainContext _context;
        public QuizService(MainContext context)
        {
            _context = context;
        }

        public async Task<Quiz> GetQuizByAddressKey(string addressKey)
        {
            return (await _context.Quiz.Include(x => x.Questions).ThenInclude(x => x.Answers).Include(x => x.Status)
                .Select(x => new Quiz
                {
                    Id = x.Id,
                    AddressKey = x.AddressKey,
                    CreateDateTime = x.CreateDateTime,
                    Questions = x.Questions.OrderByDescending(y => y.CreateDateTime).ToList(),
                    Status = x.Status,
                    StatusId = x.StatusId,

                }).FirstOrDefaultAsync(x => x.AddressKey == addressKey));
        }


        public async Task<int> SetQuizStarted(string addressKey)
        {
            Quiz q = await _context.Quiz.Include(x => x.Status).FirstOrDefaultAsync(x => x.AddressKey == addressKey);
            q.StatusId = 2;
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Dictionary<string, bool>> SetQuizEnded(string addressKey)
        {
            Quiz quiz = await _context.Quiz.Include(x => x.Status).Include(x => x.Questions).FirstOrDefaultAsync(x => x.AddressKey == addressKey);
            if (quiz == null ) throw ExceptionFactory.SoftException(ExceptionEnum.QuizNotFound, $"quiz not found");
            if (quiz.Status.Id == 2)
            {
                return await GetTestResult(quiz);
            }
            else
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.TestNotStarted, "the test not be started or already ended");
            }
        }

        public async Task<Quiz> CreateNewQuiz(int empId, int userId)
        {
            UserEmployee userEmployee = await _context.UserEmployee.FirstOrDefaultAsync(x => x.EmployeeId == empId && x.UserId == userId);
            if (userEmployee == null)
                throw ExceptionFactory.SoftException(ExceptionEnum.EmployeeIsNotYours, "Employee is not yours");

            DateTime currentTime = DateTime.UtcNow;
            Subscription subscription = await _context.Subscription.Include(x => x.Type).FirstOrDefaultAsync(x =>
                x.BeginDateTime <= currentTime && x.EndDateTime >= currentTime && x.UserId == userId);

            if (subscription == null)
                throw ExceptionFactory.SoftException(ExceptionEnum.SubscriptionNotFound, "Subscription not found");

            int quizzesFromThisSubscriptionCount = await _context.Quiz.Where(x => x.UserId == userId &&
                    x.CreateDateTime >= subscription.BeginDateTime && x.CreateDateTime <= subscription.EndDateTime)
                .CountAsync();

            if (quizzesFromThisSubscriptionCount >= subscription.Type.AvailableTestAmount)
                throw ExceptionFactory.SoftException(ExceptionEnum.ExceededMaximumTests,
                    $"Exceeded the maximum number of tests for the current subscription, SubscriptionId={subscription.Id}");

            string quizId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

            Quiz newQuiz = new Quiz { StatusId = 1, CreateDateTime = currentTime, AddressKey = quizId, EmployeeId = empId, UserId = userId };
            await _context.Quiz.AddAsync(newQuiz);
            await _context.SaveChangesAsync();
            QuestionType questionType = await _context.QuestionType.Include(x => x.QuestionTemplates).ThenInclude(x => x.AnswerTamplates).FirstOrDefaultAsync(x => x.Id == 2);
            List<QuestionTemplate> questionTemplates = await _context.QuestionTemplate.Include(x => x.AnswerTamplates).Take(20).Where(x => x.QuestionTypeId != 2).ToListAsync();
            for (int i = 0; i < questionTemplates.Count; i++)
            {
                Question question = await GenerateQuestion(questionTemplates[i]);
                question.QuestionTypeId = questionTemplates[i].QuestionTypeId;
                question.QuizId = newQuiz.Id;
                await _context.Question.AddAsync(question);
                await _context.SaveChangesAsync();
                if (questionType.QuestionTemplates.Count >= 1)
                {
                    List<Answer> ans = new List<Answer>();
                    foreach (var answerTamplate in questionType.QuestionTemplates.First().AnswerTamplates)
                    {
                        ans.Add(new Answer()
                        {
                            CreateDateTime = DateTime.UtcNow,
                            IsRight = answerTamplate.IsRight,
                            Text = answerTamplate.Text,
                        });
                    }
                    Question statsQuestion = new Question()
                    {
                        QuestionTypeId = questionType.Id,
                        QuizId = newQuiz.Id,
                        CreateDateTime = DateTime.UtcNow,
                        Text = questionType.QuestionTemplates.First().Text,
                        AboutQuestionId = question.Id,
                        Answers = ans,
                    };
                    await _context.Question.AddAsync(statsQuestion);
                    await _context.SaveChangesAsync();
                }

            }

            return await _context.Quiz.Include(x => x.Status).Include(x => x.Questions).FirstOrDefaultAsync(x => x.Id == newQuiz.Id);
        }



        public async Task<Question> GenerateQuestion(QuestionTemplate questionTemplate)
        {
            WordParser wordParser = new WordParser(questionTemplate.Text);
            Dictionary<int, Word> numberWordTypeData = new Dictionary<int, Word>();
            Dictionary<int, GenderEnum> nounsGender = new Dictionary<int, GenderEnum>();
            foreach (var word in wordParser.templateDataObjects)
            {
                if (!numberWordTypeData.TryGetValue(word.Value.WordNumber, out var wordTypeEnum))
                {
                    numberWordTypeData.Add(word.Value.WordNumber, word.Value);
                    switch (word.Value.WordType)
                    {
                        case WordTypeEnum.Noun:
                            nounsGender[word.Value.WordNumber] = word.Value.Gender;
                            break;
                    }
                }
            }
            Dictionary<int, Noun> nounsNumberObject = new Dictionary<int, Noun>();
            Dictionary<int, Verb> verbsNumberObject = new Dictionary<int, Verb>();
            Dictionary<int, Adjective> adjectivesNumberObject = new Dictionary<int, Adjective>();
            foreach (var numberWord in numberWordTypeData)
            {
                if (numberWord.Value.WordType == WordTypeEnum.Adjective)
                {
                    adjectivesNumberObject.Add(numberWord.Value.WordNumber, await _context.Adjective.FirstOrDefaultAsync(x => !adjectivesNumberObject.Select(y => y.Value.Id).Contains(x.Id)));
                }
                if (numberWord.Value.WordType == WordTypeEnum.Verb)
                {
                    verbsNumberObject.Add(numberWord.Value.WordNumber, await _context.Verb.FirstOrDefaultAsync(x => !verbsNumberObject.Select(y => y.Value.Id).Contains(x.Id)));
                }
                if (numberWord.Value.WordType == WordTypeEnum.Noun)
                {
                    nounsNumberObject.Add(numberWord.Value.WordNumber, await _context.Noun.FirstOrDefaultAsync(x => !nounsNumberObject.Select(y => y.Value.Id).Contains(x.Id) && x.Gender == nounsGender[numberWord.Key].ToString()));
                }
            }
            Dictionary<string, string> templateRealWordDataObject = new Dictionary<string, string>();
            List<Answer> answers = new List<Answer>();
            foreach (var answerTemplete in questionTemplate.AnswerTamplates)
            {
                WordParser answerWordParser = new WordParser(answerTemplete.Text);
                templateRealWordDataObject = CreateTempleteWordDict(answerWordParser.templateDataObjects,
                    nounsNumberObject, verbsNumberObject, adjectivesNumberObject);
                var scribanAnswerTemplate = Scriban.Template.Parse(answerWordParser.parsedTemplate);
                answers.Add(new Answer
                {
                    Text = string.Join(". ", scribanAnswerTemplate.Render(templateRealWordDataObject).Split(". ").Select(x => x.FirstCharToUpper())),
                    CreateDateTime = DateTime.UtcNow,
                    IsRight = answerTemplete.IsRight,
                });
            }

            templateRealWordDataObject = CreateTempleteWordDict(wordParser.templateDataObjects, nounsNumberObject, verbsNumberObject, adjectivesNumberObject);
            var scribanQuestionTemplate = Scriban.Template.Parse(wordParser.parsedTemplate);
            Question question = new Question
            {
                QuestionTypeId = questionTemplate.QuestionTypeId,
                CreateDateTime = DateTime.UtcNow,
                Text = string.Join(". ", scribanQuestionTemplate.Render(templateRealWordDataObject).Split(". ").Select(x => x.FirstCharToUpper())),
                Answers = answers,
            };
            return question;

        }

        public Dictionary<string, string> CreateTempleteWordDict(Dictionary<string, Word> templateDataObjects,
            Dictionary<int, Noun> nounsNumberObject, Dictionary<int, Verb> verbsNumberObject, Dictionary<int, Adjective> adjectivesNumberObject)
        {
            Dictionary<string, string> templateRealWordDataObject = new Dictionary<string, string>();
            foreach (var templateObject in templateDataObjects)
            {
                string finalword = "";
                if (nounsNumberObject.ContainsKey(templateObject.Value.WordNumber))
                {
                    JObject json = JObject.Parse(nounsNumberObject[templateObject.Value.WordNumber].Json);
                    finalword = json.Children().FirstOrDefault(x => x.Path.Contains(templateObject.Value.Amount.ToString()))
                        .Children().FirstOrDefault()
                        .Children().FirstOrDefault(x => x.Path.Contains(templateObject.Value.Declension.ToString()))
                        .Children().FirstOrDefault().ToString();

                }
                else if (verbsNumberObject.ContainsKey(templateObject.Value.WordNumber))
                {
                    JObject json = JObject.Parse(verbsNumberObject[templateObject.Value.WordNumber].Json);
                    var a = json.Children().FirstOrDefault(x => x.Path.Contains(templateObject.Value.Time.ToString()))
                        .Children().FirstOrDefault()
                        .Children().FirstOrDefault(x => x.Path.Contains(templateObject.Value.Amount.ToString()))
                        .Children().FirstOrDefault();
                    if (templateObject.Value.Time == TimeEnum.Past)
                    {
                        if (templateObject.Value.Amount == AmountEnum.Alone)
                        {
                            finalword = a.Children().FirstOrDefault(x => x.Path.Contains(templateObject.Value.Gender.ToString()))
                            .Children().FirstOrDefault().ToString();
                        }
                        else
                        {
                            finalword = a.ToString();
                        }
                    }
                    else
                    {
                        finalword = a.Children().FirstOrDefault(x => x.Path.Contains(templateObject.Value.Person.ToString()))
                            .Children().FirstOrDefault().ToString();
                    }
                }
                else if (adjectivesNumberObject.ContainsKey(templateObject.Value.WordNumber))
                {
                    JObject json = JObject.Parse(adjectivesNumberObject[templateObject.Value.WordNumber].Json);
                    finalword = json.Children().FirstOrDefault(x => x.Path.Contains(templateObject.Value.Gender.ToString()))
                        .Children().FirstOrDefault()
                        .Children().FirstOrDefault(x => x.Path.Contains(templateObject.Value.Amount.ToString()))
                        .Children().FirstOrDefault()
                        .Children().FirstOrDefault(x => x.Path.Contains(templateObject.Value.Declension.ToString()))
                        .Children().FirstOrDefault().ToString();

                }
                templateRealWordDataObject.Add(templateObject.Key, finalword);
            }
            return templateRealWordDataObject;

        }

        public async Task<List<Quiz>> GetEmployeeQuizzes(int empId, int userId)
        {
            return await _context.Quiz.Include(x => x.Status).Where(x => x.UserId == userId && x.EmployeeId == empId).ToListAsync();
        }

        public async Task<EmployeeAnswer> SetAnswer(int QuestionId, int answerId)
        {
            int endStatusId = 3;
            int notStartedStatus = 1;
            Answer answer = await _context.Answer.Include(x => x.Question).ThenInclude(x => x.Quiz).ThenInclude(x => x.Status).FirstOrDefaultAsync(x => x.Id == answerId);
            if (answer == null || answer.Question.Id != QuestionId)
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.AnswerNotFound, "answer not found");
            }
            if (answer.Question.Id != QuestionId) throw ExceptionFactory.SoftException(ExceptionEnum.AnswerNotFound, "answer not found");
            if (answer.Question.Quiz.Status.Id == endStatusId | answer.Question.Quiz.Status.Id == notStartedStatus)
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.TestAlreadyCompleted, "the test has already been completed or not be started");
            }

            EmployeeAnswer userAnswer = await _context.EmployeeAnswer.FirstOrDefaultAsync(x => x.QuestionId == answer.Question.Id);
            if (userAnswer != null)
            {
                userAnswer.AnswerId = answerId;
            }
            else
            {
                userAnswer = new EmployeeAnswer
                {
                    AnswerId = answerId,
                    QuestionId = answer.Question.Id,
                    QuizId = answer.Question.Quiz.Id,
                    EmployeeId = answer.Question.Quiz.EmployeeId,
                    CreateDateTime = DateTime.UtcNow,
                };
                await _context.EmployeeAnswer.AddAsync(userAnswer);
            }
            await _context.SaveChangesAsync();
            return userAnswer;
        }

        public async Task<EmployeeAnswerAssessment> SetEmployeeAnswerAssessment(int questionId, int assessmentId)
        {
            Assessment assessment = await _context.Assessment.FirstOrDefaultAsync(x => x.Id == assessmentId);
            if (assessment == null)
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.AssessmentNotFound, "assessment not found");
            }
            Question question = await _context.Question.Include(x => x.Quiz).ThenInclude(x => x.Status).FirstOrDefaultAsync(x => x.Id == questionId);
            if (question == null)
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.QuestionNotFound, "question not found");
            }
            int endStatusId = 3;
            int notStartedStatus = 1;
            if (question.Quiz.Status.Id == endStatusId | question.Quiz.Status.Id == notStartedStatus)
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.TestAlreadyCompleted, "the test has already been completed or not be started");
            }
            EmployeeAnswerAssessment employeeAnswerAssessment = await _context.EmployeeAnswerAssessment.FirstOrDefaultAsync(x => x.QuestionId == questionId);
            if (employeeAnswerAssessment == null)
            {
                await _context.EmployeeAnswerAssessment.AddAsync(new EmployeeAnswerAssessment
                {
                    QuestionId = questionId,
                    AssessmentId = assessmentId,
                    CreateDateTime = DateTime.UtcNow
                });
            }
            else
            {
                employeeAnswerAssessment.AssessmentId = assessmentId;
            }
            await _context.SaveChangesAsync();
            return await _context.EmployeeAnswerAssessment.Include(x => x.Question).Include(x => x.Assessment).FirstOrDefaultAsync(x => x.QuestionId == questionId);
        }

        public async Task<int> SetAllegedEmployeeErrors(List<int> questionIds, int quizId)
        {
            List<AllegedEmployeeError> allegedEmployeeErrors = new List<AllegedEmployeeError>();
            foreach (var questionId in questionIds)
            {
                Question question = await _context.Question.Include(x => x.Quiz).ThenInclude(x => x.Status).FirstOrDefaultAsync(x => x.Id == questionId);
                if(question != null && question.Quiz.Id == quizId)
                {
                    if(question.Quiz.Status.Id == 2)
                    {
                        if(question.QuestionTypeId == 2) throw ExceptionFactory.SoftException(ExceptionEnum.IsStatisticQuestion, $"question id {question.Id} is statistic question");
                        allegedEmployeeErrors.Add(new AllegedEmployeeError()
                        {
                            EmployeeId = question.Quiz.EmployeeId,
                            QuestionId = question.Id,
                        });
                    }
                    else
                    {
                        throw ExceptionFactory.SoftException(ExceptionEnum.TestAlreadyCompleted, "the test has already been completed or not be started");
                    }
                    
                }
                else
                {
                    throw ExceptionFactory.SoftException(ExceptionEnum.QuestionNotBelongsQuiz, $"question id {questionId} is not belongs quiz");
                }
            }
            await _context.AllegedEmployeeError.AddRangeAsync(allegedEmployeeErrors);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Dictionary<string, bool>> GetTestResult(Quiz quiz)
        {
            Dictionary<string, bool> result = new Dictionary<string, bool>();
            foreach (var question in quiz.Questions)
            {
                if (question.AboutQuestionId == null)
                {
                    EmployeeAnswer employeeAnswer = await _context.EmployeeAnswer.Include(x => x.Answer).FirstOrDefaultAsync(x => x.QuestionId == question.Id && x.QuizId == quiz.Id);
                    if (employeeAnswer == null)
                    {
                        result.Add(question.Id.ToString(), false);
                        continue;
                    }
                    result.Add(question.Id.ToString(), employeeAnswer.Answer.IsRight);
                }
            }
            Quiz quiz1 = await _context.Quiz.FirstOrDefaultAsync(x => x.Id == quiz.Id);
            quiz1.StatusId = 3;
            await _context.SaveChangesAsync();
            return result;
        }


        public async Task<Dictionary<string, string>> GetTestAssessments(Quiz quiz)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach(var questionAssessment in quiz.Questions)
            {
                if (questionAssessment.AboutQuestionId != null)
                {
                    EmployeeAnswer employeeAnswer = await _context.EmployeeAnswer.Include(x => x.Answer).FirstOrDefaultAsync(x => x.QuestionId == questionAssessment.Id && x.QuizId == quiz.Id);
                    if (employeeAnswer == null)
                    {
                        result.Add(questionAssessment.Id.ToString(), "");
                        continue;
                    }
                    result.Add(questionAssessment.AboutQuestionId.ToString(), employeeAnswer.Answer.Text);
                }
            }
            return result;
        } 

        public async Task<Quiz> GetQuiz(int quizId)
        {
            Quiz quiz = await _context.Quiz.Include(x => x.Questions).ThenInclude(x => x.Answers).FirstOrDefaultAsync(x => x.Id == quizId);
            if (quiz == null) throw ExceptionFactory.SoftException(ExceptionEnum.QuizNotFound, "quiz not found");
            return quiz;
        }
    }
}
