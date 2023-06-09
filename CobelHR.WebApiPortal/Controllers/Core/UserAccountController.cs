using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Core.Abstract;
using CobelHR.Entities.Core;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Core
{
    [Route("api/Core")]
    public class UserAccountController : BaseController
    {
        public UserAccountController(IUserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

        private IUserAccountService userAccountService { get; set; }

        [HttpGet]
        [Route("UserAccount/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.userAccountService.RetrieveById(id, UserAccount.Informer, this.UserCredit);

			return result.ToActionResult<UserAccount>();
        }

        [HttpPost]
        [Route("UserAccount/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.userAccountService.RetrieveAll(UserAccount.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<UserAccount>();
        }
            

        
        [HttpPost]
        [Route("UserAccount/Save")]
        public async Task<IActionResult> Save([FromBody] UserAccount userAccount)
        {
            var result = await this.userAccountService.Save(userAccount, this.UserCredit);

			return result.ToActionResult<UserAccount>();
        }

        
        [HttpPost]
        [Route("UserAccount/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] UserAccount userAccount)
        {
            var result = await this.userAccountService.SaveAttached(userAccount, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("UserAccount/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<UserAccount> userAccountList)
        {
            var result = await this.userAccountService.SaveBulk(userAccountList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("UserAccount/Seek")]
        public async Task<IActionResult> Seek([FromBody] UserAccount userAccount)
        {
            var result = await this.userAccountService.Seek(userAccount, this.UserCredit);

			return result.ToActionResult<UserAccount>();
        }

        [HttpGet]
        [Route("UserAccount/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.userAccountService.SeekByValue(seekValue, UserAccount.Informer, this.UserCredit);

			return result.ToActionResult<UserAccount>();
        }

        [HttpPost]
        [Route("UserAccount/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] UserAccount userAccount)
        {
            var result = await this.userAccountService.Delete(userAccount, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}