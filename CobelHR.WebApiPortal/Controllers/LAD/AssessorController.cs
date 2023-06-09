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
    public class AssessorController : BaseController
    {
        public AssessorController(IAssessorService assessorService)
        {
            this.assessorService = assessorService;
        }

        private IAssessorService assessorService { get; set; }

        [HttpGet]
        [Route("Assessor/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.assessorService.RetrieveById(id, Assessor.Informer, this.UserCredit);

			return result.ToActionResult<Assessor>();
        }

        [HttpPost]
        [Route("Assessor/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.assessorService.RetrieveAll(Assessor.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Assessor>();
        }
            

        
        [HttpPost]
        [Route("Assessor/Save")]
        public async Task<IActionResult> Save([FromBody] Assessor assessor)
        {
            var result = await this.assessorService.Save(assessor, this.UserCredit);

			return result.ToActionResult<Assessor>();
        }

        
        [HttpPost]
        [Route("Assessor/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Assessor assessor)
        {
            var result = await this.assessorService.SaveAttached(assessor, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Assessor/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Assessor> assessorList)
        {
            var result = await this.assessorService.SaveBulk(assessorList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Assessor/Seek")]
        public async Task<IActionResult> Seek([FromBody] Assessor assessor)
        {
            var result = await this.assessorService.Seek(assessor, this.UserCredit);

			return result.ToActionResult<Assessor>();
        }

        [HttpGet]
        [Route("Assessor/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.assessorService.SeekByValue(seekValue, Assessor.Informer, this.UserCredit);

			return result.ToActionResult<Assessor>();
        }

        [HttpPost]
        [Route("Assessor/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Assessor assessor)
        {
            var result = await this.assessorService.Delete(assessor, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAssessment
        [HttpPost]
        [Route("Assessor/{assessor_id:int}/Assessment")]
        public IActionResult CollectionOfAssessment([FromRoute(Name = "assessor_id")] int id, Assessment assessment)
        {
            return this.assessorService.CollectionOfAssessment(id, assessment, this.UserCredit).ToActionResult();
        }

		// CollectionOfAssessorConnectionLine
        [HttpPost]
        [Route("Assessor/{assessor_id:int}/AssessorConnectionLine")]
        public IActionResult CollectionOfAssessorConnectionLine([FromRoute(Name = "assessor_id")] int id, AssessorConnectionLine assessorConnectionLine)
        {
            return this.assessorService.CollectionOfAssessorConnectionLine(id, assessorConnectionLine, this.UserCredit).ToActionResult();
        }
    }
}