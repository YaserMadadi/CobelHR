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
    public class AppraisalApproverConfigController : BaseController
    {
        public AppraisalApproverConfigController(IAppraisalApproverConfigService appraisalApproverConfigService)
        {
            this.appraisalApproverConfigService = appraisalApproverConfigService;
        }

        private IAppraisalApproverConfigService appraisalApproverConfigService { get; set; }

        [HttpGet]
        [Route("AppraisalApproverConfig/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.appraisalApproverConfigService.RetrieveById(id, AppraisalApproverConfig.Informer, this.UserCredit);

			return result.ToActionResult<AppraisalApproverConfig>();
        }

        [HttpPost]
        [Route("AppraisalApproverConfig/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.appraisalApproverConfigService.RetrieveAll(AppraisalApproverConfig.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AppraisalApproverConfig>();
        }
            

        
        [HttpPost]
        [Route("AppraisalApproverConfig/Save")]
        public async Task<IActionResult> Save([FromBody] AppraisalApproverConfig appraisalApproverConfig)
        {
            var result = await this.appraisalApproverConfigService.Save(appraisalApproverConfig, this.UserCredit);

			return result.ToActionResult<AppraisalApproverConfig>();
        }

        
        [HttpPost]
        [Route("AppraisalApproverConfig/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AppraisalApproverConfig appraisalApproverConfig)
        {
            var result = await this.appraisalApproverConfigService.SaveAttached(appraisalApproverConfig, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AppraisalApproverConfig/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AppraisalApproverConfig> appraisalApproverConfigList)
        {
            var result = await this.appraisalApproverConfigService.SaveBulk(appraisalApproverConfigList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AppraisalApproverConfig/Seek")]
        public async Task<IActionResult> Seek([FromBody] AppraisalApproverConfig appraisalApproverConfig)
        {
            var result = await this.appraisalApproverConfigService.Seek(appraisalApproverConfig, this.UserCredit);

			return result.ToActionResult<AppraisalApproverConfig>();
        }

        [HttpGet]
        [Route("AppraisalApproverConfig/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.appraisalApproverConfigService.SeekByValue(seekValue, AppraisalApproverConfig.Informer, this.UserCredit);

			return result.ToActionResult<AppraisalApproverConfig>();
        }

        [HttpPost]
        [Route("AppraisalApproverConfig/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AppraisalApproverConfig appraisalApproverConfig)
        {
            var result = await this.appraisalApproverConfigService.Delete(appraisalApproverConfig, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}