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
    public class BehavioralAppraiseController : BaseController
    {
        public BehavioralAppraiseController(IBehavioralAppraiseService behavioralAppraiseService)
        {
            this.behavioralAppraiseService = behavioralAppraiseService;
        }

        private IBehavioralAppraiseService behavioralAppraiseService { get; set; }

        [HttpGet]
        [Route("BehavioralAppraise/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.behavioralAppraiseService.RetrieveById(id, BehavioralAppraise.Informer, this.UserCredit);

			return result.ToActionResult<BehavioralAppraise>();
        }

        [HttpPost]
        [Route("BehavioralAppraise/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.behavioralAppraiseService.RetrieveAll(BehavioralAppraise.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<BehavioralAppraise>();
        }
            

        
        [HttpPost]
        [Route("BehavioralAppraise/Save")]
        public async Task<IActionResult> Save([FromBody] BehavioralAppraise behavioralAppraise)
        {
            var result = await this.behavioralAppraiseService.Save(behavioralAppraise, this.UserCredit);

			return result.ToActionResult<BehavioralAppraise>();
        }

        
        [HttpPost]
        [Route("BehavioralAppraise/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] BehavioralAppraise behavioralAppraise)
        {
            var result = await this.behavioralAppraiseService.SaveAttached(behavioralAppraise, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("BehavioralAppraise/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<BehavioralAppraise> behavioralAppraiseList)
        {
            var result = await this.behavioralAppraiseService.SaveBulk(behavioralAppraiseList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("BehavioralAppraise/Seek")]
        public async Task<IActionResult> Seek([FromBody] BehavioralAppraise behavioralAppraise)
        {
            var result = await this.behavioralAppraiseService.Seek(behavioralAppraise, this.UserCredit);

			return result.ToActionResult<BehavioralAppraise>();
        }

        [HttpGet]
        [Route("BehavioralAppraise/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.behavioralAppraiseService.SeekByValue(seekValue, BehavioralAppraise.Informer, this.UserCredit);

			return result.ToActionResult<BehavioralAppraise>();
        }

        [HttpPost]
        [Route("BehavioralAppraise/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] BehavioralAppraise behavioralAppraise)
        {
            var result = await this.behavioralAppraiseService.Delete(behavioralAppraise, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}