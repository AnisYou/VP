using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfidentialsWebAPI.Filters;
using ConfidentialsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfidentialsWebAPI.Controllers
{
    [Route("api/[Controller]")]
    [CustomAuthorizationFilter]
    public class ConfidentialsController : Controller
    {
        [HttpPost]
        [Route("")]
        public ActionResult Post([FromBody]User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return (UsersCredentials.ConfidentialUsers.Find(x => x.Email.Equals(user.Email)) != null) ? (ActionResult)Ok("Utilisateur authentifié") : Unauthorized();

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
