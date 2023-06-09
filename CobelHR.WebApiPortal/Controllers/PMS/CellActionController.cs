using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class CellActionController : BaseController
    {
        public CellActionController(ICellActionService cellActionService)
        {
            this.cellActionService = cellActionService;
        }

        private ICellActionService cellActionService { get; set; }

        [HttpGet]
        [Route("CellAction/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.cellActionService.RetrieveById(id, CellAction.Informer, this.UserCredit);

			return result.ToActionResult<CellAction>();
        }

        [HttpPost]
        [Route("CellAction/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.cellActionService.RetrieveAll(CellAction.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CellAction>();
        }
            

        
        [HttpPost]
        [Route("CellAction/Save")]
        public async Task<IActionResult> Save([FromBody] CellAction cellAction)
        {
            var result = await this.cellActionService.Save(cellAction, this.UserCredit);

			return result.ToActionResult<CellAction>();
        }

        
        [HttpPost]
        [Route("CellAction/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CellAction cellAction)
        {
            var result = await this.cellActionService.SaveAttached(cellAction, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CellAction/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CellAction> cellActionList)
        {
            var result = await this.cellActionService.SaveBulk(cellActionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CellAction/Seek")]
        public async Task<IActionResult> Seek([FromBody] CellAction cellAction)
        {
            var result = await this.cellActionService.Seek(cellAction, this.UserCredit);

			return result.ToActionResult<CellAction>();
        }

        [HttpGet]
        [Route("CellAction/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.cellActionService.SeekByValue(seekValue, CellAction.Informer, this.UserCredit);

			return result.ToActionResult<CellAction>();
        }

        [HttpPost]
        [Route("CellAction/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CellAction cellAction)
        {
            var result = await this.cellActionService.Delete(cellAction, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}