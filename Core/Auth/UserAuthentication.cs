using Entity;
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
        //initial dumb data
        public static List<User> users = new()
        {
            new User() { Id = 1, Username = "Jan", Password = "Janjan" },
            new User() { Id = 2, Username = "Feb", Password = "Febfeb" },
            new User() { Id = 3, Username = "Marc", Password = "Marcmarc" }
        };

        public static LogInResponse LogInResponse(LogInRequest request)
        {
            var user = users.Where(x => x.Username == request.Username).FirstOrDefault();

            //check user if exists
            if (user == null)
            {
                return new LogInResponse() { IsSuccess = false, ErrorCode = "UserNotExists" };
            }

            //if exists you can check user password
            //we will generate token for user

        }
    }
}
