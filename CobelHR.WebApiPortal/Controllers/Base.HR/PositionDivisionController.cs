using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class PositionDivisionController : BaseController
    {
        public PositionDivisionController(IPositionDivisionService positionDivisionService)
        {
            this.positionDivisionService = positionDivisionService;
        }

        private IPositionDivisionService positionDivisionService { get; set; }

        [HttpGet]
        [Route("PositionDivision/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.positionDivisionService.RetrieveById(id, PositionDivision.Informer, this.UserCredit);

			return result.ToActionResult<PositionDivision>();
        }

        [HttpPost]
        [Route("PositionDivision/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.positionDivisionService.RetrieveAll(PositionDivision.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PositionDivision>();
        }
            

        
        [HttpPost]
        [Route("PositionDivision/Save")]
        public async Task<IActionResult> Save([FromBody] PositionDivision positionDivision)
        {
            var result = await this.positionDivisionService.Save(positionDivision, this.UserCredit);

			return result.ToActionResult<PositionDivision>();
        }

        
        [HttpPost]
        [Route("PositionDivision/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PositionDivision positionDivision)
        {
            var result = await this.positionDivisionService.SaveAttached(positionDivision, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PositionDivision/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PositionDivision> positionDivisionList)
        {
            var result = await this.positionDivisionService.SaveBulk(positionDivisionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PositionDivision/Seek")]
        public async Task<IActionResult> Seek([FromBody] PositionDivision positionDivision)
        {
            var result = await this.positionDivisionService.Seek(positionDivision, this.UserCredit);

			return result.ToActionResult<PositionDivision>();
        }

        [HttpGet]
        [Route("PositionDivision/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.positionDivisionService.SeekByValue(seekValue, PositionDivision.Informer, this.UserCredit);

			return result.ToActionResult<PositionDivision>();
        }

        [HttpPost]
        [Route("PositionDivision/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PositionDivision positionDivision)
        {
            var result = await this.positionDivisionService.Delete(positionDivision, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPosition
        [HttpPost]
        [Route("PositionDivision/{positionDivision_id:int}/Position")]
        public IActionResult CollectionOfPosition([FromRoute(Name = "positionDivision_id")] int id, Position position)
        {
            return this.positionDivisionService.CollectionOfPosition(id, position, this.UserCredit).ToActionResult();
        }
    }
}