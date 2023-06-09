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
    public class ExpectedLevelController : BaseController
    {
        public ExpectedLevelController(IExpectedLevelService expectedLevelService)
        {
            this.expectedLevelService = expectedLevelService;
        }

        private IExpectedLevelService expectedLevelService { get; set; }

        [HttpGet]
        [Route("ExpectedLevel/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.expectedLevelService.RetrieveById(id, ExpectedLevel.Informer, this.UserCredit);

			return result.ToActionResult<ExpectedLevel>();
        }

        [HttpPost]
        [Route("ExpectedLevel/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.expectedLevelService.RetrieveAll(ExpectedLevel.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ExpectedLevel>();
        }
            

        
        [HttpPost]
        [Route("ExpectedLevel/Save")]
        public async Task<IActionResult> Save([FromBody] ExpectedLevel expectedLevel)
        {
            var result = await this.expectedLevelService.Save(expectedLevel, this.UserCredit);

			return result.ToActionResult<ExpectedLevel>();
        }

        
        [HttpPost]
        [Route("ExpectedLevel/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ExpectedLevel expectedLevel)
        {
            var result = await this.expectedLevelService.SaveAttached(expectedLevel, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ExpectedLevel/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ExpectedLevel> expectedLevelList)
        {
            var result = await this.expectedLevelService.SaveBulk(expectedLevelList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ExpectedLevel/Seek")]
        public async Task<IActionResult> Seek([FromBody] ExpectedLevel expectedLevel)
        {
            var result = await this.expectedLevelService.Seek(expectedLevel, this.UserCredit);

			return result.ToActionResult<ExpectedLevel>();
        }

        [HttpGet]
        [Route("ExpectedLevel/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.expectedLevelService.SeekByValue(seekValue, ExpectedLevel.Informer, this.UserCredit);

			return result.ToActionResult<ExpectedLevel>();
        }

        [HttpPost]
        [Route("ExpectedLevel/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ExpectedLevel expectedLevel)
        {
            var result = await this.expectedLevelService.Delete(expectedLevel, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfBehavioralObjective
        [HttpPost]
        [Route("ExpectedLevel/{expectedLevel_id:int}/BehavioralObjective")]
        public IActionResult CollectionOfBehavioralObjective([FromRoute(Name = "expectedLevel_id")] int id, BehavioralObjective behavioralObjective)
        {
            return this.expectedLevelService.CollectionOfBehavioralObjective(id, behavioralObjective, this.UserCredit).ToActionResult();
        }
    }
}