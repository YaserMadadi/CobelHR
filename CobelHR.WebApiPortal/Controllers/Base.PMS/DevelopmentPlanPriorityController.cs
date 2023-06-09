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
    public class DevelopmentPlanPriorityController : BaseController
    {
        public DevelopmentPlanPriorityController(IDevelopmentPlanPriorityService developmentPlanPriorityService)
        {
            this.developmentPlanPriorityService = developmentPlanPriorityService;
        }

        private IDevelopmentPlanPriorityService developmentPlanPriorityService { get; set; }

        [HttpGet]
        [Route("DevelopmentPlanPriority/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.developmentPlanPriorityService.RetrieveById(id, DevelopmentPlanPriority.Informer, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanPriority>();
        }

        [HttpPost]
        [Route("DevelopmentPlanPriority/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.developmentPlanPriorityService.RetrieveAll(DevelopmentPlanPriority.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanPriority>();
        }
            

        
        [HttpPost]
        [Route("DevelopmentPlanPriority/Save")]
        public async Task<IActionResult> Save([FromBody] DevelopmentPlanPriority developmentPlanPriority)
        {
            var result = await this.developmentPlanPriorityService.Save(developmentPlanPriority, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanPriority>();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanPriority/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] DevelopmentPlanPriority developmentPlanPriority)
        {
            var result = await this.developmentPlanPriorityService.SaveAttached(developmentPlanPriority, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanPriority/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<DevelopmentPlanPriority> developmentPlanPriorityList)
        {
            var result = await this.developmentPlanPriorityService.SaveBulk(developmentPlanPriorityList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("DevelopmentPlanPriority/Seek")]
        public async Task<IActionResult> Seek([FromBody] DevelopmentPlanPriority developmentPlanPriority)
        {
            var result = await this.developmentPlanPriorityService.Seek(developmentPlanPriority, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanPriority>();
        }

        [HttpGet]
        [Route("DevelopmentPlanPriority/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.developmentPlanPriorityService.SeekByValue(seekValue, DevelopmentPlanPriority.Informer, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanPriority>();
        }

        [HttpPost]
        [Route("DevelopmentPlanPriority/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] DevelopmentPlanPriority developmentPlanPriority)
        {
            var result = await this.developmentPlanPriorityService.Delete(developmentPlanPriority, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan_Priority
        [HttpPost]
        [Route("Priority/{developmentPlanPriority_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan_Priority([FromRoute(Name = "developmentPlanPriority_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.developmentPlanPriorityService.CollectionOfIndividualDevelopmentPlan_Priority(id, individualDevelopmentPlan, this.UserCredit).ToActionResult();
        }
    }
}