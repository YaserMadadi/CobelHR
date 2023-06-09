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
    public class ConclusionTypeController : BaseController
    {
        public ConclusionTypeController(IConclusionTypeService conclusionTypeService)
        {
            this.conclusionTypeService = conclusionTypeService;
        }

        private IConclusionTypeService conclusionTypeService { get; set; }

        [HttpGet]
        [Route("ConclusionType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.conclusionTypeService.RetrieveById(id, ConclusionType.Informer, this.UserCredit);

			return result.ToActionResult<ConclusionType>();
        }

        [HttpPost]
        [Route("ConclusionType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.conclusionTypeService.RetrieveAll(ConclusionType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ConclusionType>();
        }
            

        
        [HttpPost]
        [Route("ConclusionType/Save")]
        public async Task<IActionResult> Save([FromBody] ConclusionType conclusionType)
        {
            var result = await this.conclusionTypeService.Save(conclusionType, this.UserCredit);

			return result.ToActionResult<ConclusionType>();
        }

        
        [HttpPost]
        [Route("ConclusionType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ConclusionType conclusionType)
        {
            var result = await this.conclusionTypeService.SaveAttached(conclusionType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ConclusionType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ConclusionType> conclusionTypeList)
        {
            var result = await this.conclusionTypeService.SaveBulk(conclusionTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ConclusionType/Seek")]
        public async Task<IActionResult> Seek([FromBody] ConclusionType conclusionType)
        {
            var result = await this.conclusionTypeService.Seek(conclusionType, this.UserCredit);

			return result.ToActionResult<ConclusionType>();
        }

        [HttpGet]
        [Route("ConclusionType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.conclusionTypeService.SeekByValue(seekValue, ConclusionType.Informer, this.UserCredit);

			return result.ToActionResult<ConclusionType>();
        }

        [HttpPost]
        [Route("ConclusionType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ConclusionType conclusionType)
        {
            var result = await this.conclusionTypeService.Delete(conclusionType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfConclusion
        [HttpPost]
        [Route("ConclusionType/{conclusionType_id:int}/Conclusion")]
        public IActionResult CollectionOfConclusion([FromRoute(Name = "conclusionType_id")] int id, Conclusion conclusion)
        {
            return this.conclusionTypeService.CollectionOfConclusion(id, conclusion, this.UserCredit).ToActionResult();
        }
    }
}