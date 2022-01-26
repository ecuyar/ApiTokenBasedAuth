using Core.Auth;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ApiTokenBasedAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration configuration;

        //initial dumb data
        public static List<User> users = new()
        {
            new User() { Id = 1, Username = "Jan", Password = "Janjan" },
            new User() { Id = 2, Username = "Feb", Password = "Febfeb" },
            new User() { Id = 3, Username = "Marc", Password = "Marcmarc" }
        };

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public LogInResponse AuthLogin([FromBody] LogInRequest request)
        {
            //we dont access data etc. from here. just send data to core and validate the request from there
            return UserAuthentication.LogInResponse(request, configuration);
        }

        //authorize attribute doesnt allow to be reached without authorization
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            //use dumb data to search
            var user = users.Find(x => x.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }
}
