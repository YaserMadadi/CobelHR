using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class LevelController : BaseController
    {
        public LevelController(ILevelService levelService)
        {
            this.levelService = levelService;
        }

        private ILevelService levelService { get; set; }

        [HttpGet]
        [Route("Level/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.levelService.RetrieveById(id, Level.Informer, this.UserCredit);

			return result.ToActionResult<Level>();
        }

        [HttpPost]
        [Route("Level/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.levelService.RetrieveAll(Level.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Level>();
        }
            

        
        [HttpPost]
        [Route("Level/Save")]
        public async Task<IActionResult> Save([FromBody] Level level)
        {
            var result = await this.levelService.Save(level, this.UserCredit);

			return result.ToActionResult<Level>();
        }

        
        [HttpPost]
        [Route("Level/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Level level)
        {
            var result = await this.levelService.SaveAttached(level, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Level/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Level> levelList)
        {
            var result = await this.levelService.SaveBulk(levelList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Level/Seek")]
        public async Task<IActionResult> Seek([FromBody] Level level)
        {
            var result = await this.levelService.Seek(level, this.UserCredit);

			return result.ToActionResult<Level>();
        }

        [HttpGet]
        [Route("Level/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.levelService.SeekByValue(seekValue, Level.Informer, this.UserCredit);

			return result.ToActionResult<Level>();
        }

        [HttpPost]
        [Route("Level/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Level level)
        {
            var result = await this.levelService.Delete(level, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfObjectiveWeightNonOperational
        [HttpPost]
        [Route("Level/{level_id:int}/ObjectiveWeightNonOperational")]
        public IActionResult CollectionOfObjectiveWeightNonOperational([FromRoute(Name = "level_id")] int id, ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            return this.levelService.CollectionOfObjectiveWeightNonOperational(id, objectiveWeightNonOperational, this.UserCredit).ToActionResult();
        }

		// CollectionOfPosition
        [HttpPost]
        [Route("Level/{level_id:int}/Position")]
        public IActionResult CollectionOfPosition([FromRoute(Name = "level_id")] int id, Position position)
        {
            return this.levelService.CollectionOfPosition(id, position, this.UserCredit).ToActionResult();
        }
    }
}