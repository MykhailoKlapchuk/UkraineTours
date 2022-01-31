using Microsoft.AspNetCore.Http;
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
using UkraineToursAPI.Dtos;
using UkraineToursAPI.Errors;
using UkraineToursAPI.Extensions;
using UkraineToursAPI.Interfaces;
using UkraineToursAPI.Models;

namespace UkraineToursAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IConfiguration configuration;
        public AccountController(IUnitOfWork uow, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.uow = uow;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginReqDto loginReq)
        {
            var user = await uow.UserRepository.Authenticate(loginReq.UserName, loginReq.Password);

            ApiError apiError = new ApiError();

            if (user == null)
            {
                apiError.ErrorCode=Unauthorized().StatusCode;
                apiError.ErrorMessage="Invalid user name or password";
                apiError.ErrorDetails="This error appear when provided user id or password does not exists";
                return Unauthorized(apiError);
            }

            var loginRes = new LoginResDto();
            loginRes.UserName = user.UserName;
            loginRes.Token = CreateJWT(user);
            return Ok(loginRes);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterReqDto user)
        {
            ApiError apiError = new ApiError();

            if (user.UserName.IsEmpty() || user.Password.IsEmpty())
            {
                    apiError.ErrorCode=BadRequest().StatusCode;
                    apiError.ErrorMessage="User name or password can not be blank";                    
                    return BadRequest(apiError);
            }                    

            if (await uow.UserRepository.UserAlreadyExists(user.UserName)) {
                apiError.ErrorCode=BadRequest().StatusCode;
                apiError.ErrorMessage="User already exists, please try different user name";
                return BadRequest(apiError);
            }                

            uow.UserRepository.Register(user);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        private string CreateJWT(User user)
        {
            var secretKey = configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(secretKey));

            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var signingCredentials = new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
