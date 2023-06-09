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
    public class VisionApprovedController : BaseController
    {
        public VisionApprovedController(IVisionApprovedService visionApprovedService)
        {
            this.visionApprovedService = visionApprovedService;
        }

        private IVisionApprovedService visionApprovedService { get; set; }

        [HttpGet]
        [Route("VisionApproved/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.visionApprovedService.RetrieveById(id, VisionApproved.Informer, this.UserCredit);

			return result.ToActionResult<VisionApproved>();
        }

        [HttpPost]
        [Route("VisionApproved/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.visionApprovedService.RetrieveAll(VisionApproved.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<VisionApproved>();
        }
            

        
        [HttpPost]
        [Route("VisionApproved/Save")]
        public async Task<IActionResult> Save([FromBody] VisionApproved visionApproved)
        {
            var result = await this.visionApprovedService.Save(visionApproved, this.UserCredit);

			return result.ToActionResult<VisionApproved>();
        }

        
        [HttpPost]
        [Route("VisionApproved/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] VisionApproved visionApproved)
        {
            var result = await this.visionApprovedService.SaveAttached(visionApproved, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("VisionApproved/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<VisionApproved> visionApprovedList)
        {
            var result = await this.visionApprovedService.SaveBulk(visionApprovedList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("VisionApproved/Seek")]
        public async Task<IActionResult> Seek([FromBody] VisionApproved visionApproved)
        {
            var result = await this.visionApprovedService.Seek(visionApproved, this.UserCredit);

			return result.ToActionResult<VisionApproved>();
        }

        [HttpGet]
        [Route("VisionApproved/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.visionApprovedService.SeekByValue(seekValue, VisionApproved.Informer, this.UserCredit);

			return result.ToActionResult<VisionApproved>();
        }

        [HttpPost]
        [Route("VisionApproved/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] VisionApproved visionApproved)
        {
            var result = await this.visionApprovedService.Delete(visionApproved, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}