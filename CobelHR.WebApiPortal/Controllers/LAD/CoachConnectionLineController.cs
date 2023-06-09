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
    public class CoachConnectionLineController : BaseController
    {
        public CoachConnectionLineController(ICoachConnectionLineService coachConnectionLineService)
        {
            this.coachConnectionLineService = coachConnectionLineService;
        }

        private ICoachConnectionLineService coachConnectionLineService { get; set; }

        [HttpGet]
        [Route("CoachConnectionLine/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.coachConnectionLineService.RetrieveById(id, CoachConnectionLine.Informer, this.UserCredit);

			return result.ToActionResult<CoachConnectionLine>();
        }

        [HttpPost]
        [Route("CoachConnectionLine/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.coachConnectionLineService.RetrieveAll(CoachConnectionLine.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CoachConnectionLine>();
        }
            

        
        [HttpPost]
        [Route("CoachConnectionLine/Save")]
        public async Task<IActionResult> Save([FromBody] CoachConnectionLine coachConnectionLine)
        {
            var result = await this.coachConnectionLineService.Save(coachConnectionLine, this.UserCredit);

			return result.ToActionResult<CoachConnectionLine>();
        }

        
        [HttpPost]
        [Route("CoachConnectionLine/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CoachConnectionLine coachConnectionLine)
        {
            var result = await this.coachConnectionLineService.SaveAttached(coachConnectionLine, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachConnectionLine/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CoachConnectionLine> coachConnectionLineList)
        {
            var result = await this.coachConnectionLineService.SaveBulk(coachConnectionLineList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CoachConnectionLine/Seek")]
        public async Task<IActionResult> Seek([FromBody] CoachConnectionLine coachConnectionLine)
        {
            var result = await this.coachConnectionLineService.Seek(coachConnectionLine, this.UserCredit);

			return result.ToActionResult<CoachConnectionLine>();
        }

        [HttpGet]
        [Route("CoachConnectionLine/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.coachConnectionLineService.SeekByValue(seekValue, CoachConnectionLine.Informer, this.UserCredit);

			return result.ToActionResult<CoachConnectionLine>();
        }

        [HttpPost]
        [Route("CoachConnectionLine/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CoachConnectionLine coachConnectionLine)
        {
            var result = await this.coachConnectionLineService.Delete(coachConnectionLine, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}