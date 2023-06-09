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
    public class BadgeController : BaseController
    {
        public BadgeController(IBadgeService badgeService)
        {
            this.badgeService = badgeService;
        }

        private IBadgeService badgeService { get; set; }

        [HttpGet]
        [Route("Badge/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.badgeService.RetrieveById(id, Badge.Informer, this.UserCredit);

			return result.ToActionResult<Badge>();
        }

        [HttpPost]
        [Route("Badge/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.badgeService.RetrieveAll(Badge.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Badge>();
        }
            

        
        [HttpPost]
        [Route("Badge/Save")]
        public async Task<IActionResult> Save([FromBody] Badge badge)
        {
            var result = await this.badgeService.Save(badge, this.UserCredit);

			return result.ToActionResult<Badge>();
        }

        
        [HttpPost]
        [Route("Badge/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Badge badge)
        {
            var result = await this.badgeService.SaveAttached(badge, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Badge/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Badge> badgeList)
        {
            var result = await this.badgeService.SaveBulk(badgeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Badge/Seek")]
        public async Task<IActionResult> Seek([FromBody] Badge badge)
        {
            var result = await this.badgeService.Seek(badge, this.UserCredit);

			return result.ToActionResult<Badge>();
        }

        [HttpGet]
        [Route("Badge/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.badgeService.SeekByValue(seekValue, Badge.Informer, this.UserCredit);

			return result.ToActionResult<Badge>();
        }

        [HttpPost]
        [Route("Badge/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Badge badge)
        {
            var result = await this.badgeService.Delete(badge, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}