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
    public class FieldCategoryController : BaseController
    {
        public FieldCategoryController(IFieldCategoryService fieldCategoryService)
        {
            this.fieldCategoryService = fieldCategoryService;
        }

        private IFieldCategoryService fieldCategoryService { get; set; }

        [HttpGet]
        [Route("FieldCategory/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.fieldCategoryService.RetrieveById(id, FieldCategory.Informer, this.UserCredit);

			return result.ToActionResult<FieldCategory>();
        }

        [HttpPost]
        [Route("FieldCategory/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.fieldCategoryService.RetrieveAll(FieldCategory.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<FieldCategory>();
        }
            

        
        [HttpPost]
        [Route("FieldCategory/Save")]
        public async Task<IActionResult> Save([FromBody] FieldCategory fieldCategory)
        {
            var result = await this.fieldCategoryService.Save(fieldCategory, this.UserCredit);

			return result.ToActionResult<FieldCategory>();
        }

        
        [HttpPost]
        [Route("FieldCategory/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] FieldCategory fieldCategory)
        {
            var result = await this.fieldCategoryService.SaveAttached(fieldCategory, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("FieldCategory/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<FieldCategory> fieldCategoryList)
        {
            var result = await this.fieldCategoryService.SaveBulk(fieldCategoryList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("FieldCategory/Seek")]
        public async Task<IActionResult> Seek([FromBody] FieldCategory fieldCategory)
        {
            var result = await this.fieldCategoryService.Seek(fieldCategory, this.UserCredit);

			return result.ToActionResult<FieldCategory>();
        }

        [HttpGet]
        [Route("FieldCategory/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.fieldCategoryService.SeekByValue(seekValue, FieldCategory.Informer, this.UserCredit);

			return result.ToActionResult<FieldCategory>();
        }

        [HttpPost]
        [Route("FieldCategory/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] FieldCategory fieldCategory)
        {
            var result = await this.fieldCategoryService.Delete(fieldCategory, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPersonCertificate
        [HttpPost]
        [Route("FieldCategory/{fieldCategory_id:int}/PersonCertificate")]
        public IActionResult CollectionOfPersonCertificate([FromRoute(Name = "fieldCategory_id")] int id, PersonCertificate personCertificate)
        {
            return this.fieldCategoryService.CollectionOfPersonCertificate(id, personCertificate, this.UserCredit).ToActionResult();
        }
    }
}