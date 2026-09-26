using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;


        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            // Demo user (replace with DB validation in real projects)
            if (login.Username != "admin" || login.Password != "admin123")
            {
                return Unauthorized("Invalid username or password.");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: creds);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
    //public class AuthController : ControllerBase
    //{
    //    private readonly IConfiguration _configuration;


    //    public AuthController(IConfiguration configuration)
    //    {
    //        _configuration = configuration;
    //    }

    //    [HttpPost("login")]
    //    public IActionResult Login(LoginDto login)
    //    {
    //        // Demo user (replace with DB validation in real projects)
    //        if (login.Username != "admin" || login.Password != "admin123")
    //        {
    //            return Unauthorized("Invalid username or password.");
    //        }

    //        var claims = new[]
    //        {
    //            new Claim(ClaimTypes.Name, login.Username),
    //            new Claim(ClaimTypes.Role, "Admin")
    //        };

    //        var key = new SymmetricSecurityKey(
    //            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

    //        var creds = new SigningCredentials(
    //            key,
    //            SecurityAlgorithms.HmacSha256);

    //        var token = new JwtSecurityToken(
    //            issuer: _configuration["Jwt:Issuer"],
    //            audience: _configuration["Jwt:Audience"],
    //            claims: claims,
    //            expires: DateTime.UtcNow.AddMinutes(
    //                Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
    //            signingCredentials: creds);

    //        return Ok(new
    //        {
    //            Token = new JwtSecurityTokenHandler().WriteToken(token)
    //        });
    //    }

    //}

}