using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        public async Task<Quiz> CreateNewQuiz(int empId, int userId)
        {
            UserEmployee userEmployee = await _context.UserEmployee.FirstOrDefaultAsync(x => x.EmployeeId == empId && x.UserId == userId);
            if (userEmployee == null)
                throw ExceptionFactory.SoftException(ExceptionEnum.EmployeeIsNotYours, "Employee is not yours");
            
            DateTime currentTime = DateTime.Now;
            Subscription subscription = await _context.Subscription.Include(x => x.Type).FirstOrDefaultAsync(x =>
                x.BeginDateTime <= currentTime && x.EndDateTime >= currentTime && x.UserId == userId);

            if (subscription == null)
                throw ExceptionFactory.SoftException(ExceptionEnum.SubscriptionNotFound, "Subscription not found");

            int quizzesFromThisSubscriptionCount = await _context.UserQuiz.Include(x => x.Quiz)
                .Where(x => x.UserId == userId).Select(x => x.Quiz).Where(x =>
                    x.CreateDateTime >= subscription.BeginDateTime && x.CreateDateTime <= subscription.EndDateTime)
                .CountAsync();

            if (quizzesFromThisSubscriptionCount >= subscription.Type.AvailableTestAmount)
                throw ExceptionFactory.SoftException(ExceptionEnum.ExceededMaximumTests,
                    $"Exceeded the maximum number of tests for the current subscription, SubscriptionId={subscription.Id}");

            string quizId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

            Quiz newQuiz = new Quiz {StatusId = 1, CreateDateTime = currentTime, AddressKey = quizId };
            await _context.Quiz.AddAsync(newQuiz);
            await _context.SaveChangesAsync();
            await _context.UserQuiz.AddAsync(new UserQuiz
            {
                QuizId = newQuiz.Id,
                UserId = userId,
                EmployeeId = empId,
            });
            await _context.SaveChangesAsync();
            List<QuestionTemplate> questionTemplates = await _context.QuestionTemplate.Include(x => x.AnswerTamplates).Take(20).ToListAsync();
            List<Question> questions = new List<Question>();
            for (int i = 0; i < questionTemplates.Count; i++)
            {
                Question question = await GenerateQuestion(questionTemplates[i]);
                question.QuestionTypeId = questionTemplates[i].QuestionTypeId;
                question.QuizId = newQuiz.Id;
                questions.Add(question);
            }
            await _context.Question.AddRangeAsync(questions);
            await _context.SaveChangesAsync();
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
                    CreateDateTime = DateTime.Now,
                });
            }

            templateRealWordDataObject = CreateTempleteWordDict(wordParser.templateDataObjects, nounsNumberObject, verbsNumberObject, adjectivesNumberObject);
            var scribanQuestionTemplate = Scriban.Template.Parse(wordParser.parsedTemplate);
            Question question = new Question
            {
                QuestionTypeId = questionTemplate.QuestionTypeId,
                CreateDateTime = DateTime.Now,
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
            return await _context.UserQuiz.Include(x => x.Quiz).ThenInclude(x => x.Status).Where(x => x.UserId == userId && x.EmployeeId == empId).Select(x => x.Quiz).ToListAsync();
        }
    }
}
