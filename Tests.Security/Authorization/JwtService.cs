using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Tests.Security.Options;
using Tests.Utilities.Exceptions;

namespace Tests.Security.Authorization
{
    public static class JwtService
    {


        public  static ClaimsIdentity GetUserIdentity(int id, int roleId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, roleId.ToString()),
            };
            return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public static string GenerateToken(ClaimsIdentity claims)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOption.ISSUER,
                audience: AuthOption.AUDIENCE,
                notBefore: now,
                claims: claims.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOption.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOption.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return "Bearer " + new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public static JwtSecurityToken? ParseTokenErrorSafe(string token)
        {
            try
            {
                return ParseToken(token, AuthOption.KEY);
            }
            catch
            {
                return null;
            }
        }

        public static JwtSecurityToken ParseToken(string token, string securityKey)
        {
            if (string.IsNullOrEmpty(securityKey) || string.IsNullOrEmpty(token))
            {
                throw ExceptionFactory.SoftException(ExceptionEnum.SecurityKeyIsNull, "Invalid security key");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKeyBytes = Encoding.ASCII.GetBytes(securityKey);

            SecurityToken SignatureValidator(string encodedToken, TokenValidationParameters parameters)
            {
                var jwt = new JwtSecurityToken(encodedToken);

                var hmac = new HMACSHA256(securityKeyBytes);

                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(hmac.Key), SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);

                var signKey = signingCredentials.Key as SymmetricSecurityKey;

                var encodedData = jwt.EncodedHeader + "." + jwt.EncodedPayload;
                var compiledSignature = Encode(encodedData, signKey.Key);

                if (compiledSignature != jwt.RawSignature)
                {
                    throw new Exception("Token signature validation failed.");
                }
                return jwt;
            }

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(securityKeyBytes),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireSignedTokens = false, //погугли
                ClockSkew = TimeSpan.Zero,
                SignatureValidator = SignatureValidator,
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            return jwtToken;
        }
        private static string Encode(string input, byte[] key)
        {
            HMACSHA256 sha = new HMACSHA256(key);
            byte[] byteArray = Encoding.UTF8.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            byte[] hashValue = sha.ComputeHash(stream);
            return Base64UrlEncoder.Encode(hashValue);
        }
    }
}
