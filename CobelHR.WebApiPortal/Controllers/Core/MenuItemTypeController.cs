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
    public class MenuItemTypeController : BaseController
    {
        public MenuItemTypeController(IMenuItemTypeService menuItemTypeService)
        {
            this.menuItemTypeService = menuItemTypeService;
        }

        private IMenuItemTypeService menuItemTypeService { get; set; }

        [HttpGet]
        [Route("MenuItemType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.menuItemTypeService.RetrieveById(id, MenuItemType.Informer, this.UserCredit);

			return result.ToActionResult<MenuItemType>();
        }

        [HttpPost]
        [Route("MenuItemType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.menuItemTypeService.RetrieveAll(MenuItemType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<MenuItemType>();
        }
            

        
        [HttpPost]
        [Route("MenuItemType/Save")]
        public async Task<IActionResult> Save([FromBody] MenuItemType menuItemType)
        {
            var result = await this.menuItemTypeService.Save(menuItemType, this.UserCredit);

			return result.ToActionResult<MenuItemType>();
        }

        
        [HttpPost]
        [Route("MenuItemType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] MenuItemType menuItemType)
        {
            var result = await this.menuItemTypeService.SaveAttached(menuItemType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("MenuItemType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<MenuItemType> menuItemTypeList)
        {
            var result = await this.menuItemTypeService.SaveBulk(menuItemTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("MenuItemType/Seek")]
        public async Task<IActionResult> Seek([FromBody] MenuItemType menuItemType)
        {
            var result = await this.menuItemTypeService.Seek(menuItemType, this.UserCredit);

			return result.ToActionResult<MenuItemType>();
        }

        [HttpGet]
        [Route("MenuItemType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.menuItemTypeService.SeekByValue(seekValue, MenuItemType.Informer, this.UserCredit);

			return result.ToActionResult<MenuItemType>();
        }

        [HttpPost]
        [Route("MenuItemType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MenuItemType menuItemType)
        {
            var result = await this.menuItemTypeService.Delete(menuItemType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfMenuItem
        [HttpPost]
        [Route("MenuItemType/{menuItemType_id:int}/MenuItem")]
        public IActionResult CollectionOfMenuItem([FromRoute(Name = "menuItemType_id")] int id, MenuItem menuItem)
        {
            return this.menuItemTypeService.CollectionOfMenuItem(id, menuItem, this.UserCredit).ToActionResult();
        }
    }
}