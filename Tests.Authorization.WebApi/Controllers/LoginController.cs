using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Models;
using Tests.Dal.Models.Out;
using Tests.Security;

namespace Tests.Authorization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<OutAuthorizationViewModel> Login([FromQuery] string login, [FromQuery] string password)
        {
            User user = await _loginService.Authorization(login, password);
            var identity = JwtService.GetUserIdentity(user.Id, user.Role.Id);
            var jwtToken = JwtService.GenerateToken(identity);
            return new OutAuthorizationViewModel() { Id = user.Id, RoleName = user.Role.Title, Token = jwtToken };
        }
        

    }
}