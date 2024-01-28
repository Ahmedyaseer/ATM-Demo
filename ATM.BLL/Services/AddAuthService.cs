
using ATM.BLL.DTOs.LoginDto;
using ATM.BLL.DTOs.RegisterDtos;
using ATM.DAL.Models.Accounts;
using ATM.DAL.Repos.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ATM.BLL.Services
{
    public class AddAuthService : IAddAuthService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configration;
        private readonly IAccountRepo accountRepo;

        public AddAuthService(UserManager <IdentityUser> userManager ,
            IConfiguration configration ,
            IAccountRepo accountRepo)
        {
            this.userManager = userManager;
            this.configration = configration;
            this.accountRepo = accountRepo;
        }





        public async Task<bool> RegisterUser(RegisterDto registerDto)
        {
            var user = new IdentityUser
            {
                UserName = registerDto.CardNumber,

            };
            var creationResult = await userManager.CreateAsync(user, registerDto.Pin);
            if( creationResult.Succeeded == true)
            {
                var account = new Account
                {
                    CardNumber = registerDto.CardNumber,
                    Balance = registerDto.Balance,
                };

                accountRepo.AddWithSaveChanges(account);
                return true;
            }
            return false;

           

            


        }



        public async Task<bool> Login(LoginDto credentials)
        {
            #region CardNumber and Pin verification

            var user = await userManager.FindByNameAsync(credentials.CardNumbr);
            if (user is null)
            {
                return false;
            }

            bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, credentials.Pin);
            if (!isPasswordCorrect)
            {
                return false;
            }

            return true;
            #endregion
        }




        public  string  GenerateToken(LoginDto credentials)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, credentials.CardNumbr),
            new Claim(ClaimTypes.Role, "User"),
            
        };
        

            string? secretKey = configration.GetSection("SecretKey").Value;
            var algorithm = SecurityAlgorithms.HmacSha256Signature;

            var keyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(keyInBytes);
            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(10));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
            
        }
    }
}
