using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Out;

namespace Tests.QuestionAnswer.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuizController : BaseController
    {
        private readonly QuizService _quizService;
        private readonly IMapper _mapperProfile;
        public QuizController(QuizService quizService, IMapper mapperProfile)
        {
            _quizService = quizService;
            _mapperProfile = mapperProfile;
        }


        [HttpGet]
        public async Task<OutQuizViewModel?> Get([FromQuery] string addressKey)
        {
            var quiz = await _quizService.GetQuizByAddressKey(addressKey);
            if(quiz == null)
                return null;

            OutQuizViewModel returnModel = _mapperProfile.Map<OutQuizViewModel>(quiz);
            returnModel.IsAdmin = UserId == quiz.UserId;

            if (!returnModel.IsAdmin)
            {
                if (quiz.Status.Id != 1) 
                    return null;

                await _quizService.SetQuizStarted(addressKey);

                return returnModel;
            }
            
            returnModel.AnsweredQuestionIds = new List<int>();
            foreach (var i in returnModel.Questions)
            {
                var employeeAnswer = await _quizService.GetEmployeeAnswer(i.Id);
                if(employeeAnswer != null)
                {
                    returnModel.AnsweredQuestionIds.Add(employeeAnswer.QuestionId);
                    i.IsUserAnswered = true;
                    foreach(var j in i.Answers)
                    {
                        if(j.Id == employeeAnswer.AnswerId)
                        {
                            j.IsPicked = true;
                            j.IsCorrect = employeeAnswer.Answer.IsRight;
                        }
                        else
                        {
                            j.IsPicked = false;
                        }

                    }
                }
                else
                {
                    i.IsUserAnswered = false;
                }

            }
            returnModel.AllegedErrors = (await _quizService.GetAllegedEmployeeErrors(quiz.Id)).Select(x => x.QuestionId).ToList();
            return returnModel;
        }

        [HttpPost]
        public async Task<Dictionary<string, bool>> SetQuizEnded([FromQuery] string addressKey)
        {
            return await _quizService.SetQuizEnded(addressKey);
        }
    }
}