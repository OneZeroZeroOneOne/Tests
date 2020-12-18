using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Utilities.Exceptions
{
    public class AuthenticationException : Exception
    {
        public int exceptionCode;
        public string exceptionMessage;
        public AuthenticationException(int code, string message) : base(message)
        {
            exceptionMessage = message;
            exceptionCode = code;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new { exceptionCode, Message = exceptionMessage });
        }
    }
}
