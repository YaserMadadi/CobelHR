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
    public class MilitaryServiceStatusController : BaseController
    {
        public MilitaryServiceStatusController(IMilitaryServiceStatusService militaryServiceStatusService)
        {
            this.militaryServiceStatusService = militaryServiceStatusService;
        }

        private IMilitaryServiceStatusService militaryServiceStatusService { get; set; }

        [HttpGet]
        [Route("MilitaryServiceStatus/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.militaryServiceStatusService.RetrieveById(id, MilitaryServiceStatus.Informer, this.UserCredit);

			return result.ToActionResult<MilitaryServiceStatus>();
        }

        [HttpPost]
        [Route("MilitaryServiceStatus/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.militaryServiceStatusService.RetrieveAll(MilitaryServiceStatus.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<MilitaryServiceStatus>();
        }
            

        
        [HttpPost]
        [Route("MilitaryServiceStatus/Save")]
        public async Task<IActionResult> Save([FromBody] MilitaryServiceStatus militaryServiceStatus)
        {
            var result = await this.militaryServiceStatusService.Save(militaryServiceStatus, this.UserCredit);

			return result.ToActionResult<MilitaryServiceStatus>();
        }

        
        [HttpPost]
        [Route("MilitaryServiceStatus/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] MilitaryServiceStatus militaryServiceStatus)
        {
            var result = await this.militaryServiceStatusService.SaveAttached(militaryServiceStatus, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("MilitaryServiceStatus/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<MilitaryServiceStatus> militaryServiceStatusList)
        {
            var result = await this.militaryServiceStatusService.SaveBulk(militaryServiceStatusList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("MilitaryServiceStatus/Seek")]
        public async Task<IActionResult> Seek([FromBody] MilitaryServiceStatus militaryServiceStatus)
        {
            var result = await this.militaryServiceStatusService.Seek(militaryServiceStatus, this.UserCredit);

			return result.ToActionResult<MilitaryServiceStatus>();
        }

        [HttpGet]
        [Route("MilitaryServiceStatus/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.militaryServiceStatusService.SeekByValue(seekValue, MilitaryServiceStatus.Informer, this.UserCredit);

			return result.ToActionResult<MilitaryServiceStatus>();
        }

        [HttpPost]
        [Route("MilitaryServiceStatus/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MilitaryServiceStatus militaryServiceStatus)
        {
            var result = await this.militaryServiceStatusService.Delete(militaryServiceStatus, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfMilitaryService
        [HttpPost]
        [Route("MilitaryServiceStatus/{militaryServiceStatus_id:int}/MilitaryService")]
        public IActionResult CollectionOfMilitaryService([FromRoute(Name = "militaryServiceStatus_id")] int id, MilitaryService militaryService)
        {
            return this.militaryServiceStatusService.CollectionOfMilitaryService(id, militaryService, this.UserCredit).ToActionResult();
        }
    }
}