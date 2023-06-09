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
    public class BadgeTypeController : BaseController
    {
        public BadgeTypeController(IBadgeTypeService badgeTypeService)
        {
            this.badgeTypeService = badgeTypeService;
        }

        private IBadgeTypeService badgeTypeService { get; set; }

        [HttpGet]
        [Route("BadgeType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.badgeTypeService.RetrieveById(id, BadgeType.Informer, this.UserCredit);

			return result.ToActionResult<BadgeType>();
        }

        [HttpPost]
        [Route("BadgeType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.badgeTypeService.RetrieveAll(BadgeType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<BadgeType>();
        }
            

        
        [HttpPost]
        [Route("BadgeType/Save")]
        public async Task<IActionResult> Save([FromBody] BadgeType badgeType)
        {
            var result = await this.badgeTypeService.Save(badgeType, this.UserCredit);

			return result.ToActionResult<BadgeType>();
        }

        
        [HttpPost]
        [Route("BadgeType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] BadgeType badgeType)
        {
            var result = await this.badgeTypeService.SaveAttached(badgeType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("BadgeType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<BadgeType> badgeTypeList)
        {
            var result = await this.badgeTypeService.SaveBulk(badgeTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("BadgeType/Seek")]
        public async Task<IActionResult> Seek([FromBody] BadgeType badgeType)
        {
            var result = await this.badgeTypeService.Seek(badgeType, this.UserCredit);

			return result.ToActionResult<BadgeType>();
        }

        [HttpGet]
        [Route("BadgeType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.badgeTypeService.SeekByValue(seekValue, BadgeType.Informer, this.UserCredit);

			return result.ToActionResult<BadgeType>();
        }

        [HttpPost]
        [Route("BadgeType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] BadgeType badgeType)
        {
            var result = await this.badgeTypeService.Delete(badgeType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfBadge
        [HttpPost]
        [Route("BadgeType/{badgeType_id:int}/Badge")]
        public IActionResult CollectionOfBadge([FromRoute(Name = "badgeType_id")] int id, Badge badge)
        {
            return this.badgeTypeService.CollectionOfBadge(id, badge, this.UserCredit).ToActionResult();
        }
    }
}