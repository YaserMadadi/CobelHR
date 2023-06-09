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
    public class QualitativeKPIController : BaseController
    {
        public QualitativeKPIController(IQualitativeKPIService qualitativeKPIService)
        {
            this.qualitativeKPIService = qualitativeKPIService;
        }

        private IQualitativeKPIService qualitativeKPIService { get; set; }

        [HttpGet]
        [Route("QualitativeKPI/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.qualitativeKPIService.RetrieveById(id, QualitativeKPI.Informer, this.UserCredit);

			return result.ToActionResult<QualitativeKPI>();
        }

        [HttpPost]
        [Route("QualitativeKPI/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.qualitativeKPIService.RetrieveAll(QualitativeKPI.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<QualitativeKPI>();
        }
            

        
        [HttpPost]
        [Route("QualitativeKPI/Save")]
        public async Task<IActionResult> Save([FromBody] QualitativeKPI qualitativeKPI)
        {
            var result = await this.qualitativeKPIService.Save(qualitativeKPI, this.UserCredit);

			return result.ToActionResult<QualitativeKPI>();
        }

        
        [HttpPost]
        [Route("QualitativeKPI/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] QualitativeKPI qualitativeKPI)
        {
            var result = await this.qualitativeKPIService.SaveAttached(qualitativeKPI, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("QualitativeKPI/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<QualitativeKPI> qualitativeKPIList)
        {
            var result = await this.qualitativeKPIService.SaveBulk(qualitativeKPIList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("QualitativeKPI/Seek")]
        public async Task<IActionResult> Seek([FromBody] QualitativeKPI qualitativeKPI)
        {
            var result = await this.qualitativeKPIService.Seek(qualitativeKPI, this.UserCredit);

			return result.ToActionResult<QualitativeKPI>();
        }

        [HttpGet]
        [Route("QualitativeKPI/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.qualitativeKPIService.SeekByValue(seekValue, QualitativeKPI.Informer, this.UserCredit);

			return result.ToActionResult<QualitativeKPI>();
        }

        [HttpPost]
        [Route("QualitativeKPI/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] QualitativeKPI qualitativeKPI)
        {
            var result = await this.qualitativeKPIService.Delete(qualitativeKPI, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfQualitativeAppraise
        [HttpPost]
        [Route("QualitativeKPI/{qualitativeKPI_id:int}/QualitativeAppraise")]
        public IActionResult CollectionOfQualitativeAppraise([FromRoute(Name = "qualitativeKPI_id")] int id, QualitativeAppraise qualitativeAppraise)
        {
            return this.qualitativeKPIService.CollectionOfQualitativeAppraise(id, qualitativeAppraise, this.UserCredit).ToActionResult();
        }
    }
}