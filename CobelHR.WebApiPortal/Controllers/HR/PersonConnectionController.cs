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
    public class PersonConnectionController : BaseController
    {
        public PersonConnectionController(IPersonConnectionService personConnectionService)
        {
            this.personConnectionService = personConnectionService;
        }

        private IPersonConnectionService personConnectionService { get; set; }

        [HttpGet]
        [Route("PersonConnection/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.personConnectionService.RetrieveById(id, PersonConnection.Informer, this.UserCredit);

			return result.ToActionResult<PersonConnection>();
        }

        [HttpPost]
        [Route("PersonConnection/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.personConnectionService.RetrieveAll(PersonConnection.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PersonConnection>();
        }
            

        
        [HttpPost]
        [Route("PersonConnection/Save")]
        public async Task<IActionResult> Save([FromBody] PersonConnection personConnection)
        {
            var result = await this.personConnectionService.Save(personConnection, this.UserCredit);

			return result.ToActionResult<PersonConnection>();
        }

        
        [HttpPost]
        [Route("PersonConnection/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PersonConnection personConnection)
        {
            var result = await this.personConnectionService.SaveAttached(personConnection, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PersonConnection/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PersonConnection> personConnectionList)
        {
            var result = await this.personConnectionService.SaveBulk(personConnectionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PersonConnection/Seek")]
        public async Task<IActionResult> Seek([FromBody] PersonConnection personConnection)
        {
            var result = await this.personConnectionService.Seek(personConnection, this.UserCredit);

			return result.ToActionResult<PersonConnection>();
        }

        [HttpGet]
        [Route("PersonConnection/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.personConnectionService.SeekByValue(seekValue, PersonConnection.Informer, this.UserCredit);

			return result.ToActionResult<PersonConnection>();
        }

        [HttpPost]
        [Route("PersonConnection/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PersonConnection personConnection)
        {
            var result = await this.personConnectionService.Delete(personConnection, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}