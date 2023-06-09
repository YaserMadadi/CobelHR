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
    public class EducationSystemController : BaseController
    {
        public EducationSystemController(IEducationSystemService educationSystemService)
        {
            this.educationSystemService = educationSystemService;
        }

        private IEducationSystemService educationSystemService { get; set; }

        [HttpGet]
        [Route("EducationSystem/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.educationSystemService.RetrieveById(id, EducationSystem.Informer, this.UserCredit);

			return result.ToActionResult<EducationSystem>();
        }

        [HttpPost]
        [Route("EducationSystem/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.educationSystemService.RetrieveAll(EducationSystem.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<EducationSystem>();
        }
            

        
        [HttpPost]
        [Route("EducationSystem/Save")]
        public async Task<IActionResult> Save([FromBody] EducationSystem educationSystem)
        {
            var result = await this.educationSystemService.Save(educationSystem, this.UserCredit);

			return result.ToActionResult<EducationSystem>();
        }

        
        [HttpPost]
        [Route("EducationSystem/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] EducationSystem educationSystem)
        {
            var result = await this.educationSystemService.SaveAttached(educationSystem, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("EducationSystem/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<EducationSystem> educationSystemList)
        {
            var result = await this.educationSystemService.SaveBulk(educationSystemList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("EducationSystem/Seek")]
        public async Task<IActionResult> Seek([FromBody] EducationSystem educationSystem)
        {
            var result = await this.educationSystemService.Seek(educationSystem, this.UserCredit);

			return result.ToActionResult<EducationSystem>();
        }

        [HttpGet]
        [Route("EducationSystem/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.educationSystemService.SeekByValue(seekValue, EducationSystem.Informer, this.UserCredit);

			return result.ToActionResult<EducationSystem>();
        }

        [HttpPost]
        [Route("EducationSystem/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] EducationSystem educationSystem)
        {
            var result = await this.educationSystemService.Delete(educationSystem, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfUniversityHistory
        [HttpPost]
        [Route("EducationSystem/{educationSystem_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "educationSystem_id")] int id, UniversityHistory universityHistory)
        {
            return this.educationSystemService.CollectionOfUniversityHistory(id, universityHistory, this.UserCredit).ToActionResult();
        }
    }
}