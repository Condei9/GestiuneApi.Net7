using GestiuneApi.Net7.AuthToken;
using GestiuneApi.Net7.Models;
using GestiuneSaliNET7.Data;
using GestiuneSaliNET7.Models;
using GestiuneSaliNET7.Repository;
using GestiuneSaliNET7.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace GestiuneSaliNET7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogin _loguser;

        public LoginController(ApplicationDBContext context, ILogin loguser)
        {
            _context = context;
            _loguser = loguser;
        }



        [HttpGet]
        public IActionResult Register()
        {
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([Bind("Name, Email, Password")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                userModel.Password = userModel.Password.Hash();
                userModel.Role = (int)Roles.User;
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([Bind("Email, Password")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var issuccess = _loguser.AuthenticateUser(userModel.Email, userModel.Password.Hash());
                var token = TokenManager.GenerateToken(userModel.Email);

                if (issuccess.Result != null)
                {
                    TempData["email"] = userModel.Email;
                    var res = new { message = "Success", token,issuccess.Result.Email,issuccess.Result.Role,issuccess.Result.Name };
                    return Ok(res);
                }
                else
                {

                    return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpPost("ValidatetToken")]
        public async Task<IActionResult> Validate([Bind("token")] AuthTokenModel authToken)
        {
            if (authToken.token == null )
            {
                return BadRequest();
            }

            var validate = TokenManager.ValidateToken(authToken.token);
            
            if(validate == null)
            {
                return BadRequest();
            }

            return Ok(true);
        }
    }
}
