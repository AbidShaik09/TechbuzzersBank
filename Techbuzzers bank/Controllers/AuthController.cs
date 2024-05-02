using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Techbuzzers_bank.Data;
using Techbuzzers_bank.Interface;
using Techbuzzers_bank.Models;
using Techbuzzers_bank.Repository;

namespace Techbuzzers_bank.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _config;
        private readonly IUsers _user;
        private readonly ApplicationDbContext _db;
        public AuthController( IConfiguration config, ApplicationDbContext db) { 
            _db= db;
            _config = config;
            _user= new UserRepository(db);
        }


        [HttpPost("/signup")]
        public async Task<IActionResult> signUp(UserDetails userDetails)
        {
            if (userDetails == null)
            {
                return BadRequest("Userdetails not recieved");
            }
            else
            {
                _user.AddUser(userDetails);
                
                return Ok();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> signIn(UserCred userDetails)
        {
            if (userDetails != null && userDetails.PhoneNumber != null && userDetails.Pin!= null)
            {
                UserDetails user = _user.GetUser(userDetails.PhoneNumber, userDetails.Pin);

                if (user != null)
                {
                    
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id),
                        new Claim("DisplayName", user.FirstName),
                        new Claim("UserName", user.LastName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }

        }
    }
    public class UserCred
    {
        public long PhoneNumber { get; set; }
        public int Pin { get; set; }
    }
}
