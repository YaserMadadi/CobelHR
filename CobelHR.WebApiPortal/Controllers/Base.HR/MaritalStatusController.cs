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
    public class MaritalStatusController : BaseController
    {
        public MaritalStatusController(IMaritalStatusService maritalStatusService)
        {
            this.maritalStatusService = maritalStatusService;
        }

        private IMaritalStatusService maritalStatusService { get; set; }

        [HttpGet]
        [Route("MaritalStatus/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.maritalStatusService.RetrieveById(id, MaritalStatus.Informer, this.UserCredit);

			return result.ToActionResult<MaritalStatus>();
        }

        [HttpPost]
        [Route("MaritalStatus/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.maritalStatusService.RetrieveAll(MaritalStatus.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<MaritalStatus>();
        }
            

        
        [HttpPost]
        [Route("MaritalStatus/Save")]
        public async Task<IActionResult> Save([FromBody] MaritalStatus maritalStatus)
        {
            var result = await this.maritalStatusService.Save(maritalStatus, this.UserCredit);

			return result.ToActionResult<MaritalStatus>();
        }

        
        [HttpPost]
        [Route("MaritalStatus/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] MaritalStatus maritalStatus)
        {
            var result = await this.maritalStatusService.SaveAttached(maritalStatus, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("MaritalStatus/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<MaritalStatus> maritalStatusList)
        {
            var result = await this.maritalStatusService.SaveBulk(maritalStatusList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("MaritalStatus/Seek")]
        public async Task<IActionResult> Seek([FromBody] MaritalStatus maritalStatus)
        {
            var result = await this.maritalStatusService.Seek(maritalStatus, this.UserCredit);

			return result.ToActionResult<MaritalStatus>();
        }

        [HttpGet]
        [Route("MaritalStatus/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.maritalStatusService.SeekByValue(seekValue, MaritalStatus.Informer, this.UserCredit);

			return result.ToActionResult<MaritalStatus>();
        }

        [HttpPost]
        [Route("MaritalStatus/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MaritalStatus maritalStatus)
        {
            var result = await this.maritalStatusService.Delete(maritalStatus, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPerson
        [HttpPost]
        [Route("MaritalStatus/{maritalStatus_id:int}/Person")]
        public IActionResult CollectionOfPerson([FromRoute(Name = "maritalStatus_id")] int id, Person person)
        {
            return this.maritalStatusService.CollectionOfPerson(id, person, this.UserCredit).ToActionResult();
        }
    }
}