using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Tests.Security.Options;
using Tests.Utilities.Exceptions;

namespace Tests.Security.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                ParseToken(context, token);
            }
            await _next(context);
        }

        private void ParseToken(HttpContext context, string token)
        {
            var jwtToken = JwtService.ParseToken(token, AuthOption.KEY);
            context.User = new GenericPrincipal(new AuthorizedUserModel
            {
                Id = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value),
                RoleId = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value),
            }, new[] { "" });
        }
    }
}
