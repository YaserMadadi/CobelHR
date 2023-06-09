using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.XCode.Abstract;
using CobelHR.Entities.XCode;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.XCode
{
    [Route("api/XCode")]
    public class MessageController : BaseController
    {
        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        private IMessageService messageService { get; set; }

        [HttpGet]
        [Route("Message/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.messageService.RetrieveById(id, Message.Informer, this.UserCredit);

			return result.ToActionResult<Message>();
        }

        [HttpPost]
        [Route("Message/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.messageService.RetrieveAll(Message.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Message>();
        }
            

        
        [HttpPost]
        [Route("Message/Save")]
        public async Task<IActionResult> Save([FromBody] Message message)
        {
            var result = await this.messageService.Save(message, this.UserCredit);

			return result.ToActionResult<Message>();
        }

        
        [HttpPost]
        [Route("Message/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Message message)
        {
            var result = await this.messageService.SaveAttached(message, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Message/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Message> messageList)
        {
            var result = await this.messageService.SaveBulk(messageList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Message/Seek")]
        public async Task<IActionResult> Seek([FromBody] Message message)
        {
            var result = await this.messageService.Seek(message, this.UserCredit);

			return result.ToActionResult<Message>();
        }

        [HttpGet]
        [Route("Message/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.messageService.SeekByValue(seekValue, Message.Informer, this.UserCredit);

			return result.ToActionResult<Message>();
        }

        [HttpPost]
        [Route("Message/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Message message)
        {
            var result = await this.messageService.Delete(message, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}