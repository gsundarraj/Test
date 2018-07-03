using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IIAC.Manager.Interfaces;
using IIAC.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace IIAC.Api.Controllers
{
    [EnableCors("IIAC")]
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private IUserManager _userManager;
        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public Task<IEnumerable<User>> GetUsers()
        {
            return _userManager.GetUsers();
        }
        [HttpGet]
        [Route("{id:int}")]
        public User Get(int id)
        {
            return _userManager.GetUser(id);
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post([FromBody]User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var users = await _userManager.GetUsers();
                var userExist = users.Where(x => x.Mobile == user.Mobile).SingleOrDefault();
                if (userExist != null && user.Id == 0)
                {
                    return Ok(userExist.Id);
                }
                return Ok(_userManager.UpsertUser(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}