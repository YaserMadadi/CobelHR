using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.IDEA.Abstract;
using CobelHR.Entities.IDEA;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.IDEA
{
    [Route("api/IDEA")]
    public class TrainingController : BaseController
    {
        public TrainingController(ITrainingService trainingService)
        {
            this.trainingService = trainingService;
        }

        private ITrainingService trainingService { get; set; }

        [HttpGet]
        [Route("Training/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.trainingService.RetrieveById(id, Training.Informer, this.UserCredit);

			return result.ToActionResult<Training>();
        }

        [HttpPost]
        [Route("Training/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.trainingService.RetrieveAll(Training.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Training>();
        }
            

        
        [HttpPost]
        [Route("Training/Save")]
        public async Task<IActionResult> Save([FromBody] Training training)
        {
            var result = await this.trainingService.Save(training, this.UserCredit);

			return result.ToActionResult<Training>();
        }

        
        [HttpPost]
        [Route("Training/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Training training)
        {
            var result = await this.trainingService.SaveAttached(training, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Training/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Training> trainingList)
        {
            var result = await this.trainingService.SaveBulk(trainingList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Training/Seek")]
        public async Task<IActionResult> Seek([FromBody] Training training)
        {
            var result = await this.trainingService.Seek(training, this.UserCredit);

			return result.ToActionResult<Training>();
        }

        [HttpGet]
        [Route("Training/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.trainingService.SeekByValue(seekValue, Training.Informer, this.UserCredit);

			return result.ToActionResult<Training>();
        }

        [HttpPost]
        [Route("Training/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Training training)
        {
            var result = await this.trainingService.Delete(training, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}