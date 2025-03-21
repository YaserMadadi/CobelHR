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
    public class RolePermissionController : BaseController
    {
        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            this.rolePermissionService = rolePermissionService;
        }

        private IRolePermissionService rolePermissionService { get; set; }

        [HttpGet]
        [Route("RolePermission/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.rolePermissionService.RetrieveById(id, RolePermission.Informer, this.UserCredit);

			return result.ToActionResult<RolePermission>();
        }

        [HttpPost]
        [Route("RolePermission/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.rolePermissionService.RetrieveAll(RolePermission.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<RolePermission>();
        }
            

        
        [HttpPost]
        [Route("RolePermission/Save")]
        public async Task<IActionResult> Save([FromBody] RolePermission rolePermission)
        {
            var result = await this.rolePermissionService.Save(rolePermission, this.UserCredit);

			return result.ToActionResult<RolePermission>();
        }

        
        [HttpPost]
        [Route("RolePermission/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] RolePermission rolePermission)
        {
            var result = await this.rolePermissionService.SaveAttached(rolePermission, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("RolePermission/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<RolePermission> rolePermissionList)
        {
            var result = await this.rolePermissionService.SaveBulk(rolePermissionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("RolePermission/Seek")]
        public async Task<IActionResult> Seek([FromBody] RolePermission rolePermission)
        {
            var result = await this.rolePermissionService.Seek(rolePermission, this.UserCredit);

			return result.ToActionResult<RolePermission>();
        }

        [HttpGet]
        [Route("RolePermission/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.rolePermissionService.SeekByValue(seekValue, RolePermission.Informer, this.UserCredit);

			return result.ToActionResult<RolePermission>();
        }

        [HttpPost]
        [Route("RolePermission/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] RolePermission rolePermission)
        {
            var result = await this.rolePermissionService.Delete(rolePermission, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}