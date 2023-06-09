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
    public class CriticalIncidentTypeController : BaseController
    {
        public CriticalIncidentTypeController(ICriticalIncidentTypeService criticalIncidentTypeService)
        {
            this.criticalIncidentTypeService = criticalIncidentTypeService;
        }

        private ICriticalIncidentTypeService criticalIncidentTypeService { get; set; }

        [HttpGet]
        [Route("CriticalIncidentType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.criticalIncidentTypeService.RetrieveById(id, CriticalIncidentType.Informer, this.UserCredit);

			return result.ToActionResult<CriticalIncidentType>();
        }

        [HttpPost]
        [Route("CriticalIncidentType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.criticalIncidentTypeService.RetrieveAll(CriticalIncidentType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CriticalIncidentType>();
        }
            

        
        [HttpPost]
        [Route("CriticalIncidentType/Save")]
        public async Task<IActionResult> Save([FromBody] CriticalIncidentType criticalIncidentType)
        {
            var result = await this.criticalIncidentTypeService.Save(criticalIncidentType, this.UserCredit);

			return result.ToActionResult<CriticalIncidentType>();
        }

        
        [HttpPost]
        [Route("CriticalIncidentType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CriticalIncidentType criticalIncidentType)
        {
            var result = await this.criticalIncidentTypeService.SaveAttached(criticalIncidentType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CriticalIncidentType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CriticalIncidentType> criticalIncidentTypeList)
        {
            var result = await this.criticalIncidentTypeService.SaveBulk(criticalIncidentTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CriticalIncidentType/Seek")]
        public async Task<IActionResult> Seek([FromBody] CriticalIncidentType criticalIncidentType)
        {
            var result = await this.criticalIncidentTypeService.Seek(criticalIncidentType, this.UserCredit);

			return result.ToActionResult<CriticalIncidentType>();
        }

        [HttpGet]
        [Route("CriticalIncidentType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.criticalIncidentTypeService.SeekByValue(seekValue, CriticalIncidentType.Informer, this.UserCredit);

			return result.ToActionResult<CriticalIncidentType>();
        }

        [HttpPost]
        [Route("CriticalIncidentType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CriticalIncidentType criticalIncidentType)
        {
            var result = await this.criticalIncidentTypeService.Delete(criticalIncidentType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfCriticalIncident
        [HttpPost]
        [Route("CriticalIncidentType/{criticalIncidentType_id:int}/CriticalIncident")]
        public IActionResult CollectionOfCriticalIncident([FromRoute(Name = "criticalIncidentType_id")] int id, CriticalIncident criticalIncident)
        {
            return this.criticalIncidentTypeService.CollectionOfCriticalIncident(id, criticalIncident, this.UserCredit).ToActionResult();
        }
    }
}