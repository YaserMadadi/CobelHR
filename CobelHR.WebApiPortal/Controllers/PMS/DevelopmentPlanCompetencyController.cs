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
    public class DevelopmentPlanCompetencyController : BaseController
    {
        public DevelopmentPlanCompetencyController(IDevelopmentPlanCompetencyService developmentPlanCompetencyService)
        {
            this.developmentPlanCompetencyService = developmentPlanCompetencyService;
        }

        private IDevelopmentPlanCompetencyService developmentPlanCompetencyService { get; set; }

        [HttpGet]
        [Route("DevelopmentPlanCompetency/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.developmentPlanCompetencyService.RetrieveById(id, DevelopmentPlanCompetency.Informer, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanCompetency>();
        }

        [HttpPost]
        [Route("DevelopmentPlanCompetency/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.developmentPlanCompetencyService.RetrieveAll(DevelopmentPlanCompetency.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanCompetency>();
        }
            

        
        [HttpPost]
        [Route("DevelopmentPlanCompetency/Save")]
        public async Task<IActionResult> Save([FromBody] DevelopmentPlanCompetency developmentPlanCompetency)
        {
            var result = await this.developmentPlanCompetencyService.Save(developmentPlanCompetency, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanCompetency>();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanCompetency/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] DevelopmentPlanCompetency developmentPlanCompetency)
        {
            var result = await this.developmentPlanCompetencyService.SaveAttached(developmentPlanCompetency, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("DevelopmentPlanCompetency/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<DevelopmentPlanCompetency> developmentPlanCompetencyList)
        {
            var result = await this.developmentPlanCompetencyService.SaveBulk(developmentPlanCompetencyList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("DevelopmentPlanCompetency/Seek")]
        public async Task<IActionResult> Seek([FromBody] DevelopmentPlanCompetency developmentPlanCompetency)
        {
            var result = await this.developmentPlanCompetencyService.Seek(developmentPlanCompetency, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanCompetency>();
        }

        [HttpGet]
        [Route("DevelopmentPlanCompetency/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.developmentPlanCompetencyService.SeekByValue(seekValue, DevelopmentPlanCompetency.Informer, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanCompetency>();
        }

        [HttpPost]
        [Route("DevelopmentPlanCompetency/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] DevelopmentPlanCompetency developmentPlanCompetency)
        {
            var result = await this.developmentPlanCompetencyService.Delete(developmentPlanCompetency, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}