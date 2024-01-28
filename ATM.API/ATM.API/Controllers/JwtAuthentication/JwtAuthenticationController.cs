using ATM.BLL.DTOs.LoginDto;
using ATM.BLL.DTOs.RegisterDtos;
using ATM.BLL.Services;
using Microsoft.AspNetCore.Mvc;


namespace ATM.API.Controllers.JwtAuthentication
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class JwtAuthenticationController : ControllerBase
    {
        private readonly IAddAuthService addAuthService;


        public JwtAuthenticationController(IAddAuthService addAuthService)

        {
            this.addAuthService = addAuthService;
        }

       

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if( await addAuthService.RegisterUser(registerDto))
            {
                return Ok("Successfuly Registered");
            }
            return BadRequest();
            
        }




        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginDto credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

          var result = await addAuthService.Login(credentials);

            if(result == true)
            {
                var tokenString = addAuthService.GenerateToken(credentials);
                return Ok(tokenString);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            
        }

          
        
        
    }
}
