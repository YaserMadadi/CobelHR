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
    public class VisionController : BaseController
    {
        public VisionController(IVisionService visionService)
        {
            this.visionService = visionService;
        }

        private IVisionService visionService { get; set; }

        [HttpGet]
        [Route("Vision/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.visionService.RetrieveById(id, Vision.Informer, this.UserCredit);

			return result.ToActionResult<Vision>();
        }

        [HttpPost]
        [Route("Vision/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.visionService.RetrieveAll(Vision.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Vision>();
        }
            

        
        [HttpPost]
        [Route("Vision/Save")]
        public async Task<IActionResult> Save([FromBody] Vision vision)
        {
            var result = await this.visionService.Save(vision, this.UserCredit);

			return result.ToActionResult<Vision>();
        }

        
        [HttpPost]
        [Route("Vision/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Vision vision)
        {
            var result = await this.visionService.SaveAttached(vision, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Vision/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Vision> visionList)
        {
            var result = await this.visionService.SaveBulk(visionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Vision/Seek")]
        public async Task<IActionResult> Seek([FromBody] Vision vision)
        {
            var result = await this.visionService.Seek(vision, this.UserCredit);

			return result.ToActionResult<Vision>();
        }

        [HttpGet]
        [Route("Vision/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.visionService.SeekByValue(seekValue, Vision.Informer, this.UserCredit);

			return result.ToActionResult<Vision>();
        }

        [HttpPost]
        [Route("Vision/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Vision vision)
        {
            var result = await this.visionService.Delete(vision, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan
        [HttpPost]
        [Route("Vision/{vision_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "vision_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.visionService.CollectionOfIndividualDevelopmentPlan(id, individualDevelopmentPlan, this.UserCredit).ToActionResult();
        }

		// CollectionOfVisionApproved
        [HttpPost]
        [Route("Vision/{vision_id:int}/VisionApproved")]
        public IActionResult CollectionOfVisionApproved([FromRoute(Name = "vision_id")] int id, VisionApproved visionApproved)
        {
            return this.visionService.CollectionOfVisionApproved(id, visionApproved, this.UserCredit).ToActionResult();
        }

		// CollectionOfVisionComment
        [HttpPost]
        [Route("Vision/{vision_id:int}/VisionComment")]
        public IActionResult CollectionOfVisionComment([FromRoute(Name = "vision_id")] int id, VisionComment visionComment)
        {
            return this.visionService.CollectionOfVisionComment(id, visionComment, this.UserCredit).ToActionResult();
        }
    }
}