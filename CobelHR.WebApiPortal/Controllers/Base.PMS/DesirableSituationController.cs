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
    public class DesirableSituationController : BaseController
    {
        public DesirableSituationController(IDesirableSituationService desirableSituationService)
        {
            this.desirableSituationService = desirableSituationService;
        }

        private IDesirableSituationService desirableSituationService { get; set; }

        [HttpGet]
        [Route("DesirableSituation/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.desirableSituationService.RetrieveById(id, DesirableSituation.Informer, this.UserCredit);

			return result.ToActionResult<DesirableSituation>();
        }

        [HttpPost]
        [Route("DesirableSituation/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.desirableSituationService.RetrieveAll(DesirableSituation.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<DesirableSituation>();
        }
            

        
        [HttpPost]
        [Route("DesirableSituation/Save")]
        public async Task<IActionResult> Save([FromBody] DesirableSituation desirableSituation)
        {
            var result = await this.desirableSituationService.Save(desirableSituation, this.UserCredit);

			return result.ToActionResult<DesirableSituation>();
        }

        
        [HttpPost]
        [Route("DesirableSituation/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] DesirableSituation desirableSituation)
        {
            var result = await this.desirableSituationService.SaveAttached(desirableSituation, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("DesirableSituation/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<DesirableSituation> desirableSituationList)
        {
            var result = await this.desirableSituationService.SaveBulk(desirableSituationList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("DesirableSituation/Seek")]
        public async Task<IActionResult> Seek([FromBody] DesirableSituation desirableSituation)
        {
            var result = await this.desirableSituationService.Seek(desirableSituation, this.UserCredit);

			return result.ToActionResult<DesirableSituation>();
        }

        [HttpGet]
        [Route("DesirableSituation/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.desirableSituationService.SeekByValue(seekValue, DesirableSituation.Informer, this.UserCredit);

			return result.ToActionResult<DesirableSituation>();
        }

        [HttpPost]
        [Route("DesirableSituation/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] DesirableSituation desirableSituation)
        {
            var result = await this.desirableSituationService.Delete(desirableSituation, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan
        [HttpPost]
        [Route("DesirableSituation/{desirableSituation_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "desirableSituation_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.desirableSituationService.CollectionOfIndividualDevelopmentPlan(id, individualDevelopmentPlan, this.UserCredit).ToActionResult();
        }
    }
}