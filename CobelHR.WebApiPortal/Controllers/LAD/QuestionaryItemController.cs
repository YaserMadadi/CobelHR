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
    public class QuestionaryItemController : BaseController
    {
        public QuestionaryItemController(IQuestionaryItemService questionaryItemService)
        {
            this.questionaryItemService = questionaryItemService;
        }

        private IQuestionaryItemService questionaryItemService { get; set; }

        [HttpGet]
        [Route("QuestionaryItem/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.questionaryItemService.RetrieveById(id, QuestionaryItem.Informer, this.UserCredit);

			return result.ToActionResult<QuestionaryItem>();
        }

        [HttpPost]
        [Route("QuestionaryItem/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.questionaryItemService.RetrieveAll(QuestionaryItem.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<QuestionaryItem>();
        }
            

        
        [HttpPost]
        [Route("QuestionaryItem/Save")]
        public async Task<IActionResult> Save([FromBody] QuestionaryItem questionaryItem)
        {
            var result = await this.questionaryItemService.Save(questionaryItem, this.UserCredit);

			return result.ToActionResult<QuestionaryItem>();
        }

        
        [HttpPost]
        [Route("QuestionaryItem/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] QuestionaryItem questionaryItem)
        {
            var result = await this.questionaryItemService.SaveAttached(questionaryItem, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("QuestionaryItem/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<QuestionaryItem> questionaryItemList)
        {
            var result = await this.questionaryItemService.SaveBulk(questionaryItemList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("QuestionaryItem/Seek")]
        public async Task<IActionResult> Seek([FromBody] QuestionaryItem questionaryItem)
        {
            var result = await this.questionaryItemService.Seek(questionaryItem, this.UserCredit);

			return result.ToActionResult<QuestionaryItem>();
        }

        [HttpGet]
        [Route("QuestionaryItem/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.questionaryItemService.SeekByValue(seekValue, QuestionaryItem.Informer, this.UserCredit);

			return result.ToActionResult<QuestionaryItem>();
        }

        [HttpPost]
        [Route("QuestionaryItem/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] QuestionaryItem questionaryItem)
        {
            var result = await this.questionaryItemService.Delete(questionaryItem, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfCoachingQuestionaryAnswered
        [HttpPost]
        [Route("QuestionaryItem/{questionaryItem_id:int}/CoachingQuestionaryAnswered")]
        public IActionResult CollectionOfCoachingQuestionaryAnswered([FromRoute(Name = "questionaryItem_id")] int id, CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            return this.questionaryItemService.CollectionOfCoachingQuestionaryAnswered(id, coachingQuestionaryAnswered, this.UserCredit).ToActionResult();
        }
    }
}