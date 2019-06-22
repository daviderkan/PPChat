using Microsoft.AspNetCore.Mvc;
using PPChat.Models;
using PPChat.Services;
using PPChat.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPChat.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {

        private readonly UserService _userService;
        private readonly IPPChatSessionSettings _sessionSettings;

        public UsersController(UserService userService, IPPChatSessionSettings sessionSettings)
        {
            _userService = userService;
            _sessionSettings = sessionSettings;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() => _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost("Create")]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPost("Register")]
        public User Register(User user)
        {
            return _userService.Create(user);
        }

        [HttpPost("Login")]
        public User Login(User user)
        {
            var queryResult = _userService.GetByUsername(user.Name);

            if (queryResult != null && queryResult.Password == user.Password)
                HttpContext.Session.Set<User>(_sessionSettings.Name, queryResult);
            return HttpContext.Session.Get<User>(_sessionSettings.Name);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Remove(user.Id);

            return NoContent();
        }
    }
}
