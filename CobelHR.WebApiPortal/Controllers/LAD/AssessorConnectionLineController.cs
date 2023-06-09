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
    public class AssessorConnectionLineController : BaseController
    {
        public AssessorConnectionLineController(IAssessorConnectionLineService assessorConnectionLineService)
        {
            this.assessorConnectionLineService = assessorConnectionLineService;
        }

        private IAssessorConnectionLineService assessorConnectionLineService { get; set; }

        [HttpGet]
        [Route("AssessorConnectionLine/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.assessorConnectionLineService.RetrieveById(id, AssessorConnectionLine.Informer, this.UserCredit);

			return result.ToActionResult<AssessorConnectionLine>();
        }

        [HttpPost]
        [Route("AssessorConnectionLine/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.assessorConnectionLineService.RetrieveAll(AssessorConnectionLine.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AssessorConnectionLine>();
        }
            

        
        [HttpPost]
        [Route("AssessorConnectionLine/Save")]
        public async Task<IActionResult> Save([FromBody] AssessorConnectionLine assessorConnectionLine)
        {
            var result = await this.assessorConnectionLineService.Save(assessorConnectionLine, this.UserCredit);

			return result.ToActionResult<AssessorConnectionLine>();
        }

        
        [HttpPost]
        [Route("AssessorConnectionLine/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AssessorConnectionLine assessorConnectionLine)
        {
            var result = await this.assessorConnectionLineService.SaveAttached(assessorConnectionLine, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessorConnectionLine/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AssessorConnectionLine> assessorConnectionLineList)
        {
            var result = await this.assessorConnectionLineService.SaveBulk(assessorConnectionLineList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AssessorConnectionLine/Seek")]
        public async Task<IActionResult> Seek([FromBody] AssessorConnectionLine assessorConnectionLine)
        {
            var result = await this.assessorConnectionLineService.Seek(assessorConnectionLine, this.UserCredit);

			return result.ToActionResult<AssessorConnectionLine>();
        }

        [HttpGet]
        [Route("AssessorConnectionLine/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.assessorConnectionLineService.SeekByValue(seekValue, AssessorConnectionLine.Informer, this.UserCredit);

			return result.ToActionResult<AssessorConnectionLine>();
        }

        [HttpPost]
        [Route("AssessorConnectionLine/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AssessorConnectionLine assessorConnectionLine)
        {
            var result = await this.assessorConnectionLineService.Delete(assessorConnectionLine, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}