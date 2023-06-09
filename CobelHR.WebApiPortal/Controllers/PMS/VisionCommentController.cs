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
    public class VisionCommentController : BaseController
    {
        public VisionCommentController(IVisionCommentService visionCommentService)
        {
            this.visionCommentService = visionCommentService;
        }

        private IVisionCommentService visionCommentService { get; set; }

        [HttpGet]
        [Route("VisionComment/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.visionCommentService.RetrieveById(id, VisionComment.Informer, this.UserCredit);

			return result.ToActionResult<VisionComment>();
        }

        [HttpPost]
        [Route("VisionComment/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.visionCommentService.RetrieveAll(VisionComment.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<VisionComment>();
        }
            

        
        [HttpPost]
        [Route("VisionComment/Save")]
        public async Task<IActionResult> Save([FromBody] VisionComment visionComment)
        {
            var result = await this.visionCommentService.Save(visionComment, this.UserCredit);

			return result.ToActionResult<VisionComment>();
        }

        
        [HttpPost]
        [Route("VisionComment/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] VisionComment visionComment)
        {
            var result = await this.visionCommentService.SaveAttached(visionComment, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("VisionComment/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<VisionComment> visionCommentList)
        {
            var result = await this.visionCommentService.SaveBulk(visionCommentList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("VisionComment/Seek")]
        public async Task<IActionResult> Seek([FromBody] VisionComment visionComment)
        {
            var result = await this.visionCommentService.Seek(visionComment, this.UserCredit);

			return result.ToActionResult<VisionComment>();
        }

        [HttpGet]
        [Route("VisionComment/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.visionCommentService.SeekByValue(seekValue, VisionComment.Informer, this.UserCredit);

			return result.ToActionResult<VisionComment>();
        }

        [HttpPost]
        [Route("VisionComment/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] VisionComment visionComment)
        {
            var result = await this.visionCommentService.Delete(visionComment, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}