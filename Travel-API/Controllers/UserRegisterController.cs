using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Travel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {
        private readonly IUserRegisteredService _userRegistrationService;

        public UserRegisterController(IUserRegisteredService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost]
        public IActionResult AddUser(UserRegister user)
        {
            try
            {
                // Hash the password before storing it
                user.Password = HashPassword(user.Password);

                _userRegistrationService.AddUser(user);
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = _userRegistrationService.GetUserById(id);
                if (user != null)
                {
                    _userRegistrationService.DeleteUser(id);
                    return Ok("User deleted successfully.");
                }
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userRegistrationService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userRegistrationService.GetUserById(id);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserRegister user)
        {
            try
            {
                var existingUser = _userRegistrationService.GetUserById(id);
                if (existingUser != null)
                {
                    // Hash the password before updating it
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    existingUser.Password = HashPassword(user.Password);

                    _userRegistrationService.UpdateUser(existingUser);
                    return Ok("User updated successfully.");
                }
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = Convert.ToBase64String(hashedBytes);
                return hash;
            }
        }
    }
}
