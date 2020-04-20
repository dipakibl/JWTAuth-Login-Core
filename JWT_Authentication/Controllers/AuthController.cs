using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JWT_Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWT_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IConfiguration _Configuration;
        private UserContext _context;
        public AuthController(IConfiguration configuration, UserContext context)
        {
            _Configuration = configuration;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(string username, string pass)
        {
            UserModel login = new UserModel();
            login.UserName = username;
            login.Password = pass;

            IActionResult response = Unauthorized();
            var userModel = AuthenticateUser(login);
            if (userModel != null)
            {
                var newtoken = GetToken(userModel);
                response = Ok(new { token = newtoken });
            }

            return response;

        }
        private UserModel AuthenticateUser(UserModel user)
        {
            UserModel userModel = null;

            userModel = _context.userModels.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            return userModel;

        }
        private string GetToken(UserModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
            var Credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_Configuration["Jwt:Issuer"],
                _Configuration["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: Credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            return _context.userModels.ToList();
        }
    }
}