using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Models;
using Tests.Dal.Models.In;
using Tests.Dal.Models.Out;
using Tests.Security;

namespace Tests.Authorization.Controllers
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