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
    public class RoleMemberController : BaseController
    {
        public RoleMemberController(IRoleMemberService roleMemberService)
        {
            this.roleMemberService = roleMemberService;
        }

        private IRoleMemberService roleMemberService { get; set; }

        [HttpGet]
        [Route("RoleMember/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.roleMemberService.RetrieveById(id, RoleMember.Informer, this.UserCredit);

			return result.ToActionResult<RoleMember>();
        }

        [HttpPost]
        [Route("RoleMember/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.roleMemberService.RetrieveAll(RoleMember.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<RoleMember>();
        }
            

        
        [HttpPost]
        [Route("RoleMember/Save")]
        public async Task<IActionResult> Save([FromBody] RoleMember roleMember)
        {
            var result = await this.roleMemberService.Save(roleMember, this.UserCredit);

			return result.ToActionResult<RoleMember>();
        }

        
        [HttpPost]
        [Route("RoleMember/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] RoleMember roleMember)
        {
            var result = await this.roleMemberService.SaveAttached(roleMember, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("RoleMember/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<RoleMember> roleMemberList)
        {
            var result = await this.roleMemberService.SaveBulk(roleMemberList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("RoleMember/Seek")]
        public async Task<IActionResult> Seek([FromBody] RoleMember roleMember)
        {
            var result = await this.roleMemberService.Seek(roleMember, this.UserCredit);

			return result.ToActionResult<RoleMember>();
        }

        [HttpGet]
        [Route("RoleMember/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.roleMemberService.SeekByValue(seekValue, RoleMember.Informer, this.UserCredit);

			return result.ToActionResult<RoleMember>();
        }

        [HttpPost]
        [Route("RoleMember/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] RoleMember roleMember)
        {
            var result = await this.roleMemberService.Delete(roleMember, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}