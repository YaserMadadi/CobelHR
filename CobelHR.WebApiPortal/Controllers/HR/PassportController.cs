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
    public class PassportController : BaseController
    {
        public PassportController(IPassportService passportService)
        {
            this.passportService = passportService;
        }

        private IPassportService passportService { get; set; }

        [HttpGet]
        [Route("Passport/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.passportService.RetrieveById(id, Passport.Informer, this.UserCredit);

			return result.ToActionResult<Passport>();
        }

        [HttpPost]
        [Route("Passport/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.passportService.RetrieveAll(Passport.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Passport>();
        }
            

        
        [HttpPost]
        [Route("Passport/Save")]
        public async Task<IActionResult> Save([FromBody] Passport passport)
        {
            var result = await this.passportService.Save(passport, this.UserCredit);

			return result.ToActionResult<Passport>();
        }

        
        [HttpPost]
        [Route("Passport/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Passport passport)
        {
            var result = await this.passportService.SaveAttached(passport, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Passport/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Passport> passportList)
        {
            var result = await this.passportService.SaveBulk(passportList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Passport/Seek")]
        public async Task<IActionResult> Seek([FromBody] Passport passport)
        {
            var result = await this.passportService.Seek(passport, this.UserCredit);

			return result.ToActionResult<Passport>();
        }

        [HttpGet]
        [Route("Passport/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.passportService.SeekByValue(seekValue, Passport.Informer, this.UserCredit);

			return result.ToActionResult<Passport>();
        }

        [HttpPost]
        [Route("Passport/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Passport passport)
        {
            var result = await this.passportService.Delete(passport, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}