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
    public class FunctionalAppraiseController : BaseController
    {
        public FunctionalAppraiseController(IFunctionalAppraiseService functionalAppraiseService)
        {
            this.functionalAppraiseService = functionalAppraiseService;
        }

        private IFunctionalAppraiseService functionalAppraiseService { get; set; }

        [HttpGet]
        [Route("FunctionalAppraise/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.functionalAppraiseService.RetrieveById(id, FunctionalAppraise.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalAppraise>();
        }

        [HttpPost]
        [Route("FunctionalAppraise/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.functionalAppraiseService.RetrieveAll(FunctionalAppraise.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<FunctionalAppraise>();
        }
            

        
        [HttpPost]
        [Route("FunctionalAppraise/Save")]
        public async Task<IActionResult> Save([FromBody] FunctionalAppraise functionalAppraise)
        {
            var result = await this.functionalAppraiseService.Save(functionalAppraise, this.UserCredit);

			return result.ToActionResult<FunctionalAppraise>();
        }

        
        [HttpPost]
        [Route("FunctionalAppraise/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] FunctionalAppraise functionalAppraise)
        {
            var result = await this.functionalAppraiseService.SaveAttached(functionalAppraise, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalAppraise/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<FunctionalAppraise> functionalAppraiseList)
        {
            var result = await this.functionalAppraiseService.SaveBulk(functionalAppraiseList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalAppraise/Seek")]
        public async Task<IActionResult> Seek([FromBody] FunctionalAppraise functionalAppraise)
        {
            var result = await this.functionalAppraiseService.Seek(functionalAppraise, this.UserCredit);

			return result.ToActionResult<FunctionalAppraise>();
        }

        [HttpGet]
        [Route("FunctionalAppraise/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.functionalAppraiseService.SeekByValue(seekValue, FunctionalAppraise.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalAppraise>();
        }

        [HttpPost]
        [Route("FunctionalAppraise/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalAppraise functionalAppraise)
        {
            var result = await this.functionalAppraiseService.Delete(functionalAppraise, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}