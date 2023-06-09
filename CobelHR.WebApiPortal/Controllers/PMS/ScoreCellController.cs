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
    public class ScoreCellController : BaseController
    {
        public ScoreCellController(IScoreCellService scoreCellService)
        {
            this.scoreCellService = scoreCellService;
        }

        private IScoreCellService scoreCellService { get; set; }

        [HttpGet]
        [Route("ScoreCell/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.scoreCellService.RetrieveById(id, ScoreCell.Informer, this.UserCredit);

			return result.ToActionResult<ScoreCell>();
        }

        [HttpPost]
        [Route("ScoreCell/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.scoreCellService.RetrieveAll(ScoreCell.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ScoreCell>();
        }
            

        
        [HttpPost]
        [Route("ScoreCell/Save")]
        public async Task<IActionResult> Save([FromBody] ScoreCell scoreCell)
        {
            var result = await this.scoreCellService.Save(scoreCell, this.UserCredit);

			return result.ToActionResult<ScoreCell>();
        }

        
        [HttpPost]
        [Route("ScoreCell/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ScoreCell scoreCell)
        {
            var result = await this.scoreCellService.SaveAttached(scoreCell, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ScoreCell/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ScoreCell> scoreCellList)
        {
            var result = await this.scoreCellService.SaveBulk(scoreCellList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ScoreCell/Seek")]
        public async Task<IActionResult> Seek([FromBody] ScoreCell scoreCell)
        {
            var result = await this.scoreCellService.Seek(scoreCell, this.UserCredit);

			return result.ToActionResult<ScoreCell>();
        }

        [HttpGet]
        [Route("ScoreCell/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.scoreCellService.SeekByValue(seekValue, ScoreCell.Informer, this.UserCredit);

			return result.ToActionResult<ScoreCell>();
        }

        [HttpPost]
        [Route("ScoreCell/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ScoreCell scoreCell)
        {
            var result = await this.scoreCellService.Delete(scoreCell, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAppraiseResult
        [HttpPost]
        [Route("ScoreCell/{scoreCell_id:int}/AppraiseResult")]
        public IActionResult CollectionOfAppraiseResult([FromRoute(Name = "scoreCell_id")] int id, AppraiseResult appraiseResult)
        {
            return this.scoreCellService.CollectionOfAppraiseResult(id, appraiseResult, this.UserCredit).ToActionResult();
        }

		// CollectionOfCellAction
        [HttpPost]
        [Route("ScoreCell/{scoreCell_id:int}/CellAction")]
        public IActionResult CollectionOfCellAction([FromRoute(Name = "scoreCell_id")] int id, CellAction cellAction)
        {
            return this.scoreCellService.CollectionOfCellAction(id, cellAction, this.UserCredit).ToActionResult();
        }

		// CollectionOfFinalAppraise
        [HttpPost]
        [Route("ScoreCell/{scoreCell_id:int}/FinalAppraise")]
        public IActionResult CollectionOfFinalAppraise([FromRoute(Name = "scoreCell_id")] int id, FinalAppraise finalAppraise)
        {
            return this.scoreCellService.CollectionOfFinalAppraise(id, finalAppraise, this.UserCredit).ToActionResult();
        }
    }
}