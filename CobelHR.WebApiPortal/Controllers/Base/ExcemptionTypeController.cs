using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class ExcemptionTypeController : BaseController
    {
        public ExcemptionTypeController(IExcemptionTypeService excemptionTypeService)
        {
            this.excemptionTypeService = excemptionTypeService;
        }

        private IExcemptionTypeService excemptionTypeService { get; set; }

        [HttpGet]
        [Route("ExcemptionType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.excemptionTypeService.RetrieveById(id, ExcemptionType.Informer, this.UserCredit);

			return result.ToActionResult<ExcemptionType>();
        }

        [HttpPost]
        [Route("ExcemptionType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.excemptionTypeService.RetrieveAll(ExcemptionType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ExcemptionType>();
        }
            

        
        [HttpPost]
        [Route("ExcemptionType/Save")]
        public async Task<IActionResult> Save([FromBody] ExcemptionType excemptionType)
        {
            var result = await this.excemptionTypeService.Save(excemptionType, this.UserCredit);

			return result.ToActionResult<ExcemptionType>();
        }

        
        [HttpPost]
        [Route("ExcemptionType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ExcemptionType excemptionType)
        {
            var result = await this.excemptionTypeService.SaveAttached(excemptionType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ExcemptionType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ExcemptionType> excemptionTypeList)
        {
            var result = await this.excemptionTypeService.SaveBulk(excemptionTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ExcemptionType/Seek")]
        public async Task<IActionResult> Seek([FromBody] ExcemptionType excemptionType)
        {
            var result = await this.excemptionTypeService.Seek(excemptionType, this.UserCredit);

			return result.ToActionResult<ExcemptionType>();
        }

        [HttpGet]
        [Route("ExcemptionType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.excemptionTypeService.SeekByValue(seekValue, ExcemptionType.Informer, this.UserCredit);

			return result.ToActionResult<ExcemptionType>();
        }

        [HttpPost]
        [Route("ExcemptionType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ExcemptionType excemptionType)
        {
            var result = await this.excemptionTypeService.Delete(excemptionType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfMilitaryServiceExcemption
        [HttpPost]
        [Route("ExcemptionType/{excemptionType_id:int}/MilitaryServiceExcemption")]
        public IActionResult CollectionOfMilitaryServiceExcemption([FromRoute(Name = "excemptionType_id")] int id, MilitaryServiceExcemption militaryServiceExcemption)
        {
            return this.excemptionTypeService.CollectionOfMilitaryServiceExcemption(id, militaryServiceExcemption, this.UserCredit).ToActionResult();
        }
    }
}