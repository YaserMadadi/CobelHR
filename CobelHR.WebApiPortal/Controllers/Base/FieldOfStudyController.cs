using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class FieldOfStudyController : BaseController
    {
        public FieldOfStudyController(IFieldOfStudyService fieldOfStudyService)
        {
            this.fieldOfStudyService = fieldOfStudyService;
        }

        private IFieldOfStudyService fieldOfStudyService { get; set; }

        [HttpGet]
        [Route("FieldOfStudy/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.fieldOfStudyService.RetrieveById(id, FieldOfStudy.Informer, this.UserCredit);

			return result.ToActionResult<FieldOfStudy>();
        }

        [HttpPost]
        [Route("FieldOfStudy/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.fieldOfStudyService.RetrieveAll(FieldOfStudy.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<FieldOfStudy>();
        }
            

        
        [HttpPost]
        [Route("FieldOfStudy/Save")]
        public async Task<IActionResult> Save([FromBody] FieldOfStudy fieldOfStudy)
        {
            var result = await this.fieldOfStudyService.Save(fieldOfStudy, this.UserCredit);

			return result.ToActionResult<FieldOfStudy>();
        }

        
        [HttpPost]
        [Route("FieldOfStudy/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] FieldOfStudy fieldOfStudy)
        {
            var result = await this.fieldOfStudyService.SaveAttached(fieldOfStudy, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("FieldOfStudy/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<FieldOfStudy> fieldOfStudyList)
        {
            var result = await this.fieldOfStudyService.SaveBulk(fieldOfStudyList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("FieldOfStudy/Seek")]
        public async Task<IActionResult> Seek([FromBody] FieldOfStudy fieldOfStudy)
        {
            var result = await this.fieldOfStudyService.Seek(fieldOfStudy, this.UserCredit);

			return result.ToActionResult<FieldOfStudy>();
        }

        [HttpGet]
        [Route("FieldOfStudy/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.fieldOfStudyService.SeekByValue(seekValue, FieldOfStudy.Informer, this.UserCredit);

			return result.ToActionResult<FieldOfStudy>();
        }

        [HttpPost]
        [Route("FieldOfStudy/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] FieldOfStudy fieldOfStudy)
        {
            var result = await this.fieldOfStudyService.Delete(fieldOfStudy, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfUniversityHistory
        [HttpPost]
        [Route("FieldOfStudy/{fieldOfStudy_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "fieldOfStudy_id")] int id, UniversityHistory universityHistory)
        {
            return this.fieldOfStudyService.CollectionOfUniversityHistory(id, universityHistory, this.UserCredit).ToActionResult();
        }
    }
}