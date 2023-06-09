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
    public class FunctionalObjectiveController : BaseController
    {
        public FunctionalObjectiveController(IFunctionalObjectiveService functionalObjectiveService)
        {
            this.functionalObjectiveService = functionalObjectiveService;
        }

        private IFunctionalObjectiveService functionalObjectiveService { get; set; }

        [HttpGet]
        [Route("FunctionalObjective/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.functionalObjectiveService.RetrieveById(id, FunctionalObjective.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalObjective>();
        }

        [HttpPost]
        [Route("FunctionalObjective/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.functionalObjectiveService.RetrieveAll(FunctionalObjective.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<FunctionalObjective>();
        }
            

        
        [HttpPost]
        [Route("FunctionalObjective/Save")]
        public async Task<IActionResult> Save([FromBody] FunctionalObjective functionalObjective)
        {
            var result = await this.functionalObjectiveService.Save(functionalObjective, this.UserCredit);

			return result.ToActionResult<FunctionalObjective>();
        }

        
        [HttpPost]
        [Route("FunctionalObjective/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] FunctionalObjective functionalObjective)
        {
            var result = await this.functionalObjectiveService.SaveAttached(functionalObjective, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalObjective/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<FunctionalObjective> functionalObjectiveList)
        {
            var result = await this.functionalObjectiveService.SaveBulk(functionalObjectiveList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalObjective/Seek")]
        public async Task<IActionResult> Seek([FromBody] FunctionalObjective functionalObjective)
        {
            var result = await this.functionalObjectiveService.Seek(functionalObjective, this.UserCredit);

			return result.ToActionResult<FunctionalObjective>();
        }

        [HttpGet]
        [Route("FunctionalObjective/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.functionalObjectiveService.SeekByValue(seekValue, FunctionalObjective.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalObjective>();
        }

        [HttpPost]
        [Route("FunctionalObjective/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalObjective functionalObjective)
        {
            var result = await this.functionalObjectiveService.Delete(functionalObjective, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfFunctionalKPI
        [HttpPost]
        [Route("FunctionalObjective/{functionalObjective_id:int}/FunctionalKPI")]
        public IActionResult CollectionOfFunctionalKPI([FromRoute(Name = "functionalObjective_id")] int id, FunctionalKPI functionalKPI)
        {
            return this.functionalObjectiveService.CollectionOfFunctionalKPI(id, functionalKPI, this.UserCredit).ToActionResult();
        }

		// CollectionOfFunctionalObjective_ParentalFunctionalObjective
        [HttpPost]
        [Route("ParentalFunctionalObjective/{functionalObjective_id:int}/FunctionalObjective")]
        public IActionResult CollectionOfFunctionalObjective_ParentalFunctionalObjective([FromRoute(Name = "functionalObjective_id")] int id, FunctionalObjective functionalObjective)
        {
            return this.functionalObjectiveService.CollectionOfFunctionalObjective_ParentalFunctionalObjective(id, functionalObjective, this.UserCredit).ToActionResult();
        }

		// CollectionOfFunctionalObjectiveComment
        [HttpPost]
        [Route("FunctionalObjective/{functionalObjective_id:int}/FunctionalObjectiveComment")]
        public IActionResult CollectionOfFunctionalObjectiveComment([FromRoute(Name = "functionalObjective_id")] int id, FunctionalObjectiveComment functionalObjectiveComment)
        {
            return this.functionalObjectiveService.CollectionOfFunctionalObjectiveComment(id, functionalObjectiveComment, this.UserCredit).ToActionResult();
        }
    }
}