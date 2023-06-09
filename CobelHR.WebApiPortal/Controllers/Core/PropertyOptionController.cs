using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Core.Abstract;
using CobelHR.Entities.Core;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Core
{
    [Route("api/Core")]
    public class PropertyOptionController : BaseController
    {
        public PropertyOptionController(IPropertyOptionService propertyOptionService)
        {
            this.propertyOptionService = propertyOptionService;
        }

        private IPropertyOptionService propertyOptionService { get; set; }

        [HttpGet]
        [Route("PropertyOption/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.propertyOptionService.RetrieveById(id, PropertyOption.Informer, this.UserCredit);

			return result.ToActionResult<PropertyOption>();
        }

        [HttpPost]
        [Route("PropertyOption/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.propertyOptionService.RetrieveAll(PropertyOption.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PropertyOption>();
        }
            

        
        [HttpPost]
        [Route("PropertyOption/Save")]
        public async Task<IActionResult> Save([FromBody] PropertyOption propertyOption)
        {
            var result = await this.propertyOptionService.Save(propertyOption, this.UserCredit);

			return result.ToActionResult<PropertyOption>();
        }

        
        [HttpPost]
        [Route("PropertyOption/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PropertyOption propertyOption)
        {
            var result = await this.propertyOptionService.SaveAttached(propertyOption, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PropertyOption/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PropertyOption> propertyOptionList)
        {
            var result = await this.propertyOptionService.SaveBulk(propertyOptionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PropertyOption/Seek")]
        public async Task<IActionResult> Seek([FromBody] PropertyOption propertyOption)
        {
            var result = await this.propertyOptionService.Seek(propertyOption, this.UserCredit);

			return result.ToActionResult<PropertyOption>();
        }

        [HttpGet]
        [Route("PropertyOption/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.propertyOptionService.SeekByValue(seekValue, PropertyOption.Informer, this.UserCredit);

			return result.ToActionResult<PropertyOption>();
        }

        [HttpPost]
        [Route("PropertyOption/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PropertyOption propertyOption)
        {
            var result = await this.propertyOptionService.Delete(propertyOption, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}