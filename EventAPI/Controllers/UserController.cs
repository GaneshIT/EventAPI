using EventBusiness.Services;
using EventEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private readonly UserService _user;
        public UserController(UserService user, IConfiguration config)
        {
            _config = config;
            _user = user;
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            bool status=_user.AddUser(user);
            if (status)
                return Ok("Inserted");
            return BadRequest();
        }
        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            UserModel userData = _user.Login(user);
            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_user.GetUsers());
        }
    }
}
