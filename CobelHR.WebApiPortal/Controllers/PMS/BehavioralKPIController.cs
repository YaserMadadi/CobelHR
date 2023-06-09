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
    public class BehavioralKPIController : BaseController
    {
        public BehavioralKPIController(IBehavioralKPIService behavioralKPIService)
        {
            this.behavioralKPIService = behavioralKPIService;
        }

        private IBehavioralKPIService behavioralKPIService { get; set; }

        [HttpGet]
        [Route("BehavioralKPI/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.behavioralKPIService.RetrieveById(id, BehavioralKPI.Informer, this.UserCredit);

			return result.ToActionResult<BehavioralKPI>();
        }

        [HttpPost]
        [Route("BehavioralKPI/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.behavioralKPIService.RetrieveAll(BehavioralKPI.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<BehavioralKPI>();
        }
            

        
        [HttpPost]
        [Route("BehavioralKPI/Save")]
        public async Task<IActionResult> Save([FromBody] BehavioralKPI behavioralKPI)
        {
            var result = await this.behavioralKPIService.Save(behavioralKPI, this.UserCredit);

			return result.ToActionResult<BehavioralKPI>();
        }

        
        [HttpPost]
        [Route("BehavioralKPI/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] BehavioralKPI behavioralKPI)
        {
            var result = await this.behavioralKPIService.SaveAttached(behavioralKPI, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("BehavioralKPI/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<BehavioralKPI> behavioralKPIList)
        {
            var result = await this.behavioralKPIService.SaveBulk(behavioralKPIList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("BehavioralKPI/Seek")]
        public async Task<IActionResult> Seek([FromBody] BehavioralKPI behavioralKPI)
        {
            var result = await this.behavioralKPIService.Seek(behavioralKPI, this.UserCredit);

			return result.ToActionResult<BehavioralKPI>();
        }

        [HttpGet]
        [Route("BehavioralKPI/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.behavioralKPIService.SeekByValue(seekValue, BehavioralKPI.Informer, this.UserCredit);

			return result.ToActionResult<BehavioralKPI>();
        }

        [HttpPost]
        [Route("BehavioralKPI/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] BehavioralKPI behavioralKPI)
        {
            var result = await this.behavioralKPIService.Delete(behavioralKPI, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfBehavioralAppraise
        [HttpPost]
        [Route("BehavioralKPI/{behavioralKPI_id:int}/BehavioralAppraise")]
        public IActionResult CollectionOfBehavioralAppraise([FromRoute(Name = "behavioralKPI_id")] int id, BehavioralAppraise behavioralAppraise)
        {
            return this.behavioralKPIService.CollectionOfBehavioralAppraise(id, behavioralAppraise, this.UserCredit).ToActionResult();
        }
    }
}