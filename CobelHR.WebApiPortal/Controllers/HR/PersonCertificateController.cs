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
    public class PersonCertificateController : BaseController
    {
        public PersonCertificateController(IPersonCertificateService personCertificateService)
        {
            this.personCertificateService = personCertificateService;
        }

        private IPersonCertificateService personCertificateService { get; set; }

        [HttpGet]
        [Route("PersonCertificate/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.personCertificateService.RetrieveById(id, PersonCertificate.Informer, this.UserCredit);

			return result.ToActionResult<PersonCertificate>();
        }

        [HttpPost]
        [Route("PersonCertificate/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.personCertificateService.RetrieveAll(PersonCertificate.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PersonCertificate>();
        }
            

        
        [HttpPost]
        [Route("PersonCertificate/Save")]
        public async Task<IActionResult> Save([FromBody] PersonCertificate personCertificate)
        {
            var result = await this.personCertificateService.Save(personCertificate, this.UserCredit);

			return result.ToActionResult<PersonCertificate>();
        }

        
        [HttpPost]
        [Route("PersonCertificate/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PersonCertificate personCertificate)
        {
            var result = await this.personCertificateService.SaveAttached(personCertificate, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PersonCertificate/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PersonCertificate> personCertificateList)
        {
            var result = await this.personCertificateService.SaveBulk(personCertificateList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PersonCertificate/Seek")]
        public async Task<IActionResult> Seek([FromBody] PersonCertificate personCertificate)
        {
            var result = await this.personCertificateService.Seek(personCertificate, this.UserCredit);

			return result.ToActionResult<PersonCertificate>();
        }

        [HttpGet]
        [Route("PersonCertificate/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.personCertificateService.SeekByValue(seekValue, PersonCertificate.Informer, this.UserCredit);

			return result.ToActionResult<PersonCertificate>();
        }

        [HttpPost]
        [Route("PersonCertificate/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PersonCertificate personCertificate)
        {
            var result = await this.personCertificateService.Delete(personCertificate, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}