using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.LAD.Abstract;
using CobelHR.Entities.LAD;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.LAD
{
    [Route("api/LAD")]
    public class DevelopmentGoalController : BaseController
    {
        public DevelopmentGoalController(IDevelopmentGoalService developmentGoalService)
        {
            this.developmentGoalService = developmentGoalService;
        }

        private IDevelopmentGoalService developmentGoalService { get; set; }

        [HttpGet]
        [Route("DevelopmentGoal/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.developmentGoalService.RetrieveById(id, DevelopmentGoal.Informer, this.UserCredit);

			return result.ToActionResult<DevelopmentGoal>();
        }

        [HttpPost]
        [Route("DevelopmentGoal/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.developmentGoalService.RetrieveAll(DevelopmentGoal.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<DevelopmentGoal>();
        }
            

        
        [HttpPost]
        [Route("DevelopmentGoal/Save")]
        public async Task<IActionResult> Save([FromBody] DevelopmentGoal developmentGoal)
        {
            var result = await this.developmentGoalService.Save(developmentGoal, this.UserCredit);

			return result.ToActionResult<DevelopmentGoal>();
        }

        
        [HttpPost]
        [Route("DevelopmentGoal/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] DevelopmentGoal developmentGoal)
        {
            var result = await this.developmentGoalService.SaveAttached(developmentGoal, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("DevelopmentGoal/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<DevelopmentGoal> developmentGoalList)
        {
            var result = await this.developmentGoalService.SaveBulk(developmentGoalList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("DevelopmentGoal/Seek")]
        public async Task<IActionResult> Seek([FromBody] DevelopmentGoal developmentGoal)
        {
            var result = await this.developmentGoalService.Seek(developmentGoal, this.UserCredit);

			return result.ToActionResult<DevelopmentGoal>();
        }

        [HttpGet]
        [Route("DevelopmentGoal/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.developmentGoalService.SeekByValue(seekValue, DevelopmentGoal.Informer, this.UserCredit);

			return result.ToActionResult<DevelopmentGoal>();
        }

        [HttpPost]
        [Route("DevelopmentGoal/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] DevelopmentGoal developmentGoal)
        {
            var result = await this.developmentGoalService.Delete(developmentGoal, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}