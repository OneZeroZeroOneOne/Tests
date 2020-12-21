using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tests.Bll.Services;
using Tests.Dal.Contexts;
using Tests.Dal.Out;
using Tests.Security.Authorization;
using Tests.Security.Options;
using Tests.Utilities.Exceptions;

namespace Tests.Authorization.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly MainContext _context;

        public UserController(UserService userService, MainContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet]
        public async Task<OutUserViewModel> GetUserInfo()
        {
            var headers = this.Request.Headers;
            if (!headers.ContainsKey("authorization"))
                throw ExceptionFactory.FriendlyException(ExceptionEnum.AuthorizationHeaderNotExist,
                    "Authorization header not exist");

            headers.TryGetValue("authorization", out var token);
            var jwtToken = JwtService.ParseToken(token.ToString().Split(" ").Last(), AuthOption.KEY);
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value);
            var user = await _userService.GetUser(userId);

            var avatar = await _context.Avatar.FirstOrDefaultAsync(x => x.Id == user.AvatarId);

            return new OutUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                RoleId = user.RoleId,
                Avatar = avatar != null ? new OutAvatarViewModel
                {
                    Id = avatar.Id,Name = avatar.Name, Path = avatar.Path
                } : null,
                Email = user.UserSecurity.Email,
                RoleName = user.Role.Title,
            };
        }
    }
}