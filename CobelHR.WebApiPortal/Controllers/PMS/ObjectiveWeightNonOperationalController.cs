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
    public class ObjectiveWeightNonOperationalController : BaseController
    {
        public ObjectiveWeightNonOperationalController(IObjectiveWeightNonOperationalService objectiveWeightNonOperationalService)
        {
            this.objectiveWeightNonOperationalService = objectiveWeightNonOperationalService;
        }

        private IObjectiveWeightNonOperationalService objectiveWeightNonOperationalService { get; set; }

        [HttpGet]
        [Route("ObjectiveWeightNonOperational/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.objectiveWeightNonOperationalService.RetrieveById(id, ObjectiveWeightNonOperational.Informer, this.UserCredit);

			return result.ToActionResult<ObjectiveWeightNonOperational>();
        }

        [HttpPost]
        [Route("ObjectiveWeightNonOperational/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.objectiveWeightNonOperationalService.RetrieveAll(ObjectiveWeightNonOperational.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ObjectiveWeightNonOperational>();
        }
            

        
        [HttpPost]
        [Route("ObjectiveWeightNonOperational/Save")]
        public async Task<IActionResult> Save([FromBody] ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            var result = await this.objectiveWeightNonOperationalService.Save(objectiveWeightNonOperational, this.UserCredit);

			return result.ToActionResult<ObjectiveWeightNonOperational>();
        }

        
        [HttpPost]
        [Route("ObjectiveWeightNonOperational/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            var result = await this.objectiveWeightNonOperationalService.SaveAttached(objectiveWeightNonOperational, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ObjectiveWeightNonOperational/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ObjectiveWeightNonOperational> objectiveWeightNonOperationalList)
        {
            var result = await this.objectiveWeightNonOperationalService.SaveBulk(objectiveWeightNonOperationalList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ObjectiveWeightNonOperational/Seek")]
        public async Task<IActionResult> Seek([FromBody] ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            var result = await this.objectiveWeightNonOperationalService.Seek(objectiveWeightNonOperational, this.UserCredit);

			return result.ToActionResult<ObjectiveWeightNonOperational>();
        }

        [HttpGet]
        [Route("ObjectiveWeightNonOperational/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.objectiveWeightNonOperationalService.SeekByValue(seekValue, ObjectiveWeightNonOperational.Informer, this.UserCredit);

			return result.ToActionResult<ObjectiveWeightNonOperational>();
        }

        [HttpPost]
        [Route("ObjectiveWeightNonOperational/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ObjectiveWeightNonOperational objectiveWeightNonOperational)
        {
            var result = await this.objectiveWeightNonOperationalService.Delete(objectiveWeightNonOperational, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}