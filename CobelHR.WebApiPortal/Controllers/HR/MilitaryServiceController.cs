using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class MilitaryServiceController : BaseController
    {
        public MilitaryServiceController(IMilitaryServiceService militaryServiceService)
        {
            this.militaryServiceService = militaryServiceService;
        }

        private IMilitaryServiceService militaryServiceService { get; set; }

        [HttpGet]
        [Route("MilitaryService/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.militaryServiceService.RetrieveById(id, MilitaryService.Informer, this.UserCredit);

			return result.ToActionResult<MilitaryService>();
        }

        [HttpPost]
        [Route("MilitaryService/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.militaryServiceService.RetrieveAll(MilitaryService.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<MilitaryService>();
        }
            

        
        [HttpPost]
        [Route("MilitaryService/Save")]
        public async Task<IActionResult> Save([FromBody] MilitaryService militaryService)
        {
            var result = await this.militaryServiceService.Save(militaryService, this.UserCredit);

			return result.ToActionResult<MilitaryService>();
        }

        
        [HttpPost]
        [Route("MilitaryService/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] MilitaryService militaryService)
        {
            var result = await this.militaryServiceService.SaveAttached(militaryService, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("MilitaryService/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<MilitaryService> militaryServiceList)
        {
            var result = await this.militaryServiceService.SaveBulk(militaryServiceList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("MilitaryService/Seek")]
        public async Task<IActionResult> Seek([FromBody] MilitaryService militaryService)
        {
            var result = await this.militaryServiceService.Seek(militaryService, this.UserCredit);

			return result.ToActionResult<MilitaryService>();
        }

        [HttpGet]
        [Route("MilitaryService/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.militaryServiceService.SeekByValue(seekValue, MilitaryService.Informer, this.UserCredit);

			return result.ToActionResult<MilitaryService>();
        }

        [HttpPost]
        [Route("MilitaryService/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MilitaryService militaryService)
        {
            var result = await this.militaryServiceService.Delete(militaryService, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfMilitaryServiceExcemption
        [HttpPost]
        [Route("MilitaryService/{militaryService_id:int}/MilitaryServiceExcemption")]
        public IActionResult CollectionOfMilitaryServiceExcemption([FromRoute(Name = "militaryService_id")] int id, MilitaryServiceExcemption militaryServiceExcemption)
        {
            return this.militaryServiceService.CollectionOfMilitaryServiceExcemption(id, militaryServiceExcemption, this.UserCredit).ToActionResult();
        }

		// CollectionOfMilitaryServiceInclusive
        [HttpPost]
        [Route("MilitaryService/{militaryService_id:int}/MilitaryServiceInclusive")]
        public IActionResult CollectionOfMilitaryServiceInclusive([FromRoute(Name = "militaryService_id")] int id, MilitaryServiceInclusive militaryServiceInclusive)
        {
            return this.militaryServiceService.CollectionOfMilitaryServiceInclusive(id, militaryServiceInclusive, this.UserCredit).ToActionResult();
        }
    }
}