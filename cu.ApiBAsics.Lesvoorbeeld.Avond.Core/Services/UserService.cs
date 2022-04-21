using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Entities;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Login(string username, string password)
        {
            //signin the user using signInmanager
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

            if (!result.Succeeded)
            {
                return false;
            }
            //user authenticated
            //get the user data
            var user = await _userManager.FindByNameAsync(username);

            //get the claims
            var userClaims = await _userManager.GetClaimsAsync(user);
            ////get the roles and turn into claims
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                userClaims.Add(
                    new Claim("role", role)
                    );
            }

            //create the claimsIdentity
            var claimsIdentity = new ClaimsIdentity(userClaims, "CookieAuth");
            ////create the claimsPrincipal
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            //log in the context
            try
            {
                await _httpContextAccessor.HttpContext.SignInAsync(claimsPrincipal);
                var claims = _httpContextAccessor.HttpContext.User.Claims;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
