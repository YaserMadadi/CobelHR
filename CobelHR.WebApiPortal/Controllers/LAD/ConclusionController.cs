using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.LAD.Abstract;
using CobelHR.Entities.LAD;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.LAD
{
    [Route("api/LAD")]
    public class ConclusionController : BaseController
    {
        public ConclusionController(IConclusionService conclusionService)
        {
            this.conclusionService = conclusionService;
        }

        private IConclusionService conclusionService { get; set; }

        [HttpGet]
        [Route("Conclusion/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.conclusionService.RetrieveById(id, Conclusion.Informer, this.UserCredit);

			return result.ToActionResult<Conclusion>();
        }

        [HttpPost]
        [Route("Conclusion/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.conclusionService.RetrieveAll(Conclusion.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Conclusion>();
        }
            

        
        [HttpPost]
        [Route("Conclusion/Save")]
        public async Task<IActionResult> Save([FromBody] Conclusion conclusion)
        {
            var result = await this.conclusionService.Save(conclusion, this.UserCredit);

			return result.ToActionResult<Conclusion>();
        }

        
        [HttpPost]
        [Route("Conclusion/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Conclusion conclusion)
        {
            var result = await this.conclusionService.SaveAttached(conclusion, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Conclusion/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Conclusion> conclusionList)
        {
            var result = await this.conclusionService.SaveBulk(conclusionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Conclusion/Seek")]
        public async Task<IActionResult> Seek([FromBody] Conclusion conclusion)
        {
            var result = await this.conclusionService.Seek(conclusion, this.UserCredit);

			return result.ToActionResult<Conclusion>();
        }

        [HttpGet]
        [Route("Conclusion/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.conclusionService.SeekByValue(seekValue, Conclusion.Informer, this.UserCredit);

			return result.ToActionResult<Conclusion>();
        }

        [HttpPost]
        [Route("Conclusion/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Conclusion conclusion)
        {
            var result = await this.conclusionService.Delete(conclusion, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}