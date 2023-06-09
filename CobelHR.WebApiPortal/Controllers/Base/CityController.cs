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
    public class CityController : BaseController
    {
     
        //
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }



        //test
        private ICityService cityService { get; set; }

        [HttpGet]
        [Route("City/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.cityService.RetrieveById(id, City.Informer, this.UserCredit);

			return result.ToActionResult<City>();
        }

        [HttpPost]
        [Route("City/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.cityService.RetrieveAll(City.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<City>();
        }



        [HttpPost]
        [Route("City/Save")]
        public async Task<IActionResult> Save([FromBody] City city)
        {
            var result = await this.cityService.Save(city, this.UserCredit);

			return result.ToActionResult<City>();
        }


        [HttpPost]
        [Route("City/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] City city)
        {
            var result = await this.cityService.SaveAttached(city, this.UserCredit);

            return result.ToActionResult();
        }


        [HttpPost]
        [Route("City/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<City> cityList)
        {
            var result = await this.cityService.SaveBulk(cityList, this.UserCredit);

            return result.ToActionResult();
        }

        [HttpPost]
        [Route("City/Seek")]
        public async Task<IActionResult> Seek([FromBody] City city)
        {
            var result = await this.cityService.Seek(city, this.UserCredit);

            return result.ToActionResult<City>();
        }

        [HttpGet]
        [Route("City/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.cityService.SeekByValue(seekValue, City.Informer, this.UserCredit);

            return result.ToActionResult<City>();
        }

        [HttpPost]
        [Route("City/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] City city)
        {
            var result = await this.cityService.Delete(city, id, this.UserCredit);

            return result.ToActionResult();
        }

        // CollectionOfHabitancy
        [HttpPost]
        [Route("City/{city_id:int}/Habitancy")]
        public IActionResult CollectionOfHabitancy([FromRoute(Name = "city_id")] int id, Habitancy habitancy)
        {
            return this.cityService.CollectionOfHabitancy(id, habitancy, this.UserCredit).ToActionResult();
        }

        // CollectionOfPerson_BirthCity
        [HttpPost]
        [Route("BirthCity/{city_id:int}/Person")]
        public IActionResult CollectionOfPerson_BirthCity([FromRoute(Name = "city_id")] int id, Person person)
        {
            return this.cityService.CollectionOfPerson_BirthCity(id, person, this.UserCredit).ToActionResult();
        }

        // CollectionOfUniversity
        [HttpPost]
        [Route("City/{city_id:int}/University")]
        public IActionResult CollectionOfUniversity([FromRoute(Name = "city_id")] int id, University university)
        {
            return this.cityService.CollectionOfUniversity(id, university, this.UserCredit).ToActionResult();
        }
    }
}