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
    public class CriticalIncidentController : BaseController
    {
        public CriticalIncidentController(ICriticalIncidentService criticalIncidentService)
        {
            this.criticalIncidentService = criticalIncidentService;
        }

        private ICriticalIncidentService criticalIncidentService { get; set; }

        [HttpGet]
        [Route("CriticalIncident/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.criticalIncidentService.RetrieveById(id, CriticalIncident.Informer, this.UserCredit);

			return result.ToActionResult<CriticalIncident>();
        }

        [HttpPost]
        [Route("CriticalIncident/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.criticalIncidentService.RetrieveAll(CriticalIncident.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CriticalIncident>();
        }
            

        
        [HttpPost]
        [Route("CriticalIncident/Save")]
        public async Task<IActionResult> Save([FromBody] CriticalIncident criticalIncident)
        {
            var result = await this.criticalIncidentService.Save(criticalIncident, this.UserCredit);

			return result.ToActionResult<CriticalIncident>();
        }

        
        [HttpPost]
        [Route("CriticalIncident/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CriticalIncident criticalIncident)
        {
            var result = await this.criticalIncidentService.SaveAttached(criticalIncident, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CriticalIncident/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CriticalIncident> criticalIncidentList)
        {
            var result = await this.criticalIncidentService.SaveBulk(criticalIncidentList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CriticalIncident/Seek")]
        public async Task<IActionResult> Seek([FromBody] CriticalIncident criticalIncident)
        {
            var result = await this.criticalIncidentService.Seek(criticalIncident, this.UserCredit);

			return result.ToActionResult<CriticalIncident>();
        }

        [HttpGet]
        [Route("CriticalIncident/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.criticalIncidentService.SeekByValue(seekValue, CriticalIncident.Informer, this.UserCredit);

			return result.ToActionResult<CriticalIncident>();
        }

        [HttpPost]
        [Route("CriticalIncident/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CriticalIncident criticalIncident)
        {
            var result = await this.criticalIncidentService.Delete(criticalIncident, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfCriticalIncidentRecognition
        [HttpPost]
        [Route("CriticalIncident/{criticalIncident_id:int}/CriticalIncidentRecognition")]
        public IActionResult CollectionOfCriticalIncidentRecognition([FromRoute(Name = "criticalIncident_id")] int id, CriticalIncidentRecognition criticalIncidentRecognition)
        {
            return this.criticalIncidentService.CollectionOfCriticalIncidentRecognition(id, criticalIncidentRecognition, this.UserCredit).ToActionResult();
        }
    }
}