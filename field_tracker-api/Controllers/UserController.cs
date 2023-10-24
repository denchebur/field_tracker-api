using field_tracker_api.Models.User;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace field_tracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser_Service _user_Service;

        //private Guid UserId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public UserController(IUser_Service user_Service)
        {
            _user_Service = user_Service;
        }

        [HttpGet]
        //[Authorize (Roles = "User")]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> GetUserById()
        {
            try
            {
                /*Int64.Parse(User.FindFirst("sub")?.Value)*/
                var result = await _user_Service.GetUserById(Convert.ToInt64(User.Claims.ToList().Find(r => r.Type == "UserId").Value));
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        //[Authorize (Roles = "User")]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                /*Int64.Parse(User.FindFirst("sub")?.Value)*/
                var result = await _user_Service.GetAllUsers();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUser(User_PassObject user)
        {
            try
            {
                var result = await _user_Service.AddUser(user.name, user.surname, user.email, user.phone, user.password, user.role);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserUpdate_PassObject user)
        {
            try
            {
                var result = await _user_Service.UpdateUser(user.user_id ,user.name, user.surname, user.email, user.phone, user.password, user.role);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> DeleteUserById()
        {
            try
            {
                var result = await _user_Service.DeleteUserById(Convert.ToInt64(User.Claims.ToList().Find(r => r.Type == "UserId").Value));
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserById(long id)
        {
            try
            {
                var result = await _user_Service.DeleteUserById(id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
