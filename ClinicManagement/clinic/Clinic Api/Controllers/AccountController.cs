using clinic.ApplicationDbContext;
using Microsoft.AspNetCore.Mvc;
using clinic.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BCrypt.Net;
using AutoMapper;
using clinic.DTOs;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using clinic.Utility;

namespace clinic.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper; // إضافة AutoMapper

        public AccountController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,IConfiguration configuration,IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost("Register", Name = "Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Add(AccountDTO accountDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); 
                }

                var user = _mapper.Map<ApplicationUser>(accountDTO); 
                IdentityResult result = await _userManager.CreateAsync(user, accountDTO.Password);

                if (result.Succeeded)
                {
                    var roleExists = await _roleManager.RoleExistsAsync(SD.RoleUser);
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.RoleUser)); 
                        await _roleManager.CreateAsync(new IdentityRole(SD.RoleAdmin)); 
                    }
                    await _userManager.AddToRoleAsync(user, SD.RoleUser);
                    return Ok(new { Message = "تم تسجيل المستخدم بنجاح", UserId = user.Id });
                }

                return BadRequest(result.Errors); 
            }
            catch (Exception)
            {
                return StatusCode(500, "حدث خطأ غير متوقع."); 
            }
        }

        [HttpPost("Login", Name = "Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(loginUserDTO loginUserDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); 
                }

                var user = await _userManager.FindByNameAsync(loginUserDTO.UserName);
                if (user == null || !await _userManager.CheckPasswordAsync(user, loginUserDTO.Password))
                {
                    return Unauthorized(); 
                }

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var roles = await _userManager.GetRolesAsync(user);
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var secretKey = _configuration["JWT:Key"];
                if (string.IsNullOrEmpty(secretKey))
                {
                    return StatusCode(500, "إعدادات JWT مفقودة."); 
                }

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                );

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token), 
                    Expiration = token.ValidTo 
                });
            }
            catch (Exception E)
            {
                return StatusCode(500, $"حدث خطأ غير متوقع. {E.Message}"); 
            }
        }
    }

}

