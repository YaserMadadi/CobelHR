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
    public class FunctionalKPIController : BaseController
    {
        public FunctionalKPIController(IFunctionalKPIService functionalKPIService)
        {
            this.functionalKPIService = functionalKPIService;
        }

        private IFunctionalKPIService functionalKPIService { get; set; }

        [HttpGet]
        [Route("FunctionalKPI/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.functionalKPIService.RetrieveById(id, FunctionalKPI.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalKPI>();
        }

        [HttpPost]
        [Route("FunctionalKPI/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.functionalKPIService.RetrieveAll(FunctionalKPI.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<FunctionalKPI>();
        }
            

        
        [HttpPost]
        [Route("FunctionalKPI/Save")]
        public async Task<IActionResult> Save([FromBody] FunctionalKPI functionalKPI)
        {
            var result = await this.functionalKPIService.Save(functionalKPI, this.UserCredit);

			return result.ToActionResult<FunctionalKPI>();
        }

        
        [HttpPost]
        [Route("FunctionalKPI/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] FunctionalKPI functionalKPI)
        {
            var result = await this.functionalKPIService.SaveAttached(functionalKPI, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("FunctionalKPI/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<FunctionalKPI> functionalKPIList)
        {
            var result = await this.functionalKPIService.SaveBulk(functionalKPIList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("FunctionalKPI/Seek")]
        public async Task<IActionResult> Seek([FromBody] FunctionalKPI functionalKPI)
        {
            var result = await this.functionalKPIService.Seek(functionalKPI, this.UserCredit);

			return result.ToActionResult<FunctionalKPI>();
        }

        [HttpGet]
        [Route("FunctionalKPI/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.functionalKPIService.SeekByValue(seekValue, FunctionalKPI.Informer, this.UserCredit);

			return result.ToActionResult<FunctionalKPI>();
        }

        [HttpPost]
        [Route("FunctionalKPI/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] FunctionalKPI functionalKPI)
        {
            var result = await this.functionalKPIService.Delete(functionalKPI, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfFunctionalAppraise
        [HttpPost]
        [Route("FunctionalKPI/{functionalKPI_id:int}/FunctionalAppraise")]
        public IActionResult CollectionOfFunctionalAppraise([FromRoute(Name = "functionalKPI_id")] int id, FunctionalAppraise functionalAppraise)
        {
            return this.functionalKPIService.CollectionOfFunctionalAppraise(id, functionalAppraise, this.UserCredit).ToActionResult();
        }

		// CollectionOfFunctionalKPIComment
        [HttpPost]
        [Route("FunctionalKPI/{functionalKPI_id:int}/FunctionalKPIComment")]
        public IActionResult CollectionOfFunctionalKPIComment([FromRoute(Name = "functionalKPI_id")] int id, FunctionalKPIComment functionalKPIComment)
        {
            return this.functionalKPIService.CollectionOfFunctionalKPIComment(id, functionalKPIComment, this.UserCredit).ToActionResult();
        }
    }
}