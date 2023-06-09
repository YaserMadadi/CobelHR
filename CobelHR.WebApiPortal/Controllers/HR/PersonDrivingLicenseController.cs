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
    public class PersonDrivingLicenseController : BaseController
    {
        public PersonDrivingLicenseController(IPersonDrivingLicenseService personDrivingLicenseService)
        {
            this.personDrivingLicenseService = personDrivingLicenseService;
        }

        private IPersonDrivingLicenseService personDrivingLicenseService { get; set; }

        [HttpGet]
        [Route("PersonDrivingLicense/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.personDrivingLicenseService.RetrieveById(id, PersonDrivingLicense.Informer, this.UserCredit);

			return result.ToActionResult<PersonDrivingLicense>();
        }

        [HttpPost]
        [Route("PersonDrivingLicense/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.personDrivingLicenseService.RetrieveAll(PersonDrivingLicense.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PersonDrivingLicense>();
        }
            

        
        [HttpPost]
        [Route("PersonDrivingLicense/Save")]
        public async Task<IActionResult> Save([FromBody] PersonDrivingLicense personDrivingLicense)
        {
            var result = await this.personDrivingLicenseService.Save(personDrivingLicense, this.UserCredit);

			return result.ToActionResult<PersonDrivingLicense>();
        }

        
        [HttpPost]
        [Route("PersonDrivingLicense/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PersonDrivingLicense personDrivingLicense)
        {
            var result = await this.personDrivingLicenseService.SaveAttached(personDrivingLicense, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PersonDrivingLicense/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PersonDrivingLicense> personDrivingLicenseList)
        {
            var result = await this.personDrivingLicenseService.SaveBulk(personDrivingLicenseList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PersonDrivingLicense/Seek")]
        public async Task<IActionResult> Seek([FromBody] PersonDrivingLicense personDrivingLicense)
        {
            var result = await this.personDrivingLicenseService.Seek(personDrivingLicense, this.UserCredit);

			return result.ToActionResult<PersonDrivingLicense>();
        }

        [HttpGet]
        [Route("PersonDrivingLicense/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.personDrivingLicenseService.SeekByValue(seekValue, PersonDrivingLicense.Informer, this.UserCredit);

			return result.ToActionResult<PersonDrivingLicense>();
        }

        [HttpPost]
        [Route("PersonDrivingLicense/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PersonDrivingLicense personDrivingLicense)
        {
            var result = await this.personDrivingLicenseService.Delete(personDrivingLicense, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}