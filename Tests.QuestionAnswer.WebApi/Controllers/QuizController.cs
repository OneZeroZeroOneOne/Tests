using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;
using Tests.Security.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace Tests.QuestionAnswer.WebApi.Controllers
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


        [HttpGet]
        public async Task<OutQuizViewModel> Get([FromQuery] string addressKey)
        {
            var headers = this.Request.Headers;
            bool trytoken = headers.TryGetValue("authorization", out var token);
            if(trytoken == false)
            {
                trytoken = headers.TryGetValue("Authorization", out token);
            }
            int userId = -1;
            if (trytoken != false)
            {
                try
                {
                    var jwtToken = JwtService.ParseToken(token.ToString().Split(" ").Last(), AuthOption.KEY);
                    userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value);
                }
                catch(Exception ex) 
                {
                }
                
            }

            Quiz quiz = await _quizService.GetQuizByAddressKey(addressKey);
            if(quiz == null)
            {
                return null;
            }
            OutQuizViewModel returnModel = null;
            if (userId != quiz.UserId)
            {
                if (quiz.Status.Id == 1)
                {
                    await _quizService.SetQuizStarted(addressKey);
                    returnModel = _mapperProfile.Map<OutQuizViewModel>(quiz);
                    returnModel.IsAdmin = false;
                    return returnModel;
                }
                else
                {
                    return null;
                }
                
            }
            returnModel = _mapperProfile.Map<OutQuizViewModel>(quiz);
            returnModel.IsAdmin = true;
            foreach(var i in returnModel.Questions)
            {
                EmployeeAnswer employeeAnswer = await _quizService.GetEmployeeAnswer(i.Id);
                if(employeeAnswer != null)
                {
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
            return returnModel;
        }

        [HttpPost]
        public async Task<Dictionary<string, bool>> SetQuizEnded([FromQuery] string addressKey)
        {
            return await _quizService.SetQuizEnded(addressKey);
        }
    }
}