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
    public class BehavioralObjectiveController : BaseController
    {
        public BehavioralObjectiveController(IBehavioralObjectiveService behavioralObjectiveService)
        {
            this.behavioralObjectiveService = behavioralObjectiveService;
        }

        private IBehavioralObjectiveService behavioralObjectiveService { get; set; }

        [HttpGet]
        [Route("BehavioralObjective/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.behavioralObjectiveService.RetrieveById(id, BehavioralObjective.Informer, this.UserCredit);

			return result.ToActionResult<BehavioralObjective>();
        }

        [HttpPost]
        [Route("BehavioralObjective/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.behavioralObjectiveService.RetrieveAll(BehavioralObjective.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<BehavioralObjective>();
        }
            

        
        [HttpPost]
        [Route("BehavioralObjective/Save")]
        public async Task<IActionResult> Save([FromBody] BehavioralObjective behavioralObjective)
        {
            var result = await this.behavioralObjectiveService.Save(behavioralObjective, this.UserCredit);

			return result.ToActionResult<BehavioralObjective>();
        }

        
        [HttpPost]
        [Route("BehavioralObjective/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] BehavioralObjective behavioralObjective)
        {
            var result = await this.behavioralObjectiveService.SaveAttached(behavioralObjective, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("BehavioralObjective/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<BehavioralObjective> behavioralObjectiveList)
        {
            var result = await this.behavioralObjectiveService.SaveBulk(behavioralObjectiveList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("BehavioralObjective/Seek")]
        public async Task<IActionResult> Seek([FromBody] BehavioralObjective behavioralObjective)
        {
            var result = await this.behavioralObjectiveService.Seek(behavioralObjective, this.UserCredit);

			return result.ToActionResult<BehavioralObjective>();
        }

        [HttpGet]
        [Route("BehavioralObjective/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.behavioralObjectiveService.SeekByValue(seekValue, BehavioralObjective.Informer, this.UserCredit);

			return result.ToActionResult<BehavioralObjective>();
        }

        [HttpPost]
        [Route("BehavioralObjective/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] BehavioralObjective behavioralObjective)
        {
            var result = await this.behavioralObjectiveService.Delete(behavioralObjective, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfBehavioralKPI
        [HttpPost]
        [Route("BehavioralObjective/{behavioralObjective_id:int}/BehavioralKPI")]
        public IActionResult CollectionOfBehavioralKPI([FromRoute(Name = "behavioralObjective_id")] int id, BehavioralKPI behavioralKPI)
        {
            return this.behavioralObjectiveService.CollectionOfBehavioralKPI(id, behavioralKPI, this.UserCredit).ToActionResult();
        }
    }
}