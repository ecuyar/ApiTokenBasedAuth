using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Auth
{
    public class LogInRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LogInResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorCode { get; set; }
        public string AccessToken { get; set; }
    }

    public class UserAuthentication
    {

    }
}
