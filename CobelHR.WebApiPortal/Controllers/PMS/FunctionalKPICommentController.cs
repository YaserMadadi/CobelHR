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
    public class FunctionalKPICommentController : BaseController
    {
        public FunctionalKPICommentController(IFunctionalKPICommentService functionalKPICommentService)
        {
            this.functionalKPICommentService = functionalKPICommentService;
        }

        private IFunctionalKPICommentService functionalKPICommentService { get; set; }

        [HttpGet]
        [Route("FunctionalKPIComment/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.functionalKPICommentService.RetrieveById(id, FunctionalKPIComment.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalKPIComment>();
        }

        [HttpPost]
        [Route("FunctionalKPIComment/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.functionalKPICommentService.RetrieveAll(FunctionalKPIComment.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<FunctionalKPIComment>();
        }
            

        
        [HttpPost]
        [Route("FunctionalKPIComment/Save")]
        public async Task<IActionResult> Save([FromBody] FunctionalKPIComment functionalKPIComment)
        {
            var result = await this.functionalKPICommentService.Save(functionalKPIComment, this.UserCredit);

			return result.ToActionResult<FunctionalKPIComment>();
        }

        
        [HttpPost]
        [Route("FunctionalKPIComment/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] FunctionalKPIComment functionalKPIComment)
        {
            var result = await this.functionalKPICommentService.SaveAttached(functionalKPIComment, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalKPIComment/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<FunctionalKPIComment> functionalKPICommentList)
        {
            var result = await this.functionalKPICommentService.SaveBulk(functionalKPICommentList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalKPIComment/Seek")]
        public async Task<IActionResult> Seek([FromBody] FunctionalKPIComment functionalKPIComment)
        {
            var result = await this.functionalKPICommentService.Seek(functionalKPIComment, this.UserCredit);

			return result.ToActionResult<FunctionalKPIComment>();
        }

        [HttpGet]
        [Route("FunctionalKPIComment/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.functionalKPICommentService.SeekByValue(seekValue, FunctionalKPIComment.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalKPIComment>();
        }

        [HttpPost]
        [Route("FunctionalKPIComment/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalKPIComment functionalKPIComment)
        {
            var result = await this.functionalKPICommentService.Delete(functionalKPIComment, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}