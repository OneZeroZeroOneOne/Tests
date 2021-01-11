using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Utilities
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input.Substring(1)
            };

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdrfghijklmnopqrstuvwxyz0123456789_!?";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
