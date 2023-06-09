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
    public class CountryController : BaseController
    {
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        private ICountryService countryService { get; set; }

        [HttpGet]
        [Route("Country/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.countryService.RetrieveById(id, Country.Informer, this.UserCredit);

			return result.ToActionResult<Country>();
        }

        [HttpPost]
        [Route("Country/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.countryService.RetrieveAll(Country.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Country>();
        }
            

        
        [HttpPost]
        [Route("Country/Save")]
        public async Task<IActionResult> Save([FromBody] Country country)
        {
            var result = await this.countryService.Save(country, this.UserCredit);

			return result.ToActionResult<Country>();
        }

        
        [HttpPost]
        [Route("Country/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Country country)
        {
            var result = await this.countryService.SaveAttached(country, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Country/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Country> countryList)
        {
            var result = await this.countryService.SaveBulk(countryList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Country/Seek")]
        public async Task<IActionResult> Seek([FromBody] Country country)
        {
            var result = await this.countryService.Seek(country, this.UserCredit);

			return result.ToActionResult<Country>();
        }

        [HttpGet]
        [Route("Country/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.countryService.SeekByValue(seekValue, Country.Informer, this.UserCredit);

			return result.ToActionResult<Country>();
        }

        [HttpPost]
        [Route("Country/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Country country)
        {
            var result = await this.countryService.Delete(country, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPerson_Nationality
        [HttpPost]
        [Route("Nationality/{country_id:int}/Person")]
        public IActionResult CollectionOfPerson_Nationality([FromRoute(Name = "country_id")] int id, Person person)
        {
            return this.countryService.CollectionOfPerson_Nationality(id, person, this.UserCredit).ToActionResult();
        }
    }
}