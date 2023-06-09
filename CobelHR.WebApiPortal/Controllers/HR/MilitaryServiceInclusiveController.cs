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
    public class MilitaryServiceInclusiveController : BaseController
    {
        public MilitaryServiceInclusiveController(IMilitaryServiceInclusiveService militaryServiceInclusiveService)
        {
            this.militaryServiceInclusiveService = militaryServiceInclusiveService;
        }

        private IMilitaryServiceInclusiveService militaryServiceInclusiveService { get; set; }

        [HttpGet]
        [Route("MilitaryServiceInclusive/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.militaryServiceInclusiveService.RetrieveById(id, MilitaryServiceInclusive.Informer, this.UserCredit);

			return result.ToActionResult<MilitaryServiceInclusive>();
        }

        [HttpPost]
        [Route("MilitaryServiceInclusive/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.militaryServiceInclusiveService.RetrieveAll(MilitaryServiceInclusive.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<MilitaryServiceInclusive>();
        }
            

        
        [HttpPost]
        [Route("MilitaryServiceInclusive/Save")]
        public async Task<IActionResult> Save([FromBody] MilitaryServiceInclusive militaryServiceInclusive)
        {
            var result = await this.militaryServiceInclusiveService.Save(militaryServiceInclusive, this.UserCredit);

			return result.ToActionResult<MilitaryServiceInclusive>();
        }

        
        [HttpPost]
        [Route("MilitaryServiceInclusive/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] MilitaryServiceInclusive militaryServiceInclusive)
        {
            var result = await this.militaryServiceInclusiveService.SaveAttached(militaryServiceInclusive, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("MilitaryServiceInclusive/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<MilitaryServiceInclusive> militaryServiceInclusiveList)
        {
            var result = await this.militaryServiceInclusiveService.SaveBulk(militaryServiceInclusiveList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("MilitaryServiceInclusive/Seek")]
        public async Task<IActionResult> Seek([FromBody] MilitaryServiceInclusive militaryServiceInclusive)
        {
            var result = await this.militaryServiceInclusiveService.Seek(militaryServiceInclusive, this.UserCredit);

			return result.ToActionResult<MilitaryServiceInclusive>();
        }

        [HttpGet]
        [Route("MilitaryServiceInclusive/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.militaryServiceInclusiveService.SeekByValue(seekValue, MilitaryServiceInclusive.Informer, this.UserCredit);

			return result.ToActionResult<MilitaryServiceInclusive>();
        }

        [HttpPost]
        [Route("MilitaryServiceInclusive/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MilitaryServiceInclusive militaryServiceInclusive)
        {
            var result = await this.militaryServiceInclusiveService.Delete(militaryServiceInclusive, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}