using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PhongKhamNhaKhoa.Api.Entitis;
using PhongKhamNhaKhoa.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhongKhamNhaKhoa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        public LoginController(IConfiguration configuration, SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
            if (!result.Succeeded) return BadRequest(new LoginResponse { Success = false, Error = "UserName and Password are invalid"});
            
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
                );
            return Ok(new LoginResponse { Success = true,Token = new JwtSecurityTokenHandler().WriteToken(token)});
        }
    }
}
