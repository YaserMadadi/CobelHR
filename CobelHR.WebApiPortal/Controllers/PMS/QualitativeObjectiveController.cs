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
    public class QualitativeObjectiveController : BaseController
    {
        public QualitativeObjectiveController(IQualitativeObjectiveService qualitativeObjectiveService)
        {
            this.qualitativeObjectiveService = qualitativeObjectiveService;
        }

        private IQualitativeObjectiveService qualitativeObjectiveService { get; set; }

        [HttpGet]
        [Route("QualitativeObjective/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.qualitativeObjectiveService.RetrieveById(id, QualitativeObjective.Informer, this.UserCredit);

			return result.ToActionResult<QualitativeObjective>();
        }

        [HttpPost]
        [Route("QualitativeObjective/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.qualitativeObjectiveService.RetrieveAll(QualitativeObjective.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<QualitativeObjective>();
        }
            

        
        [HttpPost]
        [Route("QualitativeObjective/Save")]
        public async Task<IActionResult> Save([FromBody] QualitativeObjective qualitativeObjective)
        {
            var result = await this.qualitativeObjectiveService.Save(qualitativeObjective, this.UserCredit);

			return result.ToActionResult<QualitativeObjective>();
        }

        
        [HttpPost]
        [Route("QualitativeObjective/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] QualitativeObjective qualitativeObjective)
        {
            var result = await this.qualitativeObjectiveService.SaveAttached(qualitativeObjective, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("QualitativeObjective/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<QualitativeObjective> qualitativeObjectiveList)
        {
            var result = await this.qualitativeObjectiveService.SaveBulk(qualitativeObjectiveList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("QualitativeObjective/Seek")]
        public async Task<IActionResult> Seek([FromBody] QualitativeObjective qualitativeObjective)
        {
            var result = await this.qualitativeObjectiveService.Seek(qualitativeObjective, this.UserCredit);

			return result.ToActionResult<QualitativeObjective>();
        }

        [HttpGet]
        [Route("QualitativeObjective/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.qualitativeObjectiveService.SeekByValue(seekValue, QualitativeObjective.Informer, this.UserCredit);

			return result.ToActionResult<QualitativeObjective>();
        }

        [HttpPost]
        [Route("QualitativeObjective/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] QualitativeObjective qualitativeObjective)
        {
            var result = await this.qualitativeObjectiveService.Delete(qualitativeObjective, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfQualitativeKPI
        [HttpPost]
        [Route("QualitativeObjective/{qualitativeObjective_id:int}/QualitativeKPI")]
        public IActionResult CollectionOfQualitativeKPI([FromRoute(Name = "qualitativeObjective_id")] int id, QualitativeKPI qualitativeKPI)
        {
            return this.qualitativeObjectiveService.CollectionOfQualitativeKPI(id, qualitativeKPI, this.UserCredit).ToActionResult();
        }
    }
}