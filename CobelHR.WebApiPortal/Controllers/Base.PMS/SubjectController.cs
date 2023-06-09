using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class SubjectController : BaseController
    {
        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        private ISubjectService subjectService { get; set; }

        [HttpGet]
        [Route("Subject/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.subjectService.RetrieveById(id, Subject.Informer, this.UserCredit);

			return result.ToActionResult<Subject>();
        }

        [HttpPost]
        [Route("Subject/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.subjectService.RetrieveAll(Subject.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Subject>();
        }
            

        
        [HttpPost]
        [Route("Subject/Save")]
        public async Task<IActionResult> Save([FromBody] Subject subject)
        {
            var result = await this.subjectService.Save(subject, this.UserCredit);

			return result.ToActionResult<Subject>();
        }

        
        [HttpPost]
        [Route("Subject/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Subject subject)
        {
            var result = await this.subjectService.SaveAttached(subject, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Subject/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Subject> subjectList)
        {
            var result = await this.subjectService.SaveBulk(subjectList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Subject/Seek")]
        public async Task<IActionResult> Seek([FromBody] Subject subject)
        {
            var result = await this.subjectService.Seek(subject, this.UserCredit);

			return result.ToActionResult<Subject>();
        }

        [HttpGet]
        [Route("Subject/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.subjectService.SeekByValue(seekValue, Subject.Informer, this.UserCredit);

			return result.ToActionResult<Subject>();
        }

        [HttpPost]
        [Route("Subject/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Subject subject)
        {
            var result = await this.subjectService.Delete(subject, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfIndividualDevelopmentPlan
        [HttpPost]
        [Route("Subject/{subject_id:int}/IndividualDevelopmentPlan")]
        public IActionResult CollectionOfIndividualDevelopmentPlan([FromRoute(Name = "subject_id")] int id, IndividualDevelopmentPlan individualDevelopmentPlan)
        {
            return this.subjectService.CollectionOfIndividualDevelopmentPlan(id, individualDevelopmentPlan, this.UserCredit).ToActionResult();
        }
    }
}