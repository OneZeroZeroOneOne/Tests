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


    }
}