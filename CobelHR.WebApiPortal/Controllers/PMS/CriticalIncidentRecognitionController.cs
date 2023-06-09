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
    public class CriticalIncidentRecognitionController : BaseController
    {
        public CriticalIncidentRecognitionController(ICriticalIncidentRecognitionService criticalIncidentRecognitionService)
        {
            this.criticalIncidentRecognitionService = criticalIncidentRecognitionService;
        }

        private ICriticalIncidentRecognitionService criticalIncidentRecognitionService { get; set; }

        [HttpGet]
        [Route("CriticalIncidentRecognition/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.criticalIncidentRecognitionService.RetrieveById(id, CriticalIncidentRecognition.Informer, this.UserCredit);

			return result.ToActionResult<CriticalIncidentRecognition>();
        }

        [HttpPost]
        [Route("CriticalIncidentRecognition/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.criticalIncidentRecognitionService.RetrieveAll(CriticalIncidentRecognition.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CriticalIncidentRecognition>();
        }
            

        
        [HttpPost]
        [Route("CriticalIncidentRecognition/Save")]
        public async Task<IActionResult> Save([FromBody] CriticalIncidentRecognition criticalIncidentRecognition)
        {
            var result = await this.criticalIncidentRecognitionService.Save(criticalIncidentRecognition, this.UserCredit);

			return result.ToActionResult<CriticalIncidentRecognition>();
        }

        
        [HttpPost]
        [Route("CriticalIncidentRecognition/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CriticalIncidentRecognition criticalIncidentRecognition)
        {
            var result = await this.criticalIncidentRecognitionService.SaveAttached(criticalIncidentRecognition, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CriticalIncidentRecognition/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CriticalIncidentRecognition> criticalIncidentRecognitionList)
        {
            var result = await this.criticalIncidentRecognitionService.SaveBulk(criticalIncidentRecognitionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CriticalIncidentRecognition/Seek")]
        public async Task<IActionResult> Seek([FromBody] CriticalIncidentRecognition criticalIncidentRecognition)
        {
            var result = await this.criticalIncidentRecognitionService.Seek(criticalIncidentRecognition, this.UserCredit);

			return result.ToActionResult<CriticalIncidentRecognition>();
        }

        [HttpGet]
        [Route("CriticalIncidentRecognition/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.criticalIncidentRecognitionService.SeekByValue(seekValue, CriticalIncidentRecognition.Informer, this.UserCredit);

			return result.ToActionResult<CriticalIncidentRecognition>();
        }

        [HttpPost]
        [Route("CriticalIncidentRecognition/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CriticalIncidentRecognition criticalIncidentRecognition)
        {
            var result = await this.criticalIncidentRecognitionService.Delete(criticalIncidentRecognition, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}