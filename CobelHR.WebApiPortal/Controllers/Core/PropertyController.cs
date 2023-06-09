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
    public class PropertyController : BaseController
    {
        public PropertyController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }

        private IPropertyService propertyService { get; set; }

        [HttpGet]
        [Route("Property/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.propertyService.RetrieveById(id, Property.Informer, this.UserCredit);

			return result.ToActionResult<Property>();
        }

        [HttpPost]
        [Route("Property/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.propertyService.RetrieveAll(Property.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Property>();
        }
            

        
        [HttpPost]
        [Route("Property/Save")]
        public async Task<IActionResult> Save([FromBody] Property property)
        {
            var result = await this.propertyService.Save(property, this.UserCredit);

			return result.ToActionResult<Property>();
        }

        
        [HttpPost]
        [Route("Property/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Property property)
        {
            var result = await this.propertyService.SaveAttached(property, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Property/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Property> propertyList)
        {
            var result = await this.propertyService.SaveBulk(propertyList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Property/Seek")]
        public async Task<IActionResult> Seek([FromBody] Property property)
        {
            var result = await this.propertyService.Seek(property, this.UserCredit);

			return result.ToActionResult<Property>();
        }

        [HttpGet]
        [Route("Property/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.propertyService.SeekByValue(seekValue, Property.Informer, this.UserCredit);

			return result.ToActionResult<Property>();
        }

        [HttpPost]
        [Route("Property/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Property property)
        {
            var result = await this.propertyService.Delete(property, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPropertyOption
        [HttpPost]
        [Route("Property/{property_id:int}/PropertyOption")]
        public IActionResult CollectionOfPropertyOption([FromRoute(Name = "property_id")] int id, PropertyOption propertyOption)
        {
            return this.propertyService.CollectionOfPropertyOption(id, propertyOption, this.UserCredit).ToActionResult();
        }
    }
}