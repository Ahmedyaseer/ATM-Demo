

using Microsoft.AspNetCore.Identity;

namespace ATM.DAL.DatabaseContext
{
    public  class AddOnIdentityUser : IdentityUser
    {
        public string AccountId { get; set; } = string.Empty;
    }
}
