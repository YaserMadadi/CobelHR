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
    public class PositionAssignmentRepealController : BaseController
    {
        public PositionAssignmentRepealController(IPositionAssignmentRepealService positionAssignmentRepealService)
        {
            this.positionAssignmentRepealService = positionAssignmentRepealService;
        }

        private IPositionAssignmentRepealService positionAssignmentRepealService { get; set; }

        [HttpGet]
        [Route("PositionAssignmentRepeal/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.positionAssignmentRepealService.RetrieveById(id, PositionAssignmentRepeal.Informer, this.UserCredit);

			return result.ToActionResult<PositionAssignmentRepeal>();
        }

        [HttpPost]
        [Route("PositionAssignmentRepeal/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.positionAssignmentRepealService.RetrieveAll(PositionAssignmentRepeal.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PositionAssignmentRepeal>();
        }
            

        
        [HttpPost]
        [Route("PositionAssignmentRepeal/Save")]
        public async Task<IActionResult> Save([FromBody] PositionAssignmentRepeal positionAssignmentRepeal)
        {
            var result = await this.positionAssignmentRepealService.Save(positionAssignmentRepeal, this.UserCredit);

			return result.ToActionResult<PositionAssignmentRepeal>();
        }

        
        [HttpPost]
        [Route("PositionAssignmentRepeal/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PositionAssignmentRepeal positionAssignmentRepeal)
        {
            var result = await this.positionAssignmentRepealService.SaveAttached(positionAssignmentRepeal, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PositionAssignmentRepeal/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PositionAssignmentRepeal> positionAssignmentRepealList)
        {
            var result = await this.positionAssignmentRepealService.SaveBulk(positionAssignmentRepealList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PositionAssignmentRepeal/Seek")]
        public async Task<IActionResult> Seek([FromBody] PositionAssignmentRepeal positionAssignmentRepeal)
        {
            var result = await this.positionAssignmentRepealService.Seek(positionAssignmentRepeal, this.UserCredit);

			return result.ToActionResult<PositionAssignmentRepeal>();
        }

        [HttpGet]
        [Route("PositionAssignmentRepeal/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.positionAssignmentRepealService.SeekByValue(seekValue, PositionAssignmentRepeal.Informer, this.UserCredit);

			return result.ToActionResult<PositionAssignmentRepeal>();
        }

        [HttpPost]
        [Route("PositionAssignmentRepeal/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PositionAssignmentRepeal positionAssignmentRepeal)
        {
            var result = await this.positionAssignmentRepealService.Delete(positionAssignmentRepeal, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}