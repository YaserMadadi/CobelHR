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
    public class PositionAssignmentController : BaseController
    {
        public PositionAssignmentController(IPositionAssignmentService positionAssignmentService)
        {
            this.positionAssignmentService = positionAssignmentService;
        }

        private IPositionAssignmentService positionAssignmentService { get; set; }

        [HttpGet]
        [Route("PositionAssignment/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.positionAssignmentService.RetrieveById(id, PositionAssignment.Informer, this.UserCredit);

			return result.ToActionResult<PositionAssignment>();
        }

        [HttpPost]
        [Route("PositionAssignment/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.positionAssignmentService.RetrieveAll(PositionAssignment.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PositionAssignment>();
        }
            

        
        [HttpPost]
        [Route("PositionAssignment/Save")]
        public async Task<IActionResult> Save([FromBody] PositionAssignment positionAssignment)
        {
            var result = await this.positionAssignmentService.Save(positionAssignment, this.UserCredit);

			return result.ToActionResult<PositionAssignment>();
        }

        
        [HttpPost]
        [Route("PositionAssignment/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PositionAssignment positionAssignment)
        {
            var result = await this.positionAssignmentService.SaveAttached(positionAssignment, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PositionAssignment/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PositionAssignment> positionAssignmentList)
        {
            var result = await this.positionAssignmentService.SaveBulk(positionAssignmentList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PositionAssignment/Seek")]
        public async Task<IActionResult> Seek([FromBody] PositionAssignment positionAssignment)
        {
            var result = await this.positionAssignmentService.Seek(positionAssignment, this.UserCredit);

			return result.ToActionResult<PositionAssignment>();
        }

        [HttpGet]
        [Route("PositionAssignment/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.positionAssignmentService.SeekByValue(seekValue, PositionAssignment.Informer, this.UserCredit);

			return result.ToActionResult<PositionAssignment>();
        }

        [HttpPost]
        [Route("PositionAssignment/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PositionAssignment positionAssignment)
        {
            var result = await this.positionAssignmentService.Delete(positionAssignment, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPositionAssignmentRepeal
        [HttpPost]
        [Route("PositionAssignment/{positionAssignment_id:int}/PositionAssignmentRepeal")]
        public IActionResult CollectionOfPositionAssignmentRepeal([FromRoute(Name = "positionAssignment_id")] int id, PositionAssignmentRepeal positionAssignmentRepeal)
        {
            return this.positionAssignmentService.CollectionOfPositionAssignmentRepeal(id, positionAssignmentRepeal, this.UserCredit).ToActionResult();
        }
    }
}