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
    public class HabitancyController : BaseController
    {
        public HabitancyController(IHabitancyService habitancyService)
        {
            this.habitancyService = habitancyService;
        }

        private IHabitancyService habitancyService { get; set; }

        [HttpGet]
        [Route("Habitancy/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.habitancyService.RetrieveById(id, Habitancy.Informer, this.UserCredit);

			return result.ToActionResult<Habitancy>();
        }

        [HttpPost]
        [Route("Habitancy/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.habitancyService.RetrieveAll(Habitancy.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Habitancy>();
        }
            

        
        [HttpPost]
        [Route("Habitancy/Save")]
        public async Task<IActionResult> Save([FromBody] Habitancy habitancy)
        {
            var result = await this.habitancyService.Save(habitancy, this.UserCredit);

			return result.ToActionResult<Habitancy>();
        }

        
        [HttpPost]
        [Route("Habitancy/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Habitancy habitancy)
        {
            var result = await this.habitancyService.SaveAttached(habitancy, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Habitancy/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Habitancy> habitancyList)
        {
            var result = await this.habitancyService.SaveBulk(habitancyList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Habitancy/Seek")]
        public async Task<IActionResult> Seek([FromBody] Habitancy habitancy)
        {
            var result = await this.habitancyService.Seek(habitancy, this.UserCredit);

			return result.ToActionResult<Habitancy>();
        }

        [HttpGet]
        [Route("Habitancy/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.habitancyService.SeekByValue(seekValue, Habitancy.Informer, this.UserCredit);

			return result.ToActionResult<Habitancy>();
        }

        [HttpPost]
        [Route("Habitancy/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Habitancy habitancy)
        {
            var result = await this.habitancyService.Delete(habitancy, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}