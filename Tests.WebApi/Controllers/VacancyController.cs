using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Contexts;
using Tests.Dal.In;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;

namespace Tests.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly IMapper _mapperProfile;
        private readonly VacancyService _vacancyService;
        public VacancyController(MainContext context, VacancyService vacancyService, IMapper mapperProfile)
        {
            _context = context;
            _mapperProfile = mapperProfile;
            _vacancyService = vacancyService;
        }

        [HttpPost]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutVacancyViewModel> AddVacancy(InVacancyViewModel inVacancyViewModel)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            Vacancy newVacancy = _mapperProfile.Map<Vacancy>(inVacancyViewModel);
            newVacancy.UserId = authorizedUserModel.Id;
            await _vacancyService.AddVacancy(newVacancy);
            return _mapperProfile.Map<OutVacancyViewModel>(newVacancy);
        }

        [HttpGet]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<List<OutVacancyViewModel>> AddUserVacancy()
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            List<Vacancy> userVacancies = await _vacancyService.GetUserVacancies(authorizedUserModel.Id);
            return _mapperProfile.Map<List<OutVacancyViewModel>>(userVacancies);
        }
    }
}
