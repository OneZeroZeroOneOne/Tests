using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.In;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;
using Tests.Security.Options;

namespace Tests.QuestionAnswer.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly QuizService _quizService;
        private readonly IMapper _mapperProfile;
        public AnswerController(QuizService quizService, IMapper mapperProfile)
        {
            _quizService = quizService;
            _mapperProfile = mapperProfile;
        }

        [HttpPost]
        public async Task<OutUserAnswerViewModel> SetAnswer([FromBody] InAnswerViewModel inAnswerViewModel)
        {
            return _mapperProfile.Map<OutUserAnswerViewModel>(await _quizService.SetAnswer(inAnswerViewModel.QuestionId, inAnswerViewModel.AnswerId));
        }

        [HttpPost]
        [Route("Assessment")]
        public async Task<OutEmployeeAnswerAssessmentViewModel> SetEmployeeAnswerAssessment([FromBody] InEmployeeAnswerAssessmentViewModel inEmployeeAnswerAssessmentViewModel)
        {
            return _mapperProfile.Map<OutEmployeeAnswerAssessmentViewModel>(await _quizService.SetEmployeeAnswerAssessment(inEmployeeAnswerAssessmentViewModel.QuestionId, inEmployeeAnswerAssessmentViewModel.AssessmentId));
        }

        [HttpPost]
        [Route("AllegedError")]
        public async Task<int> SetAllegedEmployeeError([FromBody]  InAllegedEmployeeErrorViewModel inModel)
        {
            await _quizService.SetAllegedEmployeeErrors(inModel.QuestionIds, inModel.QuizId);
            return 0;
        }


    }
}