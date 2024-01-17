using ATM.BLL.DTOs.RegisterDtos;
using ATM.DAL.DatabaseContext;
using ATM.DAL.Models.Accounts;
using ATM.DAL.Repos.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace ATM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtRegisterController : ControllerBase
    {
        private readonly UserManager<AddOnIdentityUser> userManager;
        private readonly IAccountRepo accountRepo;

        public JwtRegisterController(
            UserManager<AddOnIdentityUser> userManager,
            IAccountRepo accountRepo
            )
        {
            this.userManager = userManager;
            this.accountRepo = accountRepo;
        }

        #region Register

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = new AddOnIdentityUser
            {
                UserName = registerDto.CardNumber,

            };
            var creationResult = await userManager.CreateAsync(user, registerDto.Pin);
            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }

            var claimsList = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName),
            new Claim(ClaimTypes.Role, "User"),

        };
            await userManager.AddClaimsAsync(user, claimsList);

            Account account = new Account
            {
                CardNumber = registerDto.CardNumber,
                Balance = registerDto.Balance,
            };
            accountRepo.AddWithSaveChanges(account);

            return StatusCode(StatusCodes.Status201Created);
        }

        #endregion



    }
}
