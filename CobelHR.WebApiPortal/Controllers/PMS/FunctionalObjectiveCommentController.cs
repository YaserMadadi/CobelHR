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
    public class FunctionalObjectiveCommentController : BaseController
    {
        public FunctionalObjectiveCommentController(IFunctionalObjectiveCommentService functionalObjectiveCommentService)
        {
            this.functionalObjectiveCommentService = functionalObjectiveCommentService;
        }

        private IFunctionalObjectiveCommentService functionalObjectiveCommentService { get; set; }

        [HttpGet]
        [Route("FunctionalObjectiveComment/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.functionalObjectiveCommentService.RetrieveById(id, FunctionalObjectiveComment.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalObjectiveComment>();
        }

        [HttpPost]
        [Route("FunctionalObjectiveComment/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.functionalObjectiveCommentService.RetrieveAll(FunctionalObjectiveComment.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<FunctionalObjectiveComment>();
        }
            

        
        [HttpPost]
        [Route("FunctionalObjectiveComment/Save")]
        public async Task<IActionResult> Save([FromBody] FunctionalObjectiveComment functionalObjectiveComment)
        {
            var result = await this.functionalObjectiveCommentService.Save(functionalObjectiveComment, this.UserCredit);

			return result.ToActionResult<FunctionalObjectiveComment>();
        }

        
        [HttpPost]
        [Route("FunctionalObjectiveComment/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] FunctionalObjectiveComment functionalObjectiveComment)
        {
            var result = await this.functionalObjectiveCommentService.SaveAttached(functionalObjectiveComment, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalObjectiveComment/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<FunctionalObjectiveComment> functionalObjectiveCommentList)
        {
            var result = await this.functionalObjectiveCommentService.SaveBulk(functionalObjectiveCommentList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalObjectiveComment/Seek")]
        public async Task<IActionResult> Seek([FromBody] FunctionalObjectiveComment functionalObjectiveComment)
        {
            var result = await this.functionalObjectiveCommentService.Seek(functionalObjectiveComment, this.UserCredit);

			return result.ToActionResult<FunctionalObjectiveComment>();
        }

        [HttpGet]
        [Route("FunctionalObjectiveComment/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.functionalObjectiveCommentService.SeekByValue(seekValue, FunctionalObjectiveComment.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalObjectiveComment>();
        }

        [HttpPost]
        [Route("FunctionalObjectiveComment/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalObjectiveComment functionalObjectiveComment)
        {
            var result = await this.functionalObjectiveCommentService.Delete(functionalObjectiveComment, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}