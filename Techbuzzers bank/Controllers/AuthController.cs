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
            var dbuser = _db.userDetails.FirstOrDefault(e => e.PhoneNumber == userDetails.PhoneNumber || e.Email == userDetails.Email);
            if (dbuser != null)
            {
                if(dbuser.Email == userDetails.Email)
                {
                    return BadRequest("Email is already registered");
                }
                else
                {
                    return BadRequest("Phone number is already registered");
                }
               
            }
            else
            {
                Account a = new Account();
                a.UserId = userDetails.Id;
                a.Balance = 5000.00f;
                _db.account.Add(a);
                _db.SaveChanges();
                Account acc = _db.account.FirstOrDefault( e => e.UserId == userDetails.Id);
                userDetails.accounts.Add(acc.Id);

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
                        new Claim("UserId", user.Id.ToString()),
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
                        expires: DateTime.UtcNow.AddDays(10),
                        signingCredentials: signIn);
                    SigninResponse response = new SigninResponse();
                    response.message = "signin succes";
                    response.token = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(response);
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
    public class SigninResponse
    {
        public string message { get; set; }
        public string token { get; set; }
    }
}
