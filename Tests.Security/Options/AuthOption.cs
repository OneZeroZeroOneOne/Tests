using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Tests.Security.Options
{
    public static class AuthOption
    {
        public static string ISSUER; // издатель токена
        public static string AUDIENCE; // потребитель токена
        public static string KEY;   // ключ для шифрации
        public static int LIFETIME = 3600; // время жизни токена - 1 минута

        public static void SetAuthOption(string issuer, string audience, string key, int lifetime)
        {
            ISSUER = issuer;
            AUDIENCE = audience;
            KEY = key;
            LIFETIME = lifetime;
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
