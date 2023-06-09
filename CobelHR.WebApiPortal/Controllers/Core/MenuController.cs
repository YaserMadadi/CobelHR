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
    public class MenuController : BaseController
    {
        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        private IMenuService menuService { get; set; }

        [HttpGet]
        [Route("Menu/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.menuService.RetrieveById(id, Menu.Informer, this.UserCredit);

			return result.ToActionResult<Menu>();
        }

        [HttpPost]
        [Route("Menu/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage = 1)
        {
            var result = await this.menuService.RetrieveAll(Menu.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Menu>();
        }
            

        
        [HttpPost]
        [Route("Menu/Save")]
        public async Task<IActionResult> Save([FromBody] Menu menu)
        {
            var result = await this.menuService.Save(menu, this.UserCredit);

			return result.ToActionResult<Menu>();
        }

        
        [HttpPost]
        [Route("Menu/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Menu menu)
        {
            var result = await this.menuService.SaveAttached(menu, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Menu/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Menu> menuList)
        {
            var result = await this.menuService.SaveBulk(menuList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Menu/Seek")]
        public async Task<IActionResult> Seek([FromBody] Menu menu)
        {
            var result = await this.menuService.Seek(menu, this.UserCredit);

			return result.ToActionResult<Menu>();
        }

        [HttpGet]
        [Route("Menu/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.menuService.SeekByValue(seekValue, Menu.Informer, this.UserCredit);

			return result.ToActionResult<Menu>();
        }

        [HttpPost]
        [Route("Menu/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Menu menu)
        {
            var result = await this.menuService.Delete(menu, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfMenuItem
        [HttpPost]
        [Route("Menu/{menu_id:int}/MenuItem")]
        public IActionResult CollectionOfMenuItem([FromRoute(Name = "menu_id")] int id, MenuItem menuItem)
        {
            return this.menuService.CollectionOfMenuItem(id, menuItem, this.UserCredit).ToActionResult();
        }
    }
}