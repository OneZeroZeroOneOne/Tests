using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.In;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;

namespace Tests.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly IMapper _mapperProfile;
        public EmployeeController(EmployeeService employeeService, IMapper mapperProfile)
        {
            _employeeService = employeeService;
            _mapperProfile = mapperProfile;
        }

        [HttpGet]
        [Authorize(Policy = "ClientAdmin")]
        [Route("{id}")]
        public async Task<OutEmployeeViewModel?> GetEmployee(int id)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            var emp = await _employeeService.GetEmployee(id, authorizedUserModel.Id);
            return emp != null ? _mapperProfile.Map<OutEmployeeViewModel>(emp) : null;
        }

        [HttpGet]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<List<OutEmployeeViewModel>> GetEmployees([FromQuery]int? quizStatusId = null, [FromQuery]bool? isCandidate = null)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;
            return _mapperProfile.Map<List<OutEmployeeViewModel>>(await _employeeService.GetEmployees(authorizedUserModel.Id, quizStatusId, isCandidate));
        }

        [HttpPost]
        [Authorize(Policy = "ClientAdmin")]
        public async Task<OutEmployeeViewModel> AddEmployee(InEmployeeViewModel inEmployeeViewModel)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;

            Employee newEmp = _mapperProfile.Map<Employee>(inEmployeeViewModel);
            await _employeeService.AddEmployee(newEmp, authorizedUserModel.Id);

            return _mapperProfile.Map<OutEmployeeViewModel>(newEmp);
        }


        [HttpPatch]
        [Authorize(Policy = "ClientAdmin")]
        [Route("{id}")]
        public async Task<OutEmployeeViewModel> EditEmployee(InEmployeeViewModel inEmployeeViewModel, int id)
        {
            AuthorizedUserModel authorizedUserModel = (AuthorizedUserModel)HttpContext.User.Identity;

            Employee emp = _mapperProfile.Map<Employee>(inEmployeeViewModel);
            Employee editedEmp = await _employeeService.EditEmployee(emp, id, authorizedUserModel.Id);

            return _mapperProfile.Map<OutEmployeeViewModel>(editedEmp);
        }
    }
}
