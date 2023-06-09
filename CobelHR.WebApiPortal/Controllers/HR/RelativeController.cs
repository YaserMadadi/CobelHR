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
    public class RelativeController : BaseController
    {
        public RelativeController(IRelativeService relativeService)
        {
            this.relativeService = relativeService;
        }

        private IRelativeService relativeService { get; set; }

        [HttpGet]
        [Route("Relative/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.relativeService.RetrieveById(id, Relative.Informer, this.UserCredit);

			return result.ToActionResult<Relative>();
        }

        [HttpPost]
        [Route("Relative/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.relativeService.RetrieveAll(Relative.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Relative>();
        }
            

        
        [HttpPost]
        [Route("Relative/Save")]
        public async Task<IActionResult> Save([FromBody] Relative relative)
        {
            var result = await this.relativeService.Save(relative, this.UserCredit);

			return result.ToActionResult<Relative>();
        }

        
        [HttpPost]
        [Route("Relative/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Relative relative)
        {
            var result = await this.relativeService.SaveAttached(relative, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Relative/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Relative> relativeList)
        {
            var result = await this.relativeService.SaveBulk(relativeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Relative/Seek")]
        public async Task<IActionResult> Seek([FromBody] Relative relative)
        {
            var result = await this.relativeService.Seek(relative, this.UserCredit);

			return result.ToActionResult<Relative>();
        }

        [HttpGet]
        [Route("Relative/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.relativeService.SeekByValue(seekValue, Relative.Informer, this.UserCredit);

			return result.ToActionResult<Relative>();
        }

        [HttpPost]
        [Route("Relative/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Relative relative)
        {
            var result = await this.relativeService.Delete(relative, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}