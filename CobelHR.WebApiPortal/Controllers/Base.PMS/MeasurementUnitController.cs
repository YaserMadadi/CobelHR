using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class MeasurementUnitController : BaseController
    {
        public MeasurementUnitController(IMeasurementUnitService measurementUnitService)
        {
            this.measurementUnitService = measurementUnitService;
        }

        private IMeasurementUnitService measurementUnitService { get; set; }

        [HttpGet]
        [Route("MeasurementUnit/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.measurementUnitService.RetrieveById(id, MeasurementUnit.Informer, this.UserCredit);

			return result.ToActionResult<MeasurementUnit>();
        }

        [HttpPost]
        [Route("MeasurementUnit/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.measurementUnitService.RetrieveAll(MeasurementUnit.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<MeasurementUnit>();
        }
            

        
        [HttpPost]
        [Route("MeasurementUnit/Save")]
        public async Task<IActionResult> Save([FromBody] MeasurementUnit measurementUnit)
        {
            var result = await this.measurementUnitService.Save(measurementUnit, this.UserCredit);

			return result.ToActionResult<MeasurementUnit>();
        }

        
        [HttpPost]
        [Route("MeasurementUnit/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] MeasurementUnit measurementUnit)
        {
            var result = await this.measurementUnitService.SaveAttached(measurementUnit, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("MeasurementUnit/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<MeasurementUnit> measurementUnitList)
        {
            var result = await this.measurementUnitService.SaveBulk(measurementUnitList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("MeasurementUnit/Seek")]
        public async Task<IActionResult> Seek([FromBody] MeasurementUnit measurementUnit)
        {
            var result = await this.measurementUnitService.Seek(measurementUnit, this.UserCredit);

			return result.ToActionResult<MeasurementUnit>();
        }

        [HttpGet]
        [Route("MeasurementUnit/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.measurementUnitService.SeekByValue(seekValue, MeasurementUnit.Informer, this.UserCredit);

			return result.ToActionResult<MeasurementUnit>();
        }

        [HttpPost]
        [Route("MeasurementUnit/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MeasurementUnit measurementUnit)
        {
            var result = await this.measurementUnitService.Delete(measurementUnit, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfFunctionalKPI
        [HttpPost]
        [Route("MeasurementUnit/{measurementUnit_id:int}/FunctionalKPI")]
        public IActionResult CollectionOfFunctionalKPI([FromRoute(Name = "measurementUnit_id")] int id, FunctionalKPI functionalKPI)
        {
            return this.measurementUnitService.CollectionOfFunctionalKPI(id, functionalKPI, this.UserCredit).ToActionResult();
        }
    }
}