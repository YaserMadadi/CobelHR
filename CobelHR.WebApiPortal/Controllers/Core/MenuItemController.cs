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
    public class MenuItemController : BaseController
    {
        public MenuItemController(IMenuItemService menuItemService)
        {
            this.menuItemService = menuItemService;
        }

        private IMenuItemService menuItemService { get; set; }

        [HttpGet]
        [Route("MenuItem/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.menuItemService.RetrieveById(id, MenuItem.Informer, this.UserCredit);

			return result.ToActionResult<MenuItem>();
        }

        [HttpPost]
        [Route("MenuItem/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.menuItemService.RetrieveAll(MenuItem.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<MenuItem>();
        }
            

        
        [HttpPost]
        [Route("MenuItem/Save")]
        public async Task<IActionResult> Save([FromBody] MenuItem menuItem)
        {
            var result = await this.menuItemService.Save(menuItem, this.UserCredit);

			return result.ToActionResult<MenuItem>();
        }

        
        [HttpPost]
        [Route("MenuItem/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] MenuItem menuItem)
        {
            var result = await this.menuItemService.SaveAttached(menuItem, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("MenuItem/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<MenuItem> menuItemList)
        {
            var result = await this.menuItemService.SaveBulk(menuItemList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("MenuItem/Seek")]
        public async Task<IActionResult> Seek([FromBody] MenuItem menuItem)
        {
            var result = await this.menuItemService.Seek(menuItem, this.UserCredit);

			return result.ToActionResult<MenuItem>();
        }

        [HttpGet]
        [Route("MenuItem/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.menuItemService.SeekByValue(seekValue, MenuItem.Informer, this.UserCredit);

			return result.ToActionResult<MenuItem>();
        }

        [HttpPost]
        [Route("MenuItem/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MenuItem menuItem)
        {
            var result = await this.menuItemService.Delete(menuItem, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfBadge
        [HttpPost]
        [Route("MenuItem/{menuItem_id:int}/Badge")]
        public IActionResult CollectionOfBadge([FromRoute(Name = "menuItem_id")] int id, Badge badge)
        {
            return this.menuItemService.CollectionOfBadge(id, badge, this.UserCredit).ToActionResult();
        }
    }
}