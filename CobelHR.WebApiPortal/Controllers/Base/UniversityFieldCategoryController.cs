using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class UniversityFieldCategoryController : BaseController
    {
        public UniversityFieldCategoryController(IUniversityFieldCategoryService universityFieldCategoryService)
        {
            this.universityFieldCategoryService = universityFieldCategoryService;
        }

        private IUniversityFieldCategoryService universityFieldCategoryService { get; set; }

        [HttpGet]
        [Route("UniversityFieldCategory/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.universityFieldCategoryService.RetrieveById(id, UniversityFieldCategory.Informer, this.UserCredit);

			return result.ToActionResult<UniversityFieldCategory>();
        }

        [HttpPost]
        [Route("UniversityFieldCategory/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.universityFieldCategoryService.RetrieveAll(UniversityFieldCategory.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<UniversityFieldCategory>();
        }
            

        
        [HttpPost]
        [Route("UniversityFieldCategory/Save")]
        public async Task<IActionResult> Save([FromBody] UniversityFieldCategory universityFieldCategory)
        {
            var result = await this.universityFieldCategoryService.Save(universityFieldCategory, this.UserCredit);

			return result.ToActionResult<UniversityFieldCategory>();
        }

        
        [HttpPost]
        [Route("UniversityFieldCategory/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] UniversityFieldCategory universityFieldCategory)
        {
            var result = await this.universityFieldCategoryService.SaveAttached(universityFieldCategory, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("UniversityFieldCategory/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<UniversityFieldCategory> universityFieldCategoryList)
        {
            var result = await this.universityFieldCategoryService.SaveBulk(universityFieldCategoryList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("UniversityFieldCategory/Seek")]
        public async Task<IActionResult> Seek([FromBody] UniversityFieldCategory universityFieldCategory)
        {
            var result = await this.universityFieldCategoryService.Seek(universityFieldCategory, this.UserCredit);

			return result.ToActionResult<UniversityFieldCategory>();
        }

        [HttpGet]
        [Route("UniversityFieldCategory/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.universityFieldCategoryService.SeekByValue(seekValue, UniversityFieldCategory.Informer, this.UserCredit);

			return result.ToActionResult<UniversityFieldCategory>();
        }

        [HttpPost]
        [Route("UniversityFieldCategory/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] UniversityFieldCategory universityFieldCategory)
        {
            var result = await this.universityFieldCategoryService.Delete(universityFieldCategory, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfFieldOfStudy
        [HttpPost]
        [Route("UniversityFieldCategory/{universityFieldCategory_id:int}/FieldOfStudy")]
        public IActionResult CollectionOfFieldOfStudy([FromRoute(Name = "universityFieldCategory_id")] int id, FieldOfStudy fieldOfStudy)
        {
            return this.universityFieldCategoryService.CollectionOfFieldOfStudy(id, fieldOfStudy, this.UserCredit).ToActionResult();
        }
    }
}