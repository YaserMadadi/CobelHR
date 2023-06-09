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
    public class HabitancyTypeController : BaseController
    {
        public HabitancyTypeController(IHabitancyTypeService habitancyTypeService)
        {
            this.habitancyTypeService = habitancyTypeService;
        }

        private IHabitancyTypeService habitancyTypeService { get; set; }

        [HttpGet]
        [Route("HabitancyType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.habitancyTypeService.RetrieveById(id, HabitancyType.Informer, this.UserCredit);

			return result.ToActionResult<HabitancyType>();
        }

        [HttpPost]
        [Route("HabitancyType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.habitancyTypeService.RetrieveAll(HabitancyType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<HabitancyType>();
        }
            

        
        [HttpPost]
        [Route("HabitancyType/Save")]
        public async Task<IActionResult> Save([FromBody] HabitancyType habitancyType)
        {
            var result = await this.habitancyTypeService.Save(habitancyType, this.UserCredit);

			return result.ToActionResult<HabitancyType>();
        }

        
        [HttpPost]
        [Route("HabitancyType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] HabitancyType habitancyType)
        {
            var result = await this.habitancyTypeService.SaveAttached(habitancyType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("HabitancyType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<HabitancyType> habitancyTypeList)
        {
            var result = await this.habitancyTypeService.SaveBulk(habitancyTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("HabitancyType/Seek")]
        public async Task<IActionResult> Seek([FromBody] HabitancyType habitancyType)
        {
            var result = await this.habitancyTypeService.Seek(habitancyType, this.UserCredit);

			return result.ToActionResult<HabitancyType>();
        }

        [HttpGet]
        [Route("HabitancyType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.habitancyTypeService.SeekByValue(seekValue, HabitancyType.Informer, this.UserCredit);

			return result.ToActionResult<HabitancyType>();
        }

        [HttpPost]
        [Route("HabitancyType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] HabitancyType habitancyType)
        {
            var result = await this.habitancyTypeService.Delete(habitancyType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfHabitancy
        [HttpPost]
        [Route("HabitancyType/{habitancyType_id:int}/Habitancy")]
        public IActionResult CollectionOfHabitancy([FromRoute(Name = "habitancyType_id")] int id, Habitancy habitancy)
        {
            return this.habitancyTypeService.CollectionOfHabitancy(id, habitancy, this.UserCredit).ToActionResult();
        }
    }
}