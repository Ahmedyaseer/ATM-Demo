using ATM.BLL.DTOs.LoginDto;
using ATM.BLL.DTOs.TokenDto;
using ATM.DAL.DatabaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ATM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtLoginController : ControllerBase
    {
        private readonly UserManager<AddOnIdentityUser> userManager;
        private readonly IConfiguration configuration;

        public JwtLoginController(UserManager<AddOnIdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
        {


            AddOnIdentityUser? user = await userManager.FindByNameAsync(credentials.CardNumbr);
            if (user is null)
            {
                return Unauthorized();
            }

            bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, credentials.Pin);
            if (!isPasswordCorrect)
            {
                return Unauthorized();
            }



            var claimsList = await userManager.GetClaimsAsync(user);
            string secretKey = configuration.GetValue<string>("SecretKey")!;
            var algorithm = SecurityAlgorithms.HmacSha256Signature;

            var keyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(keyInBytes);
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                claims: claimsList,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(10));

            var tokenHandler = new JwtSecurityTokenHandler();

            return new TokenDto
            {
                Token = tokenHandler.WriteToken(token),
            };

        }
    }
}