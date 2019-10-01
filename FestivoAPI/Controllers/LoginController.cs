using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models.LoginModels;
using API.Models;
using API.BusinessLogic;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FestivoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        Login _login = new Login();

        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        private string GenerateJSONWebToken(string user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user)
            };


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> GetD()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("social")]
        public IActionResult socialLogin([FromBody]Users user)
        {
            Login login = new Login();
            var isUser = _login.socialLogin(user);
            if (isUser)
            {
                var role = _login.Role(user.Email);
                var Id = login.getUserId(user);
                var tokenn = GenerateJSONWebToken(role);
                // return Ok("User Login Successfull");
                LoginSuccess obj = new LoginSuccess()
                {
                    A = "user",
                    token = tokenn,
                    id = Id,
                    Name = login.getUserName(Id)

                };
                return Ok(obj);
            }
            else
            {
                return BadRequest();
            }
           
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public string GetD(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public string PostD([FromBody] Users model)
        {
            Login login = new Login();
            if (ModelState.IsValid)
            {

                if (login.login(model) == 1)
                {
                    var role = _login.Role(model.Email);
                    var Id = login.getUserId(model);
                    var tokenn = GenerateJSONWebToken(role);
                    // return Ok("User Login Successfull");
                    LoginSuccess obj = new LoginSuccess()
                    {
                        A = "user",
                        token = tokenn,
                        id=Id,
                        Name=login.getUserName(Id)

                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                }
                else if (login.login(model) == 2)
                {
                    var role = _login.Role(model.Email);
                    var Id = login.getUserId(model);
                    var tokenn = GenerateJSONWebToken(role);
                    LoginSuccess obj = new LoginSuccess()
                    {
                        A = "admin",
                        token = tokenn,
                        id = Id,
                        Name = login.getUserName(Id)

                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                    // return Ok("Admin Login Successfull");
                }
                else
                {
                    // return BadRequest("Email or password Invalid");
                    LoginSuccess obj = new LoginSuccess()
                    {
                        A = "Email or password Invalid"
                    };
                    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                }
            }
            else
            {
                // return BadRequest("Model Invalid");
                LoginSuccess obj = new LoginSuccess()
                {
                    A = "Email or password Invalid"
                };
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void PutD(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteD(int id)
        {
        }
    }
}
