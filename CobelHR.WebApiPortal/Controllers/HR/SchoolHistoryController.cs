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
    public class SchoolHistoryController : BaseController
    {
        public SchoolHistoryController(ISchoolHistoryService schoolHistoryService)
        {
            this.schoolHistoryService = schoolHistoryService;
        }

        private ISchoolHistoryService schoolHistoryService { get; set; }

        [HttpGet]
        [Route("SchoolHistory/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.schoolHistoryService.RetrieveById(id, SchoolHistory.Informer, this.UserCredit);

			return result.ToActionResult<SchoolHistory>();
        }

        [HttpPost]
        [Route("SchoolHistory/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.schoolHistoryService.RetrieveAll(SchoolHistory.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<SchoolHistory>();
        }
            

        
        [HttpPost]
        [Route("SchoolHistory/Save")]
        public async Task<IActionResult> Save([FromBody] SchoolHistory schoolHistory)
        {
            var result = await this.schoolHistoryService.Save(schoolHistory, this.UserCredit);

			return result.ToActionResult<SchoolHistory>();
        }

        
        [HttpPost]
        [Route("SchoolHistory/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] SchoolHistory schoolHistory)
        {
            var result = await this.schoolHistoryService.SaveAttached(schoolHistory, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("SchoolHistory/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<SchoolHistory> schoolHistoryList)
        {
            var result = await this.schoolHistoryService.SaveBulk(schoolHistoryList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("SchoolHistory/Seek")]
        public async Task<IActionResult> Seek([FromBody] SchoolHistory schoolHistory)
        {
            var result = await this.schoolHistoryService.Seek(schoolHistory, this.UserCredit);

			return result.ToActionResult<SchoolHistory>();
        }

        [HttpGet]
        [Route("SchoolHistory/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.schoolHistoryService.SeekByValue(seekValue, SchoolHistory.Informer, this.UserCredit);

			return result.ToActionResult<SchoolHistory>();
        }

        [HttpPost]
        [Route("SchoolHistory/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] SchoolHistory schoolHistory)
        {
            var result = await this.schoolHistoryService.Delete(schoolHistory, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}