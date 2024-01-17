﻿using ATM.BLL.Manager.AccountsManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ATM.API.Controllers.AccountsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IAccountManager accountManager;
        public UserAccountController(IAccountManager accountManager)
        {
            this.accountManager = accountManager;
        }


        [HttpGet]
        [Authorize (Policy ="UserPolicy")]
        [Route("VarifiedBalance")]
        public IActionResult LoginUserAuth()
        {
            var idOfCurrentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var account =  accountManager.Login(idOfCurrentUser );
            if(account == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);   
            }
            return Ok( new
            {
                balance = account.Balance
            });
        }
    }
}
