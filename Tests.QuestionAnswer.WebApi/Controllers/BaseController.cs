using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Tests.Security.Authorization;

namespace Tests.QuestionAnswer.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private bool IsTokenProvided => Request.Headers.ContainsKey("Authorization") ||
                                         Request.Headers.ContainsKey("authorization");
        private string StringToken => Request.Headers.ContainsKey("Authorization")
            ? Request.Headers.GetOrDefault("Authorization")
            : Request.Headers.GetOrDefault("authorization");

        protected JwtSecurityToken Token => IsTokenProvided ? JwtService.ParseTokenErrorSafe(StringToken.Split(" ").LastOrDefault() ?? string.Empty) ?? throw new Exception("Can't parse token") : throw new Exception("User don't provided token");

        protected int UserId()
        {
            try
            {
                return int.Parse(Token.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
