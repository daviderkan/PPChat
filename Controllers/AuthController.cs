using Microsoft.AspNetCore.Mvc;
using PPChat.Models;
using PPChat.Services;
using PPChat.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPChat.Settings;

namespace PPChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private UserService _userService;
        private IPPChatSessionSettings _sessionSettings;

        public AuthController(UserService userService, IPPChatSessionSettings sessionSettings)
        {
            _userService = userService;
            _sessionSettings = sessionSettings;
        }

        [HttpPost("Login")]
        public User Login(User user)
        {
            var queryResult = _userService.GetByUsername(user.Name);

            if (queryResult != null && queryResult.Password == user.Password)
            {
                HttpContext.Session.Set<User>(_sessionSettings.Name, queryResult);
            }
            return HttpContext.Session.Get<User>(_sessionSettings.Name);
        }

        [HttpPost("Logout")]
        public void Logout()
        {
            HttpContext.Session.Clear();
        }

        [HttpPost("LoggedUser")]
        public User LoggedUser()
        {
            return HttpContext.Session.Get<User>(_sessionSettings.Name);
        }
    }
}
