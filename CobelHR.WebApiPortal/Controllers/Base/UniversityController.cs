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
    public class UniversityController : BaseController
    {
        public UniversityController(IUniversityService universityService)
        {
            this.universityService = universityService;
        }

        private IUniversityService universityService { get; set; }

        [HttpGet]
        [Route("University/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.universityService.RetrieveById(id, University.Informer, this.UserCredit);

			return result.ToActionResult<University>();
        }

        [HttpPost]
        [Route("University/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.universityService.RetrieveAll(University.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<University>();
        }
            

        
        [HttpPost]
        [Route("University/Save")]
        public async Task<IActionResult> Save([FromBody] University university)
        {
            var result = await this.universityService.Save(university, this.UserCredit);

			return result.ToActionResult<University>();
        }

        
        [HttpPost]
        [Route("University/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] University university)
        {
            var result = await this.universityService.SaveAttached(university, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("University/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<University> universityList)
        {
            var result = await this.universityService.SaveBulk(universityList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("University/Seek")]
        public async Task<IActionResult> Seek([FromBody] University university)
        {
            var result = await this.universityService.Seek(university, this.UserCredit);

			return result.ToActionResult<University>();
        }

        [HttpGet]
        [Route("University/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.universityService.SeekByValue(seekValue, University.Informer, this.UserCredit);

			return result.ToActionResult<University>();
        }

        [HttpPost]
        [Route("University/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] University university)
        {
            var result = await this.universityService.Delete(university, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfUniversityHistory
        [HttpPost]
        [Route("University/{university_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "university_id")] int id, UniversityHistory universityHistory)
        {
            return this.universityService.CollectionOfUniversityHistory(id, universityHistory, this.UserCredit).ToActionResult();
        }
    }
}