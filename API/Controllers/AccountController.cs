using API.DTOs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(SignInManager<User> signInManager) : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterDto registerDto)
        {
            var user = new User
            {
                DisplayName = registerDto.DisplayName,
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            var result = await signInManager.UserManager.CreateAsync(user, registerDto.Password);


            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            if (result.Succeeded)
            {
                 return Ok();
            }

            return ValidationProblem();
           
        }

        [AllowAnonymous]
        [HttpGet("user-info")]
        public async Task<ActionResult> GetUserInfo()
        {
            if(User.Identity?.IsAuthenticated == false) return NoContent();
            var user = await signInManager.UserManager.GetUserAsync(User);

            if (user == null ) return Unauthorized();

            return Ok(new { user.DisplayName, user.Email, user.Id, user.ImageUrl });
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return NoContent();
        }
        
    }
}
