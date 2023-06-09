using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Core.Abstract;
using CobelHR.Entities.Core;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Core
{
    [Route("api/Core")]
    public class ImpersonateController : BaseController
    {
        public ImpersonateController(IImpersonateService impersonateService)
        {
            this.impersonateService = impersonateService;
        }

        private IImpersonateService impersonateService { get; set; }

        [HttpGet]
        [Route("Impersonate/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.impersonateService.RetrieveById(id, Impersonate.Informer, this.UserCredit);

			return result.ToActionResult<Impersonate>();
        }

        [HttpPost]
        [Route("Impersonate/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.impersonateService.RetrieveAll(Impersonate.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Impersonate>();
        }
            

        
        [HttpPost]
        [Route("Impersonate/Save")]
        public async Task<IActionResult> Save([FromBody] Impersonate impersonate)
        {
            var result = await this.impersonateService.Save(impersonate, this.UserCredit);

			return result.ToActionResult<Impersonate>();
        }

        
        [HttpPost]
        [Route("Impersonate/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Impersonate impersonate)
        {
            var result = await this.impersonateService.SaveAttached(impersonate, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Impersonate/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Impersonate> impersonateList)
        {
            var result = await this.impersonateService.SaveBulk(impersonateList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Impersonate/Seek")]
        public async Task<IActionResult> Seek([FromBody] Impersonate impersonate)
        {
            var result = await this.impersonateService.Seek(impersonate, this.UserCredit);

			return result.ToActionResult<Impersonate>();
        }

        [HttpGet]
        [Route("Impersonate/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.impersonateService.SeekByValue(seekValue, Impersonate.Informer, this.UserCredit);

			return result.ToActionResult<Impersonate>();
        }

        [HttpPost]
        [Route("Impersonate/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Impersonate impersonate)
        {
            var result = await this.impersonateService.Delete(impersonate, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}