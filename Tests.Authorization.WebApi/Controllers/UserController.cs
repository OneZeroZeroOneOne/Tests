using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Models;
using Tests.Dal.Models.Out;
using Tests.Security;
using Tests.Security.Options;
using Tests.Utilities.Exceptions;

namespace Tests.Authorization.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<OutUserViewModel> GetUserInfo()
        {
            var headers = this.Request.Headers;
            if (headers.ContainsKey("authorization"))
            {
                headers.TryGetValue("authorization", out StringValues token);
                JwtSecurityToken jwtToken = JwtService.ParseToken(token.ToString().Split(" ").Last(), AuthOption.KEY);
                int userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value);
                User user = await _userService.GetUser(userId);
                return new OutUserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    RoleId = user.RoleId,
                    AvatarUrl = user.AvatarUrl,
                    Email = user.UserSecurity.Email,
                    RoleName = user.Role.Title,
                };
            }
            throw ExceptionFactory.FriendlyException(ExceptionEnum.AuthorizationHeaderNotExist, "Authorization header not exist");
        }
    }
}