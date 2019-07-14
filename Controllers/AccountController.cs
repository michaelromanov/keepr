using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserRepository _repo;
        public AccountController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("Register")]
        public async Task<User> Register([FromBody]UserRegistration creds)
        {
            try{
                User user = _repo.Register(creds);
                if (user == null) { BadRequest("Invalid Credentials"); }
                user.SetClaims();
                await HttpContext.SignInAsync(user._principal);
                return user;
            }catch(Exception e){
                 return Unauthorized(e);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody]UserLogin creds)
        {
            try{
                User user = _repo.Login(creds);
                if (user == null) { Unauthorized("Invalid Credentials"); }
                user.SetClaims();
                await HttpContext.SignInAsync(user._principal);
                return user;
            }catch(Exception e){
                 return Unauthorized(e);
            }
        }


        [HttpDelete("Logout")]
        public async Task<ActionResult<bool>> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok(true);
        }


        [Authorize]
        [HttpGet("Authenticate")]
        public ActionResult<User> Authenticate()
        {
            var id = HttpContext.User.Identity.Name;
            return Ok(_repo.GetUserById(id));
        }
    }
}
