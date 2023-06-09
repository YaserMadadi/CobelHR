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
    public class ReligionController : BaseController
    {
        public ReligionController(IReligionService religionService)
        {
            this.religionService = religionService;
        }

        private IReligionService religionService { get; set; }

        [HttpGet]
        [Route("Religion/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.religionService.RetrieveById(id, Religion.Informer, this.UserCredit);

			return result.ToActionResult<Religion>();
        }

        [HttpPost]
        [Route("Religion/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.religionService.RetrieveAll(Religion.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Religion>();
        }
            

        
        [HttpPost]
        [Route("Religion/Save")]
        public async Task<IActionResult> Save([FromBody] Religion religion)
        {
            var result = await this.religionService.Save(religion, this.UserCredit);

			return result.ToActionResult<Religion>();
        }

        
        [HttpPost]
        [Route("Religion/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Religion religion)
        {
            var result = await this.religionService.SaveAttached(religion, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Religion/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Religion> religionList)
        {
            var result = await this.religionService.SaveBulk(religionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Religion/Seek")]
        public async Task<IActionResult> Seek([FromBody] Religion religion)
        {
            var result = await this.religionService.Seek(religion, this.UserCredit);

			return result.ToActionResult<Religion>();
        }

        [HttpGet]
        [Route("Religion/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.religionService.SeekByValue(seekValue, Religion.Informer, this.UserCredit);

			return result.ToActionResult<Religion>();
        }

        [HttpPost]
        [Route("Religion/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Religion religion)
        {
            var result = await this.religionService.Delete(religion, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPerson
        [HttpPost]
        [Route("Religion/{religion_id:int}/Person")]
        public IActionResult CollectionOfPerson([FromRoute(Name = "religion_id")] int id, Person person)
        {
            return this.religionService.CollectionOfPerson(id, person, this.UserCredit).ToActionResult();
        }
    }
}