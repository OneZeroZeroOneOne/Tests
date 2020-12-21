using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tests.Bll.Services;
using Tests.Dal.In;
using Tests.Dal.Models;
using Tests.Dal.Out;
using Tests.Security.Authorization;

namespace Tests.Authorization.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private RegisterService _registerService;
        public RegisterController(RegisterService registerService)
        {
            _registerService = registerService;
        }
        [HttpPost]
        public async Task<OutAuthorizationViewModel> RegisterClientAdmin([FromBody] InRegisterModel inRegisterModel)
        {
            User newUser = await _registerService.RegisterClientAdmin(inRegisterModel.Login, inRegisterModel.Password, inRegisterModel.Email, inRegisterModel.Name);
            var identity = JwtService.GetUserIdentity(newUser.Id, newUser.Role.Id);
            var jwtToken = JwtService.GenerateToken(identity);
            return new OutAuthorizationViewModel() { Id = newUser.Id, RoleName = newUser.Role.Title, Token = jwtToken };
        }
    }
}