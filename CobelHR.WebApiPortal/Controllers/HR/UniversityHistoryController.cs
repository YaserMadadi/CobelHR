using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class UniversityHistoryController : BaseController
    {
        public UniversityHistoryController(IUniversityHistoryService universityHistoryService)
        {
            this.universityHistoryService = universityHistoryService;
        }

        private IUniversityHistoryService universityHistoryService { get; set; }

        [HttpGet]
        [Route("UniversityHistory/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.universityHistoryService.RetrieveById(id, UniversityHistory.Informer, this.UserCredit);

			return result.ToActionResult<UniversityHistory>();
        }

        [HttpPost]
        [Route("UniversityHistory/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.universityHistoryService.RetrieveAll(UniversityHistory.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<UniversityHistory>();
        }
            

        
        [HttpPost]
        [Route("UniversityHistory/Save")]
        public async Task<IActionResult> Save([FromBody] UniversityHistory universityHistory)
        {
            var result = await this.universityHistoryService.Save(universityHistory, this.UserCredit);

			return result.ToActionResult<UniversityHistory>();
        }

        
        [HttpPost]
        [Route("UniversityHistory/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] UniversityHistory universityHistory)
        {
            var result = await this.universityHistoryService.SaveAttached(universityHistory, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("UniversityHistory/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<UniversityHistory> universityHistoryList)
        {
            var result = await this.universityHistoryService.SaveBulk(universityHistoryList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("UniversityHistory/Seek")]
        public async Task<IActionResult> Seek([FromBody] UniversityHistory universityHistory)
        {
            var result = await this.universityHistoryService.Seek(universityHistory, this.UserCredit);

			return result.ToActionResult<UniversityHistory>();
        }

        [HttpGet]
        [Route("UniversityHistory/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.universityHistoryService.SeekByValue(seekValue, UniversityHistory.Informer, this.UserCredit);

			return result.ToActionResult<UniversityHistory>();
        }

        [HttpPost]
        [Route("UniversityHistory/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] UniversityHistory universityHistory)
        {
            var result = await this.universityHistoryService.Delete(universityHistory, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfUniversityTerminate
        [HttpPost]
        [Route("UniversityHistory/{universityHistory_id:int}/UniversityTerminate")]
        public IActionResult CollectionOfUniversityTerminate([FromRoute(Name = "universityHistory_id")] int id, UniversityTerminate universityTerminate)
        {
            return this.universityHistoryService.CollectionOfUniversityTerminate(id, universityTerminate, this.UserCredit).ToActionResult();
        }
    }
}