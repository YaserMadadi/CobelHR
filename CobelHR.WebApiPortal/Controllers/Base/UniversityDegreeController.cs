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
    public class UniversityDegreeController : BaseController
    {
        public UniversityDegreeController(IUniversityDegreeService universityDegreeService)
        {
            this.universityDegreeService = universityDegreeService;
        }

        private IUniversityDegreeService universityDegreeService { get; set; }

        [HttpGet]
        [Route("UniversityDegree/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.universityDegreeService.RetrieveById(id, UniversityDegree.Informer, this.UserCredit);

			return result.ToActionResult<UniversityDegree>();
        }

        [HttpPost]
        [Route("UniversityDegree/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.universityDegreeService.RetrieveAll(UniversityDegree.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<UniversityDegree>();
        }
            

        
        [HttpPost]
        [Route("UniversityDegree/Save")]
        public async Task<IActionResult> Save([FromBody] UniversityDegree universityDegree)
        {
            var result = await this.universityDegreeService.Save(universityDegree, this.UserCredit);

			return result.ToActionResult<UniversityDegree>();
        }

        
        [HttpPost]
        [Route("UniversityDegree/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] UniversityDegree universityDegree)
        {
            var result = await this.universityDegreeService.SaveAttached(universityDegree, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("UniversityDegree/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<UniversityDegree> universityDegreeList)
        {
            var result = await this.universityDegreeService.SaveBulk(universityDegreeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("UniversityDegree/Seek")]
        public async Task<IActionResult> Seek([FromBody] UniversityDegree universityDegree)
        {
            var result = await this.universityDegreeService.Seek(universityDegree, this.UserCredit);

			return result.ToActionResult<UniversityDegree>();
        }

        [HttpGet]
        [Route("UniversityDegree/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.universityDegreeService.SeekByValue(seekValue, UniversityDegree.Informer, this.UserCredit);

			return result.ToActionResult<UniversityDegree>();
        }

        [HttpPost]
        [Route("UniversityDegree/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] UniversityDegree universityDegree)
        {
            var result = await this.universityDegreeService.Delete(universityDegree, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfUniversityHistory
        [HttpPost]
        [Route("UniversityDegree/{universityDegree_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "universityDegree_id")] int id, UniversityHistory universityHistory)
        {
            return this.universityDegreeService.CollectionOfUniversityHistory(id, universityHistory, this.UserCredit).ToActionResult();
        }
    }
}