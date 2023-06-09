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
    public class EntityController : BaseController
    {
        public EntityController(IEntityService entityService)
        {
            this.entityService = entityService;
        }

        private IEntityService entityService { get; set; }

        [HttpGet]
        [Route("Entity/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.entityService.RetrieveById(id, Entity.Informer, this.UserCredit);

			return result.ToActionResult<Entity>();
        }

        [HttpPost]
        [Route("Entity/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.entityService.RetrieveAll(Entity.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Entity>();
        }
            

        
        [HttpPost]
        [Route("Entity/Save")]
        public async Task<IActionResult> Save([FromBody] Entity entity)
        {
            var result = await this.entityService.Save(entity, this.UserCredit);

			return result.ToActionResult<Entity>();
        }

        
        [HttpPost]
        [Route("Entity/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Entity entity)
        {
            var result = await this.entityService.SaveAttached(entity, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Entity/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Entity> entityList)
        {
            var result = await this.entityService.SaveBulk(entityList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Entity/Seek")]
        public async Task<IActionResult> Seek([FromBody] Entity entity)
        {
            var result = await this.entityService.Seek(entity, this.UserCredit);

			return result.ToActionResult<Entity>();
        }

        [HttpGet]
        [Route("Entity/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.entityService.SeekByValue(seekValue, Entity.Informer, this.UserCredit);

			return result.ToActionResult<Entity>();
        }

        [HttpPost]
        [Route("Entity/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Entity entity)
        {
            var result = await this.entityService.Delete(entity, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfProperty
        [HttpPost]
        [Route("Entity/{entity_id:int}/Property")]
        public IActionResult CollectionOfProperty([FromRoute(Name = "entity_id")] int id, Property property)
        {
            return this.entityService.CollectionOfProperty(id, property, this.UserCredit).ToActionResult();
        }

		// CollectionOfRolePermission
        [HttpPost]
        [Route("Entity/{entity_id:int}/RolePermission")]
        public IActionResult CollectionOfRolePermission([FromRoute(Name = "entity_id")] int id, RolePermission rolePermission)
        {
            return this.entityService.CollectionOfRolePermission(id, rolePermission, this.UserCredit).ToActionResult();
        }
    }
}