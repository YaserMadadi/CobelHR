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
    public class SubSystemController : BaseController
    {
        public SubSystemController(ISubSystemService subSystemService)
        {
            this.subSystemService = subSystemService;
        }

        private ISubSystemService subSystemService { get; set; }

        [HttpGet]
        [Route("SubSystem/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.subSystemService.RetrieveById(id, SubSystem.Informer, this.UserCredit);

			return result.ToActionResult<SubSystem>();
        }

        [HttpPost]
        [Route("SubSystem/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.subSystemService.RetrieveAll(SubSystem.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<SubSystem>();
        }
            

        
        [HttpPost]
        [Route("SubSystem/Save")]
        public async Task<IActionResult> Save([FromBody] SubSystem subSystem)
        {
            var result = await this.subSystemService.Save(subSystem, this.UserCredit);

			return result.ToActionResult<SubSystem>();
        }

        
        [HttpPost]
        [Route("SubSystem/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] SubSystem subSystem)
        {
            var result = await this.subSystemService.SaveAttached(subSystem, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("SubSystem/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<SubSystem> subSystemList)
        {
            var result = await this.subSystemService.SaveBulk(subSystemList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("SubSystem/Seek")]
        public async Task<IActionResult> Seek([FromBody] SubSystem subSystem)
        {
            var result = await this.subSystemService.Seek(subSystem, this.UserCredit);

			return result.ToActionResult<SubSystem>();
        }

        [HttpGet]
        [Route("SubSystem/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.subSystemService.SeekByValue(seekValue, SubSystem.Informer, this.UserCredit);

			return result.ToActionResult<SubSystem>();
        }

        [HttpPost]
        [Route("SubSystem/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] SubSystem subSystem)
        {
            var result = await this.subSystemService.Delete(subSystem, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfMenu
        [HttpPost]
        [Route("SubSystem/{subSystem_id:int}/Menu")]
        public IActionResult CollectionOfMenu([FromRoute(Name = "subSystem_id")] int id, Menu menu)
        {
            return this.subSystemService.CollectionOfMenu(id, menu, this.UserCredit).ToActionResult();
        }
    }
}