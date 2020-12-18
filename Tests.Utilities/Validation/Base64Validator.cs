using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tests.Utilities.Validation
{
    public static class Base64Validator
    {
        public static bool IsBase64String(string base64)
        {
            if (base64 == null)
            {
                return false;
            }
            base64 = base64.Trim();
            return (base64.Length % 4 == 0) && Regex.IsMatch(base64, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
    }
}
