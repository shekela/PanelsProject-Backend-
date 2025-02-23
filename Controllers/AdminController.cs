using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanelsProject_Backend.Data;
using PanelsProject_Backend.DTO_s;
using PanelsProject_Backend.Entities;
using PanelsProject_Backend.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PanelsProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AdminController(DataContext context, ITokenService tokenService)
        {
              _context = context;
              _tokenService = tokenService;
        }


        //[HttpPost("register-admin")]
        //public async Task<ActionResult<ReturnAdmin>> RegisterAdmin([FromForm] AdminDto admin)
        //{
        //    if (admin == null)
        //    {
        //        return BadRequest("Admin cannot be null");
        //    }

        //    using var hmac = new HMACSHA512();
        //    var user = new Admin
        //    {
        //        Email = admin.Email.ToLower(),
        //        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(admin.Password)),
        //        PasswordSalt = hmac.Key,
        //    };
        //    var returnUser = new ReturnAdmin
        //    {
        //        Email = user.Email.ToLower(),
        //        Token = _tokenService.CreateTokenAdmin(user)
        //    };

        //    await _context.Admins.AddAsync(user);
        //    await _context.SaveChangesAsync();
        //    return Ok(returnUser);
        //}


        [HttpPost("login-admin")]
        public async Task<ActionResult<ReturnAdmin>> Login(AdminDto logindto)
        {
            var user = await _context.Admins.SingleOrDefaultAsync(x => x.Email == logindto.Email);
            string token;

            if (user == null)
            {
                return Unauthorized("User not found");
            }
            
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Password is incorrect");
                }
            }
            token = _tokenService.CreateTokenAdmin(user);
            return new ReturnAdmin { Email = user.Email, Token = token };
        }

    }
}
