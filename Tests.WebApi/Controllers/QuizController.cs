using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;

namespace Tests.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly QuizService _quizService;
        private readonly IMapper _mapperProfile;
        public QuizController(QuizService quizService, IMapper mapperProfile)
        {
            _quizService = quizService;
            _mapperProfile = mapperProfile;
        }


        [HttpPost]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutQuizViewModel> Create([FromQuery] int id)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            Quiz quiz = await _quizService.CreateNewQuiz(id, authorizedUserModel.Id);
            return _mapperProfile.Map<OutQuizViewModel>(quiz);
        }

        [HttpGet]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<List<OutQuizViewModel>> Get([FromQuery] int id)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            List<Quiz> quizzes = await _quizService.GetEmployeeQuizzes(id, authorizedUserModel.Id);
            return _mapperProfile.Map<List<OutQuizViewModel>>(quizzes);
        }


        [HttpGet]
        [Route("GetStat")]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<List<OutQuestionResultViewModel>> GetStat([FromQuery] int quizId)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            Quiz quiz = await _quizService.GetQuiz(quizId);
            Dictionary<string, bool> questionsResult = await _quizService.GetTestResult(quiz);
            Dictionary<string, string> questionsAssessment = await _quizService.GetTestAssessments(quiz);
            List<OutQuestionResultViewModel> responce = new List<OutQuestionResultViewModel>();
            foreach (var questionResult in questionsResult)
            {
                string assessmentText = "";
                if (questionsAssessment.ContainsKey(questionResult.Key))
                {
                    assessmentText = questionsAssessment[questionResult.Key];   
                }
                responce.Add(new OutQuestionResultViewModel() 
                {
                    QuestionId = int.Parse(questionResult.Key),
                    IsRight = questionResult.Value,
                    AssessmentText = assessmentText,
                });
            }
            return responce;
        }
    }
}