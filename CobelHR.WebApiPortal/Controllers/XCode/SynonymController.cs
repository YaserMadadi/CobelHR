using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.XCode.Abstract;
using CobelHR.Entities.XCode;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.XCode
{
    [Route("api/XCode")]
    public class SynonymController : BaseController
    {
        public SynonymController(ISynonymService synonymService)
        {
            this.synonymService = synonymService;
        }

        private ISynonymService synonymService { get; set; }

        [HttpGet]
        [Route("Synonym/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.synonymService.RetrieveById(id, Synonym.Informer, this.UserCredit);

			return result.ToActionResult<Synonym>();
        }

        [HttpPost]
        [Route("Synonym/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.synonymService.RetrieveAll(Synonym.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Synonym>();
        }
            

        
        [HttpPost]
        [Route("Synonym/Save")]
        public async Task<IActionResult> Save([FromBody] Synonym synonym)
        {
            var result = await this.synonymService.Save(synonym, this.UserCredit);

			return result.ToActionResult<Synonym>();
        }

        
        [HttpPost]
        [Route("Synonym/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Synonym synonym)
        {
            var result = await this.synonymService.SaveAttached(synonym, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Synonym/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Synonym> synonymList)
        {
            var result = await this.synonymService.SaveBulk(synonymList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Synonym/Seek")]
        public async Task<IActionResult> Seek([FromBody] Synonym synonym)
        {
            var result = await this.synonymService.Seek(synonym, this.UserCredit);

			return result.ToActionResult<Synonym>();
        }

        [HttpGet]
        [Route("Synonym/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.synonymService.SeekByValue(seekValue, Synonym.Informer, this.UserCredit);

			return result.ToActionResult<Synonym>();
        }

        [HttpPost]
        [Route("Synonym/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Synonym synonym)
        {
            var result = await this.synonymService.Delete(synonym, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}