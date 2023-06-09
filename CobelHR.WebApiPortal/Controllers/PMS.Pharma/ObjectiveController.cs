using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Pharma.Abstract;
using CobelHR.Entities.PMS.Pharma;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS.Pharma
{
    [Route("api/PMS.Pharma")]
    public class ObjectiveController : BaseController
    {
        public ObjectiveController(IObjectiveService objectiveService)
        {
            this.objectiveService = objectiveService;
        }

        private IObjectiveService objectiveService { get; set; }

        [HttpGet]
        [Route("Objective/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.objectiveService.RetrieveById(id, Objective.Informer, this.UserCredit);

			return result.ToActionResult<Objective>();
        }

        [HttpPost]
        [Route("Objective/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.objectiveService.RetrieveAll(Objective.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Objective>();
        }
            

        
        [HttpPost]
        [Route("Objective/Save")]
        public async Task<IActionResult> Save([FromBody] Objective objective)
        {
            var result = await this.objectiveService.Save(objective, this.UserCredit);

			return result.ToActionResult<Objective>();
        }

        
        [HttpPost]
        [Route("Objective/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Objective objective)
        {
            var result = await this.objectiveService.SaveAttached(objective, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Objective/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Objective> objectiveList)
        {
            var result = await this.objectiveService.SaveBulk(objectiveList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Objective/Seek")]
        public async Task<IActionResult> Seek([FromBody] Objective objective)
        {
            var result = await this.objectiveService.Seek(objective, this.UserCredit);

			return result.ToActionResult<Objective>();
        }

        [HttpGet]
        [Route("Objective/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.objectiveService.SeekByValue(seekValue, Objective.Informer, this.UserCredit);

			return result.ToActionResult<Objective>();
        }

        [HttpPost]
        [Route("Objective/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Objective objective)
        {
            var result = await this.objectiveService.Delete(objective, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfKPI
        [HttpPost]
        [Route("Objective/{objective_id:int}/KPI")]
        public IActionResult CollectionOfKPI([FromRoute(Name = "objective_id")] int id, KPI KPI)
        {
            return this.objectiveService.CollectionOfKPI(id, KPI, this.UserCredit).ToActionResult();
        }
    }
}