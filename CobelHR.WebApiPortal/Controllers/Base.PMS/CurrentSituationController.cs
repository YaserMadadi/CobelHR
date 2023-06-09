using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class CurrentSituationController : BaseController
    {
        public CurrentSituationController(ICurrentSituationService currentSituationService)
        {
            this.currentSituationService = currentSituationService;
        }

        private ICurrentSituationService currentSituationService { get; set; }

        [HttpGet]
        [Route("CurrentSituation/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.currentSituationService.RetrieveById(id, CurrentSituation.Informer, this.UserCredit);

			return result.ToActionResult<CurrentSituation>();
        }

        [HttpPost]
        [Route("CurrentSituation/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.currentSituationService.RetrieveAll(CurrentSituation.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CurrentSituation>();
        }
            

        
        [HttpPost]
        [Route("CurrentSituation/Save")]
        public async Task<IActionResult> Save([FromBody] CurrentSituation currentSituation)
        {
            var result = await this.currentSituationService.Save(currentSituation, this.UserCredit);

			return result.ToActionResult<CurrentSituation>();
        }

        
        [HttpPost]
        [Route("CurrentSituation/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CurrentSituation currentSituation)
        {
            var result = await this.currentSituationService.SaveAttached(currentSituation, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CurrentSituation/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CurrentSituation> currentSituationList)
        {
            var result = await this.currentSituationService.SaveBulk(currentSituationList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CurrentSituation/Seek")]
        public async Task<IActionResult> Seek([FromBody] CurrentSituation currentSituation)
        {
            var result = await this.currentSituationService.Seek(currentSituation, this.UserCredit);

			return result.ToActionResult<CurrentSituation>();
        }

        [HttpGet]
        [Route("CurrentSituation/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.currentSituationService.SeekByValue(seekValue, CurrentSituation.Informer, this.UserCredit);

			return result.ToActionResult<CurrentSituation>();
        }

        [HttpPost]
        [Route("CurrentSituation/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CurrentSituation currentSituation)
        {
            var result = await this.currentSituationService.Delete(currentSituation, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan
        [HttpPost]
        [Route("CurrentSituation/{currentSituation_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "currentSituation_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.currentSituationService.CollectionOfIndividualDevelopmentPlan(id, individualDevelopmentPlan, this.UserCredit).ToActionResult();
        }
    }
}