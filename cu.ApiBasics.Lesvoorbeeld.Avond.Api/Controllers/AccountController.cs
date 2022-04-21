using cu.ApiBasics.Lesvoorbeeld.Avond.Api.Dtos.Account;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AccountRegisterRequestdto accountRegisterRequestdto)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState.Values);
            //}
            ////create IdentityUser
            //var newUser = new ApplicationUser {UserName = accountRegisterRequestdto.Email,Email = accountRegisterRequestdto.Email };
            ////Add claims
            
            ////call usermanager create async
            //var result = await _userManager.CreateAsync(newUser, accountRegisterRequestdto.Password);
            //if(!result.Succeeded)
            //{
            //    return BadRequest(result.Errors);
            //}
            return Ok("User added!");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AccountLoginRequestDto accountLoginRequestDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            var result = await _userService.Login(accountLoginRequestDto.Email, accountLoginRequestDto.Password);
            if(result)
            {
                return Ok("loggedIn");
            }
            return Unauthorized("Loginfailed");
            
        }
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult Test()
        {
            return Ok("Allowed!");
        }
    }
}
