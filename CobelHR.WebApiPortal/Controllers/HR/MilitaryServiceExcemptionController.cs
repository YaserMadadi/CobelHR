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
    public class MilitaryServiceExcemptionController : BaseController
    {
        public MilitaryServiceExcemptionController(IMilitaryServiceExcemptionService militaryServiceExcemptionService)
        {
            this.militaryServiceExcemptionService = militaryServiceExcemptionService;
        }

        private IMilitaryServiceExcemptionService militaryServiceExcemptionService { get; set; }

        [HttpGet]
        [Route("MilitaryServiceExcemption/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.militaryServiceExcemptionService.RetrieveById(id, MilitaryServiceExcemption.Informer, this.UserCredit);

			return result.ToActionResult<MilitaryServiceExcemption>();
        }

        [HttpPost]
        [Route("MilitaryServiceExcemption/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.militaryServiceExcemptionService.RetrieveAll(MilitaryServiceExcemption.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<MilitaryServiceExcemption>();
        }
            

        
        [HttpPost]
        [Route("MilitaryServiceExcemption/Save")]
        public async Task<IActionResult> Save([FromBody] MilitaryServiceExcemption militaryServiceExcemption)
        {
            var result = await this.militaryServiceExcemptionService.Save(militaryServiceExcemption, this.UserCredit);

			return result.ToActionResult<MilitaryServiceExcemption>();
        }

        
        [HttpPost]
        [Route("MilitaryServiceExcemption/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] MilitaryServiceExcemption militaryServiceExcemption)
        {
            var result = await this.militaryServiceExcemptionService.SaveAttached(militaryServiceExcemption, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("MilitaryServiceExcemption/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<MilitaryServiceExcemption> militaryServiceExcemptionList)
        {
            var result = await this.militaryServiceExcemptionService.SaveBulk(militaryServiceExcemptionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("MilitaryServiceExcemption/Seek")]
        public async Task<IActionResult> Seek([FromBody] MilitaryServiceExcemption militaryServiceExcemption)
        {
            var result = await this.militaryServiceExcemptionService.Seek(militaryServiceExcemption, this.UserCredit);

			return result.ToActionResult<MilitaryServiceExcemption>();
        }

        [HttpGet]
        [Route("MilitaryServiceExcemption/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.militaryServiceExcemptionService.SeekByValue(seekValue, MilitaryServiceExcemption.Informer, this.UserCredit);

			return result.ToActionResult<MilitaryServiceExcemption>();
        }

        [HttpPost]
        [Route("MilitaryServiceExcemption/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MilitaryServiceExcemption militaryServiceExcemption)
        {
            var result = await this.militaryServiceExcemptionService.Delete(militaryServiceExcemption, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}