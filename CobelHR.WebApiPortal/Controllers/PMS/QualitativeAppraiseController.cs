using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class QualitativeAppraiseController : BaseController
    {
        public QualitativeAppraiseController(IQualitativeAppraiseService qualitativeAppraiseService)
        {
            this.qualitativeAppraiseService = qualitativeAppraiseService;
        }

        private IQualitativeAppraiseService qualitativeAppraiseService { get; set; }

        [HttpGet]
        [Route("QualitativeAppraise/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.qualitativeAppraiseService.RetrieveById(id, QualitativeAppraise.Informer, this.UserCredit);

			return result.ToActionResult<QualitativeAppraise>();
        }

        [HttpPost]
        [Route("QualitativeAppraise/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.qualitativeAppraiseService.RetrieveAll(QualitativeAppraise.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<QualitativeAppraise>();
        }
            

        
        [HttpPost]
        [Route("QualitativeAppraise/Save")]
        public async Task<IActionResult> Save([FromBody] QualitativeAppraise qualitativeAppraise)
        {
            var result = await this.qualitativeAppraiseService.Save(qualitativeAppraise, this.UserCredit);

			return result.ToActionResult<QualitativeAppraise>();
        }

        
        [HttpPost]
        [Route("QualitativeAppraise/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] QualitativeAppraise qualitativeAppraise)
        {
            var result = await this.qualitativeAppraiseService.SaveAttached(qualitativeAppraise, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("QualitativeAppraise/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<QualitativeAppraise> qualitativeAppraiseList)
        {
            var result = await this.qualitativeAppraiseService.SaveBulk(qualitativeAppraiseList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("QualitativeAppraise/Seek")]
        public async Task<IActionResult> Seek([FromBody] QualitativeAppraise qualitativeAppraise)
        {
            var result = await this.qualitativeAppraiseService.Seek(qualitativeAppraise, this.UserCredit);

			return result.ToActionResult<QualitativeAppraise>();
        }

        [HttpGet]
        [Route("QualitativeAppraise/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.qualitativeAppraiseService.SeekByValue(seekValue, QualitativeAppraise.Informer, this.UserCredit);

			return result.ToActionResult<QualitativeAppraise>();
        }

        [HttpPost]
        [Route("QualitativeAppraise/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] QualitativeAppraise qualitativeAppraise)
        {
            var result = await this.qualitativeAppraiseService.Delete(qualitativeAppraise, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}