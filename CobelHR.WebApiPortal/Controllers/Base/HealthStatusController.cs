using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class HealthStatusController : BaseController
    {
        public HealthStatusController(IHealthStatusService healthStatusService)
        {
            this.healthStatusService = healthStatusService;
        }

        private IHealthStatusService healthStatusService { get; set; }

        [HttpGet]
        [Route("HealthStatus/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.healthStatusService.RetrieveById(id, HealthStatus.Informer, this.UserCredit);

			return result.ToActionResult<HealthStatus>();
        }

        [HttpPost]
        [Route("HealthStatus/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.healthStatusService.RetrieveAll(HealthStatus.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<HealthStatus>();
        }
            

        
        [HttpPost]
        [Route("HealthStatus/Save")]
        public async Task<IActionResult> Save([FromBody] HealthStatus healthStatus)
        {
            var result = await this.healthStatusService.Save(healthStatus, this.UserCredit);

			return result.ToActionResult<HealthStatus>();
        }

        
        [HttpPost]
        [Route("HealthStatus/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] HealthStatus healthStatus)
        {
            var result = await this.healthStatusService.SaveAttached(healthStatus, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("HealthStatus/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<HealthStatus> healthStatusList)
        {
            var result = await this.healthStatusService.SaveBulk(healthStatusList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("HealthStatus/Seek")]
        public async Task<IActionResult> Seek([FromBody] HealthStatus healthStatus)
        {
            var result = await this.healthStatusService.Seek(healthStatus, this.UserCredit);

			return result.ToActionResult<HealthStatus>();
        }

        [HttpGet]
        [Route("HealthStatus/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.healthStatusService.SeekByValue(seekValue, HealthStatus.Informer, this.UserCredit);

			return result.ToActionResult<HealthStatus>();
        }

        [HttpPost]
        [Route("HealthStatus/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] HealthStatus healthStatus)
        {
            var result = await this.healthStatusService.Delete(healthStatus, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPerson
        [HttpPost]
        [Route("HealthStatus/{healthStatus_id:int}/Person")]
        public IActionResult CollectionOfPerson([FromRoute(Name = "healthStatus_id")] int id, Person person)
        {
            return this.healthStatusService.CollectionOfPerson(id, person, this.UserCredit).ToActionResult();
        }
    }
}