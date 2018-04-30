using AuthenticationWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthenticationWebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class AuthenticateController : Controller
    {
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody]User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (UsersCredentials.AllUsers.ContainsKey(user.Email))
                    {
                        return (UsersCredentials.AllUsers[user.Email].Password.Equals(user.Password)) ? (ActionResult)Ok("Utilisateur authentifié") : Unauthorized();
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
        
    }
}
