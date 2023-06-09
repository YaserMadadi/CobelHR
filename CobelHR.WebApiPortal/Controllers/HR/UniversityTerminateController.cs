using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class UniversityTerminateController : BaseController
    {
        public UniversityTerminateController(IUniversityTerminateService universityTerminateService)
        {
            this.universityTerminateService = universityTerminateService;
        }

        private IUniversityTerminateService universityTerminateService { get; set; }

        [HttpGet]
        [Route("UniversityTerminate/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.universityTerminateService.RetrieveById(id, UniversityTerminate.Informer, this.UserCredit);

			return result.ToActionResult<UniversityTerminate>();
        }

        [HttpPost]
        [Route("UniversityTerminate/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.universityTerminateService.RetrieveAll(UniversityTerminate.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<UniversityTerminate>();
        }
            

        
        [HttpPost]
        [Route("UniversityTerminate/Save")]
        public async Task<IActionResult> Save([FromBody] UniversityTerminate universityTerminate)
        {
            var result = await this.universityTerminateService.Save(universityTerminate, this.UserCredit);

			return result.ToActionResult<UniversityTerminate>();
        }

        
        [HttpPost]
        [Route("UniversityTerminate/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] UniversityTerminate universityTerminate)
        {
            var result = await this.universityTerminateService.SaveAttached(universityTerminate, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("UniversityTerminate/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<UniversityTerminate> universityTerminateList)
        {
            var result = await this.universityTerminateService.SaveBulk(universityTerminateList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("UniversityTerminate/Seek")]
        public async Task<IActionResult> Seek([FromBody] UniversityTerminate universityTerminate)
        {
            var result = await this.universityTerminateService.Seek(universityTerminate, this.UserCredit);

			return result.ToActionResult<UniversityTerminate>();
        }

        [HttpGet]
        [Route("UniversityTerminate/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.universityTerminateService.SeekByValue(seekValue, UniversityTerminate.Informer, this.UserCredit);

			return result.ToActionResult<UniversityTerminate>();
        }

        [HttpPost]
        [Route("UniversityTerminate/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] UniversityTerminate universityTerminate)
        {
            var result = await this.universityTerminateService.Delete(universityTerminate, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}