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
    public class AssessmentTypeController : BaseController
    {
        public AssessmentTypeController(IAssessmentTypeService assessmentTypeService)
        {
            this.assessmentTypeService = assessmentTypeService;
        }

        private IAssessmentTypeService assessmentTypeService { get; set; }

        [HttpGet]
        [Route("AssessmentType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.assessmentTypeService.RetrieveById(id, AssessmentType.Informer, this.UserCredit);

			return result.ToActionResult<AssessmentType>();
        }

        [HttpPost]
        [Route("AssessmentType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.assessmentTypeService.RetrieveAll(AssessmentType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AssessmentType>();
        }
            

        
        [HttpPost]
        [Route("AssessmentType/Save")]
        public async Task<IActionResult> Save([FromBody] AssessmentType assessmentType)
        {
            var result = await this.assessmentTypeService.Save(assessmentType, this.UserCredit);

			return result.ToActionResult<AssessmentType>();
        }

        
        [HttpPost]
        [Route("AssessmentType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AssessmentType assessmentType)
        {
            var result = await this.assessmentTypeService.SaveAttached(assessmentType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessmentType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AssessmentType> assessmentTypeList)
        {
            var result = await this.assessmentTypeService.SaveBulk(assessmentTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AssessmentType/Seek")]
        public async Task<IActionResult> Seek([FromBody] AssessmentType assessmentType)
        {
            var result = await this.assessmentTypeService.Seek(assessmentType, this.UserCredit);

			return result.ToActionResult<AssessmentType>();
        }

        [HttpGet]
        [Route("AssessmentType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.assessmentTypeService.SeekByValue(seekValue, AssessmentType.Informer, this.UserCredit);

			return result.ToActionResult<AssessmentType>();
        }

        [HttpPost]
        [Route("AssessmentType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AssessmentType assessmentType)
        {
            var result = await this.assessmentTypeService.Delete(assessmentType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAssessment
        [HttpPost]
        [Route("AssessmentType/{assessmentType_id:int}/Assessment")]
        public IActionResult CollectionOfAssessment([FromRoute(Name = "assessmentType_id")] int id, Assessment assessment)
        {
            return this.assessmentTypeService.CollectionOfAssessment(id, assessment, this.UserCredit).ToActionResult();
        }
    }
}