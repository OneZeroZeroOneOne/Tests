using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tests.Bll.Template;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
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
            for(int i = 0; i < questionTemplates.Count; i++)
            {
                int adjectivesCount = 0;
                int verbsCount = 0;
                WordParser wordParser = new WordParser(questionTemplates[i].Text);
                Dictionary<int, WordTypeEnum> numberWordTypeData = new Dictionary<int, WordTypeEnum>();
                //Dictionary<int, List<Verb>> verbs = new Dictionary<int, List<Verb>>();
                //Dictionary<int, List<Adjective>> adjectives = new Dictionary<int, List<Adjective>>();
                Dictionary<int, List<Noun>> nouns = new Dictionary<int, List<Noun>>();
                foreach (var word in wordParser._templateDataObject)
                {
                    if (!numberWordTypeData.TryGetValue(word.Value.WordNumber, out var wordTypeEnum))
                    {
                        numberWordTypeData.Add(word.Value.WordNumber, word.Value.WordType);
                        switch (word.Value.WordType)
                        {
                            case WordTypeEnum.Adjective:
                                adjectivesCount = adjectivesCount + 1;
                                //adjectives[word.Value.WordNumber].Add(await _context.Adjective.FirstOrDefaultAsync());
                                break;

                            case WordTypeEnum.Verb:
                                verbsCount = verbsCount + 1;
                                //verbs[word.Value.WordNumber].Add(await _context.Verb.FirstOrDefaultAsync());
                                break;

                            case WordTypeEnum.Noun:
                                nouns[word.Value.WordNumber].Add(await _context.Noun.FirstOrDefaultAsync(x => x.Gender == word.Value.Gender.ToString()));
                                break;
                        }
                    }
                }
                //GenerateQuestion(wordParser._parsedTemplate, wordParser._templateDataObject, numberWordTypeData, verbs, adjectives, nouns);
            }
            return await _context.Quiz.Include(x => x.Status).Include(x => x.Questions).FirstOrDefaultAsync(x => x.Id == newQuiz.Id);
        }


        public int GenerateQuestion(string template, Dictionary<string, Word> templateDataObjects, Dictionary<int, WordTypeEnum> numberWordTypeData, List<Verb> verbs, List<Adjective> adjectives, List<Noun> nouns)
        {
            Dictionary<int, int> relationVerbs = new Dictionary<int, int>();
            int verbsIndex = 0;
            Dictionary<int, int> relationAdjectives = new Dictionary<int, int>();
            int adjectivesIndex = 0;
            Dictionary<int, int> relationNouns = new Dictionary<int, int>();
            int nounsIndex = 0;
            foreach(var numberWordType in numberWordTypeData)
            {
                if(numberWordType.Value == WordTypeEnum.Adjective)
                {
                    relationAdjectives.Add(numberWordType.Key, adjectivesIndex);
                    adjectivesIndex = adjectivesIndex + 1;
                }
                if (numberWordType.Value == WordTypeEnum.Verb)
                {
                    relationVerbs.Add(numberWordType.Key, verbsIndex);
                    verbsIndex = verbsIndex + 1;
                }
                if (numberWordType.Value == WordTypeEnum.Noun)
                {
                    relationNouns.Add(numberWordType.Key, nounsIndex);
                    nounsIndex = nounsIndex + 1;
                }
            }
            foreach(var word in templateDataObjects)
            {
                string replacedWord = "";
                if (word.Value.WordType == WordTypeEnum.Adjective)
                {

                }
                if (word.Value.WordType == WordTypeEnum.Verb)
                {

                }
                if (word.Value.WordType == WordTypeEnum.Noun)
                {

                }
                //template = template.Replace($"{{{word.Key}}}", )
            }
            return 1;
        }

        public async Task<List<Quiz>> GetEmployeeQuizzes(int empId, int userId)
        {
            return await _context.UserQuiz.Include(x => x.Quiz).ThenInclude(x => x.Status).Where(x => x.UserId == userId && x.EmployeeId == empId).Select(x => x.Quiz).ToListAsync();
        }
    }
}
