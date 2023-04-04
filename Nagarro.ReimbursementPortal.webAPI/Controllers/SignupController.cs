using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nagarro.ReimbursementPortal.webAPI.Data;
using Nagarro.ReimbursementPortal.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ReimbursementPortal.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly DataContext dbContext;

        public SignupController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Signup userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            var user = await dbContext.SignupUsers.FirstOrDefaultAsync(x => x.Email == userObj.Email && x.Password == userObj.Password);

            if (user == null)
            {
                return NotFound(new { Message = "User Not Found!" });
            }
            return Ok(new
            {
                Message = "Login Success!"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] Signup userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            //if(String.IsNullOrEmpty(userObj.Username))

            await dbContext.SignupUsers.AddAsync(userObj);
            await dbContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "register Succes!"
            });

        }
    }
}
