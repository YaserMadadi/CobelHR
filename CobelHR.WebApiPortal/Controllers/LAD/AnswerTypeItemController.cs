using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.LAD.Abstract;
using CobelHR.Entities.LAD;
using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.LAD
{
    [Route("api/LAD")]
    public class AnswerTypeItemController : BaseController
    {
        public AnswerTypeItemController(IAnswerTypeItemService answerTypeItemService)
        {
            this.answerTypeItemService = answerTypeItemService;
        }

        private IAnswerTypeItemService answerTypeItemService { get; set; }

        [HttpGet]
        [Route("AnswerTypeItem/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.answerTypeItemService.RetrieveById(id, AnswerTypeItem.Informer, this.UserCredit);

			return result.ToActionResult<AnswerTypeItem>();
        }

        [HttpPost]
        [Route("AnswerTypeItem/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.answerTypeItemService.RetrieveAll(AnswerTypeItem.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AnswerTypeItem>();
        }
            

        
        [HttpPost]
        [Route("AnswerTypeItem/Save")]
        public async Task<IActionResult> Save([FromBody] AnswerTypeItem answerTypeItem)
        {
            var result = await this.answerTypeItemService.Save(answerTypeItem, this.UserCredit);

			return result.ToActionResult<AnswerTypeItem>();
        }

        
        [HttpPost]
        [Route("AnswerTypeItem/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AnswerTypeItem answerTypeItem)
        {
            var result = await this.answerTypeItemService.SaveAttached(answerTypeItem, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AnswerTypeItem/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AnswerTypeItem> answerTypeItemList)
        {
            var result = await this.answerTypeItemService.SaveBulk(answerTypeItemList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AnswerTypeItem/Seek")]
        public async Task<IActionResult> Seek([FromBody] AnswerTypeItem answerTypeItem)
        {
            var result = await this.answerTypeItemService.Seek(answerTypeItem, this.UserCredit);

			return result.ToActionResult<AnswerTypeItem>();
        }

        [HttpGet]
        [Route("AnswerTypeItem/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.answerTypeItemService.SeekByValue(seekValue, AnswerTypeItem.Informer, this.UserCredit);

			return result.ToActionResult<AnswerTypeItem>();
        }

        [HttpPost]
        [Route("AnswerTypeItem/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AnswerTypeItem answerTypeItem)
        {
            var result = await this.answerTypeItemService.Delete(answerTypeItem, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}