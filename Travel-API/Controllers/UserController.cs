using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Travel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers().ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while getting all the users: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            try
            {
                var user = _userService.GetAllUsers().FirstOrDefault(u => u.Id == id);
                if (user == null)
                    return NotFound("Error while getting a user with that id.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Eror while getting a user with that id: " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            try
            {
                _userService.AddUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding a user: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            try
            {
                var user = _userService.GetAllUsers().FirstOrDefault(u => u.Id == id);
                if (user == null)
                    return NotFound("Errir while updating a user.");

                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                user.TravelID = updatedUser.TravelID;

                _userService.UpdateUser(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating a user: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _userService.GetAllUsers().FirstOrDefault(u => u.Id == id);
                if (user == null)
                    return NotFound("Error while deleting a user with that id.");

                _userService.DeleteUser(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting a user: " + ex.Message);
            }
        }
    }
}
