using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Pharma.Abstract;
using CobelHR.Entities.PMS.Pharma;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS.Pharma
{
    [Route("api/PMS.Pharma")]
    public class KPIController : BaseController
    {
        public KPIController(IKPIService kpiService)
        {
            this.kpiService = kpiService;
        }

        private IKPIService kpiService { get; set; }

        [HttpGet]
        [Route("KPI/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.kpiService.RetrieveById(id, KPI.Informer, this.UserCredit);

			return result.ToActionResult<KPI>();
        }

        [HttpPost]
        [Route("KPI/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.kpiService.RetrieveAll(KPI.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<KPI>();
        }
            

        
        [HttpPost]
        [Route("KPI/Save")]
        public async Task<IActionResult> Save([FromBody] KPI kpi)
        {
            var result = await this.kpiService.Save(kpi, this.UserCredit);

			return result.ToActionResult<KPI>();
        }

        
        [HttpPost]
        [Route("KPI/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] KPI kpi)
        {
            var result = await this.kpiService.SaveAttached(kpi, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("KPI/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<KPI> kpiList)
        {
            var result = await this.kpiService.SaveBulk(kpiList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("KPI/Seek")]
        public async Task<IActionResult> Seek([FromBody] KPI kpi)
        {
            var result = await this.kpiService.Seek(kpi, this.UserCredit);

			return result.ToActionResult<KPI>();
        }

        [HttpGet]
        [Route("KPI/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.kpiService.SeekByValue(seekValue, KPI.Informer, this.UserCredit);

			return result.ToActionResult<KPI>();
        }

        [HttpPost]
        [Route("KPI/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] KPI kpi)
        {
            var result = await this.kpiService.Delete(kpi, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAppraise
        [HttpPost]
        [Route("KPI/{kpi_id:int}/Appraise")]
        public IActionResult CollectionOfAppraise([FromRoute(Name = "kpi_id")] int id, Appraise Appraise)
        {
            return this.kpiService.CollectionOfAppraise(id, Appraise, this.UserCredit).ToActionResult();
        }
    }
}