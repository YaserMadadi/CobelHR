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
    public class CompetencyItemKPIController : BaseController
    {
        public CompetencyItemKPIController(ICompetencyItemKPIService competencyItemKPIService)
        {
            this.competencyItemKPIService = competencyItemKPIService;
        }

        private ICompetencyItemKPIService competencyItemKPIService { get; set; }

        [HttpGet]
        [Route("CompetencyItemKPI/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.competencyItemKPIService.RetrieveById(id, CompetencyItemKPI.Informer, this.UserCredit);

			return result.ToActionResult<CompetencyItemKPI>();
        }

        [HttpPost]
        [Route("CompetencyItemKPI/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.competencyItemKPIService.RetrieveAll(CompetencyItemKPI.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CompetencyItemKPI>();
        }
            

        
        [HttpPost]
        [Route("CompetencyItemKPI/Save")]
        public async Task<IActionResult> Save([FromBody] CompetencyItemKPI competencyItemKPI)
        {
            var result = await this.competencyItemKPIService.Save(competencyItemKPI, this.UserCredit);

			return result.ToActionResult<CompetencyItemKPI>();
        }

        
        [HttpPost]
        [Route("CompetencyItemKPI/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CompetencyItemKPI competencyItemKPI)
        {
            var result = await this.competencyItemKPIService.SaveAttached(competencyItemKPI, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CompetencyItemKPI/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CompetencyItemKPI> competencyItemKPIList)
        {
            var result = await this.competencyItemKPIService.SaveBulk(competencyItemKPIList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CompetencyItemKPI/Seek")]
        public async Task<IActionResult> Seek([FromBody] CompetencyItemKPI competencyItemKPI)
        {
            var result = await this.competencyItemKPIService.Seek(competencyItemKPI, this.UserCredit);

			return result.ToActionResult<CompetencyItemKPI>();
        }

        [HttpGet]
        [Route("CompetencyItemKPI/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.competencyItemKPIService.SeekByValue(seekValue, CompetencyItemKPI.Informer, this.UserCredit);

			return result.ToActionResult<CompetencyItemKPI>();
        }

        [HttpPost]
        [Route("CompetencyItemKPI/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CompetencyItemKPI competencyItemKPI)
        {
            var result = await this.competencyItemKPIService.Delete(competencyItemKPI, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfBehavioralKPI
        [HttpPost]
        [Route("CompetencyItemKPI/{competencyItemKPI_id:int}/BehavioralKPI")]
        public IActionResult CollectionOfBehavioralKPI([FromRoute(Name = "competencyItemKPI_id")] int id, BehavioralKPI behavioralKPI)
        {
            return this.competencyItemKPIService.CollectionOfBehavioralKPI(id, behavioralKPI, this.UserCredit).ToActionResult();
        }
    }
}