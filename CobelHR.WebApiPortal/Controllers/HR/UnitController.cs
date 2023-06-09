using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class UnitController : BaseController
    {
        public UnitController(IUnitService unitService)
        {
            this.unitService = unitService;
        }

        private IUnitService unitService { get; set; }

        [HttpGet]
        [Route("Unit/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.unitService.RetrieveById(id, Unit.Informer, this.UserCredit);

			return result.ToActionResult<Unit>();
        }

        [HttpPost]
        [Route("Unit/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.unitService.RetrieveAll(Unit.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Unit>();
        }
            

        
        [HttpPost]
        [Route("Unit/Save")]
        public async Task<IActionResult> Save([FromBody] Unit unit)
        {
            var result = await this.unitService.Save(unit, this.UserCredit);

			return result.ToActionResult<Unit>();
        }

        
        [HttpPost]
        [Route("Unit/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Unit unit)
        {
            var result = await this.unitService.SaveAttached(unit, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Unit/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Unit> unitList)
        {
            var result = await this.unitService.SaveBulk(unitList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Unit/Seek")]
        public async Task<IActionResult> Seek([FromBody] Unit unit)
        {
            var result = await this.unitService.Seek(unit, this.UserCredit);

			return result.ToActionResult<Unit>();
        }

        [HttpGet]
        [Route("Unit/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.unitService.SeekByValue(seekValue, Unit.Informer, this.UserCredit);

			return result.ToActionResult<Unit>();
        }

        [HttpPost]
        [Route("Unit/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Unit unit)
        {
            var result = await this.unitService.Delete(unit, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPosition
        [HttpPost]
        [Route("Unit/{unit_id:int}/Position")]
        public IActionResult CollectionOfPosition([FromRoute(Name = "unit_id")] int id, Position position)
        {
            return this.unitService.CollectionOfPosition(id, position, this.UserCredit).ToActionResult();
        }
    }
}