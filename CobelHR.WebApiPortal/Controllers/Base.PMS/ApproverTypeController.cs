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
    public class ApproverTypeController : BaseController
    {
        public ApproverTypeController(IApproverTypeService approverTypeService)
        {
            this.approverTypeService = approverTypeService;
        }

        private IApproverTypeService approverTypeService { get; set; }

        [HttpGet]
        [Route("ApproverType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.approverTypeService.RetrieveById(id, ApproverType.Informer, this.UserCredit);

			return result.ToActionResult<ApproverType>();
        }

        [HttpPost]
        [Route("ApproverType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.approverTypeService.RetrieveAll(ApproverType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ApproverType>();
        }
            

        
        [HttpPost]
        [Route("ApproverType/Save")]
        public async Task<IActionResult> Save([FromBody] ApproverType approverType)
        {
            var result = await this.approverTypeService.Save(approverType, this.UserCredit);

			return result.ToActionResult<ApproverType>();
        }

        
        [HttpPost]
        [Route("ApproverType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ApproverType approverType)
        {
            var result = await this.approverTypeService.SaveAttached(approverType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ApproverType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ApproverType> approverTypeList)
        {
            var result = await this.approverTypeService.SaveBulk(approverTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ApproverType/Seek")]
        public async Task<IActionResult> Seek([FromBody] ApproverType approverType)
        {
            var result = await this.approverTypeService.Seek(approverType, this.UserCredit);

			return result.ToActionResult<ApproverType>();
        }

        [HttpGet]
        [Route("ApproverType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.approverTypeService.SeekByValue(seekValue, ApproverType.Informer, this.UserCredit);

			return result.ToActionResult<ApproverType>();
        }

        [HttpPost]
        [Route("ApproverType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ApproverType approverType)
        {
            var result = await this.approverTypeService.Delete(approverType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAppraisalApproverConfig
        [HttpPost]
        [Route("ApproverType/{approverType_id:int}/AppraisalApproverConfig")]
        public IActionResult CollectionOfAppraisalApproverConfig([FromRoute(Name = "approverType_id")] int id, AppraisalApproverConfig appraisalApproverConfig)
        {
            return this.approverTypeService.CollectionOfAppraisalApproverConfig(id, appraisalApproverConfig, this.UserCredit).ToActionResult();
        }
    }
}