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
    public class RoleController : BaseController
    {
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        private IRoleService roleService { get; set; }

        [HttpGet]
        [Route("Role/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.roleService.RetrieveById(id, Role.Informer, this.UserCredit);

			return result.ToActionResult<Role>();
        }

        [HttpPost]
        [Route("Role/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.roleService.RetrieveAll(Role.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Role>();
        }
            

        
        [HttpPost]
        [Route("Role/Save")]
        public async Task<IActionResult> Save([FromBody] Role role)
        {
            var result = await this.roleService.Save(role, this.UserCredit);

			return result.ToActionResult<Role>();
        }

        
        [HttpPost]
        [Route("Role/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Role role)
        {
            var result = await this.roleService.SaveAttached(role, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Role/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Role> roleList)
        {
            var result = await this.roleService.SaveBulk(roleList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Role/Seek")]
        public async Task<IActionResult> Seek([FromBody] Role role)
        {
            var result = await this.roleService.Seek(role, this.UserCredit);

			return result.ToActionResult<Role>();
        }

        [HttpGet]
        [Route("Role/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.roleService.SeekByValue(seekValue, Role.Informer, this.UserCredit);

			return result.ToActionResult<Role>();
        }

        [HttpPost]
        [Route("Role/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Role role)
        {
            var result = await this.roleService.Delete(role, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfRoleMember
        [HttpPost]
        [Route("Role/{role_id:int}/RoleMember")]
        public IActionResult CollectionOfRoleMember([FromRoute(Name = "role_id")] int id, RoleMember roleMember)
        {
            return this.roleService.CollectionOfRoleMember(id, roleMember, this.UserCredit).ToActionResult();
        }

		// CollectionOfRolePermission
        [HttpPost]
        [Route("Role/{role_id:int}/RolePermission")]
        public IActionResult CollectionOfRolePermission([FromRoute(Name = "role_id")] int id, RolePermission rolePermission)
        {
            return this.roleService.CollectionOfRolePermission(id, rolePermission, this.UserCredit).ToActionResult();
        }
    }
}