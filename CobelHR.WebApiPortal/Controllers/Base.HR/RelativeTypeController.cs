using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class RelativeTypeController : BaseController
    {
        public RelativeTypeController(IRelativeTypeService relativeTypeService)
        {
            this.relativeTypeService = relativeTypeService;
        }

        private IRelativeTypeService relativeTypeService { get; set; }

        [HttpGet]
        [Route("RelativeType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.relativeTypeService.RetrieveById(id, RelativeType.Informer, this.UserCredit);

			return result.ToActionResult<RelativeType>();
        }

        [HttpPost]
        [Route("RelativeType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.relativeTypeService.RetrieveAll(RelativeType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<RelativeType>();
        }
            

        
        [HttpPost]
        [Route("RelativeType/Save")]
        public async Task<IActionResult> Save([FromBody] RelativeType relativeType)
        {
            var result = await this.relativeTypeService.Save(relativeType, this.UserCredit);

			return result.ToActionResult<RelativeType>();
        }

        
        [HttpPost]
        [Route("RelativeType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] RelativeType relativeType)
        {
            var result = await this.relativeTypeService.SaveAttached(relativeType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("RelativeType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<RelativeType> relativeTypeList)
        {
            var result = await this.relativeTypeService.SaveBulk(relativeTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("RelativeType/Seek")]
        public async Task<IActionResult> Seek([FromBody] RelativeType relativeType)
        {
            var result = await this.relativeTypeService.Seek(relativeType, this.UserCredit);

			return result.ToActionResult<RelativeType>();
        }

        [HttpGet]
        [Route("RelativeType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.relativeTypeService.SeekByValue(seekValue, RelativeType.Informer, this.UserCredit);

			return result.ToActionResult<RelativeType>();
        }

        [HttpPost]
        [Route("RelativeType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] RelativeType relativeType)
        {
            var result = await this.relativeTypeService.Delete(relativeType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfRelative_RelationType
        [HttpPost]
        [Route("RelationType/{relativeType_id:int}/Relative")]
        public IActionResult CollectionOfRelative_RelationType([FromRoute(Name = "relativeType_id")] int id, Relative relative)
        {
            return this.relativeTypeService.CollectionOfRelative_RelationType(id, relative, this.UserCredit).ToActionResult();
        }
    }
}