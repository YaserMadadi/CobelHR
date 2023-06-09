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
    public class IndividualDevelopmentPlanController : BaseController
    {
        public IndividualDevelopmentPlanController(IIndividualDevelopmentPlanService individualDevelopmentPlanService)
        {
            this.individualDevelopmentPlanService = individualDevelopmentPlanService;
        }

        private IIndividualDevelopmentPlanService individualDevelopmentPlanService { get; set; }

        [HttpGet]
        [Route("IndividualDevelopmentPlan/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.individualDevelopmentPlanService.RetrieveById(id, IndividualDevelopmentPlan.Informer, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlan>();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlan/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.individualDevelopmentPlanService.RetrieveAll(IndividualDevelopmentPlan.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlan>();
        }
            

        
        [HttpPost]
        [Route("IndividualDevelopmentPlan/Save")]
        public async Task<IActionResult> Save([FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            var result = await this.individualDevelopmentPlanService.Save(individualDevelopmentPlan, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlan>();
        }

        
        [HttpPost]
        [Route("IndividualDevelopmentPlan/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            var result = await this.individualDevelopmentPlanService.SaveAttached(individualDevelopmentPlan, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("IndividualDevelopmentPlan/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<IndividualDevelopmentPlan> individualDevelopmentPlanList)
        {
            var result = await this.individualDevelopmentPlanService.SaveBulk(individualDevelopmentPlanList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlan/Seek")]
        public async Task<IActionResult> Seek([FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            var result = await this.individualDevelopmentPlanService.Seek(individualDevelopmentPlan, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlan>();
        }

        [HttpGet]
        [Route("IndividualDevelopmentPlan/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.individualDevelopmentPlanService.SeekByValue(seekValue, IndividualDevelopmentPlan.Informer, this.UserCredit);

			return result.ToActionResult<IndividualDevelopmentPlan>();
        }

        [HttpPost]
        [Route("IndividualDevelopmentPlan/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            var result = await this.individualDevelopmentPlanService.Delete(individualDevelopmentPlan, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfDevelopmentPlanCompetency
        [HttpPost]
        [Route("IndividualDevelopmentPlan/{individualDevelopmentPlan_id:int}/DevelopmentPlanCompetency")]
        public IActionResult CollectionOfDevelopmentPlanCompetency([FromRoute(Name = "individualDevelopmentPlan_id")] int id, DevelopmentPlanCompetency developmentPlanCompetency)
        {
            return this.individualDevelopmentPlanService.CollectionOfDevelopmentPlanCompetency(id, developmentPlanCompetency, this.UserCredit).ToActionResult();
        }
    }
}