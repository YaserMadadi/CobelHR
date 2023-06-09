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
    public class InclusiveTypeController : BaseController
    {
        public InclusiveTypeController(IInclusiveTypeService inclusiveTypeService)
        {
            this.inclusiveTypeService = inclusiveTypeService;
        }

        private IInclusiveTypeService inclusiveTypeService { get; set; }

        [HttpGet]
        [Route("InclusiveType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.inclusiveTypeService.RetrieveById(id, InclusiveType.Informer, this.UserCredit);

			return result.ToActionResult<InclusiveType>();
        }

        [HttpPost]
        [Route("InclusiveType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.inclusiveTypeService.RetrieveAll(InclusiveType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<InclusiveType>();
        }
            

        
        [HttpPost]
        [Route("InclusiveType/Save")]
        public async Task<IActionResult> Save([FromBody] InclusiveType inclusiveType)
        {
            var result = await this.inclusiveTypeService.Save(inclusiveType, this.UserCredit);

			return result.ToActionResult<InclusiveType>();
        }

        
        [HttpPost]
        [Route("InclusiveType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] InclusiveType inclusiveType)
        {
            var result = await this.inclusiveTypeService.SaveAttached(inclusiveType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("InclusiveType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<InclusiveType> inclusiveTypeList)
        {
            var result = await this.inclusiveTypeService.SaveBulk(inclusiveTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("InclusiveType/Seek")]
        public async Task<IActionResult> Seek([FromBody] InclusiveType inclusiveType)
        {
            var result = await this.inclusiveTypeService.Seek(inclusiveType, this.UserCredit);

			return result.ToActionResult<InclusiveType>();
        }

        [HttpGet]
        [Route("InclusiveType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.inclusiveTypeService.SeekByValue(seekValue, InclusiveType.Informer, this.UserCredit);

			return result.ToActionResult<InclusiveType>();
        }

        [HttpPost]
        [Route("InclusiveType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] InclusiveType inclusiveType)
        {
            var result = await this.inclusiveTypeService.Delete(inclusiveType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfMilitaryServiceInclusive
        [HttpPost]
        [Route("InclusiveType/{inclusiveType_id:int}/MilitaryServiceInclusive")]
        public IActionResult CollectionOfMilitaryServiceInclusive([FromRoute(Name = "inclusiveType_id")] int id, MilitaryServiceInclusive militaryServiceInclusive)
        {
            return this.inclusiveTypeService.CollectionOfMilitaryServiceInclusive(id, militaryServiceInclusive, this.UserCredit).ToActionResult();
        }
    }
}