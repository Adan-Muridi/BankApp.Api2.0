using BankApp.Api.AuthenticationServise;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        private IAuthService _authService;

        public AccountsController(UserManager<IdentityUser> userManager, IConfiguration configuration, IAuthService authService)
        {
            _authService= authService;
            _userManager = userManager;
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserAuthenticationDto userAuthenticationDto)
        {
            var user = await _userManager.FindByNameAsync(userAuthenticationDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userAuthenticationDto.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = _authService.GetSigningCredentials();
            var claims = _authService.GetClaims(user);
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenOptions = _authService.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }

        //private SigningCredentials GetSigningCredentials() 
        //{ 
        //    var key = Encoding.UTF8.GetBytes(_jwtSettings["securityKey"]); 
        //    var secret = new SymmetricSecurityKey(key); 
            
        //    return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256); 
        //}

        //private async Task<List<Claim>> GetClaims(IdentityUser user)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.Email)
        //    };

        //    var roles = await _userManager.GetRolesAsync(user);

        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    }
        //    return claims;
        //}

        //private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims) 
        //{ 
        //    var tokenOptions = new JwtSecurityToken(
        //        issuer: _jwtSettings["validIssuer"], 
        //        audience: _jwtSettings["validAudience"], 
        //        claims: claims, 
        //        expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])), 
        //        signingCredentials: signingCredentials); 
            
        //    return tokenOptions; 
        //}
    }
}





//var user = await _userManager.FindByNameAsync(userAuthenticationDto.Email);

//if (user == null || !await _userManager.CheckPasswordAsync(user, userAuthenticationDto.Password))
//    return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

//var signingCredentials = GetSigningCredentials();
//var claims = await GetClaims(user);
//var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
//var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

//return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });