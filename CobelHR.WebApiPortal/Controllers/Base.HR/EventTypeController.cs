using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class EventTypeController : BaseController
    {
        public EventTypeController(IEventTypeService eventTypeService)
        {
            this.eventTypeService = eventTypeService;
        }

        private IEventTypeService eventTypeService { get; set; }

        [HttpGet]
        [Route("EventType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.eventTypeService.RetrieveById(id, EventType.Informer, this.UserCredit);

			return result.ToActionResult<EventType>();
        }

        [HttpPost]
        [Route("EventType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.eventTypeService.RetrieveAll(EventType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<EventType>();
        }
            

        
        [HttpPost]
        [Route("EventType/Save")]
        public async Task<IActionResult> Save([FromBody] EventType eventType)
        {
            var result = await this.eventTypeService.Save(eventType, this.UserCredit);

			return result.ToActionResult<EventType>();
        }

        
        [HttpPost]
        [Route("EventType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] EventType eventType)
        {
            var result = await this.eventTypeService.SaveAttached(eventType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("EventType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<EventType> eventTypeList)
        {
            var result = await this.eventTypeService.SaveBulk(eventTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("EventType/Seek")]
        public async Task<IActionResult> Seek([FromBody] EventType eventType)
        {
            var result = await this.eventTypeService.Seek(eventType, this.UserCredit);

			return result.ToActionResult<EventType>();
        }

        [HttpGet]
        [Route("EventType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.eventTypeService.SeekByValue(seekValue, EventType.Informer, this.UserCredit);

			return result.ToActionResult<EventType>();
        }

        [HttpPost]
        [Route("EventType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] EventType eventType)
        {
            var result = await this.eventTypeService.Delete(eventType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfEmployeeEvent
        [HttpPost]
        [Route("EventType/{eventType_id:int}/EmployeeEvent")]
        public IActionResult CollectionOfEmployeeEvent([FromRoute(Name = "eventType_id")] int id, EmployeeEvent employeeEvent)
        {
            return this.eventTypeService.CollectionOfEmployeeEvent(id, employeeEvent, this.UserCredit).ToActionResult();
        }
    }
}