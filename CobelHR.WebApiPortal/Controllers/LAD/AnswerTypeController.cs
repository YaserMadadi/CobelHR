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
    public class AnswerTypeController : BaseController
    {
        public AnswerTypeController(IAnswerTypeService answerTypeService)
        {
            this.answerTypeService = answerTypeService;
        }

        private IAnswerTypeService answerTypeService { get; set; }

        [HttpGet]
        [Route("AnswerType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.answerTypeService.RetrieveById(id, AnswerType.Informer, this.UserCredit);

			return result.ToActionResult<AnswerType>();
        }

        [HttpPost]
        [Route("AnswerType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.answerTypeService.RetrieveAll(AnswerType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AnswerType>();
        }
            

        
        [HttpPost]
        [Route("AnswerType/Save")]
        public async Task<IActionResult> Save([FromBody] AnswerType answerType)
        {
            var result = await this.answerTypeService.Save(answerType, this.UserCredit);

			return result.ToActionResult<AnswerType>();
        }

        
        [HttpPost]
        [Route("AnswerType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AnswerType answerType)
        {
            var result = await this.answerTypeService.SaveAttached(answerType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AnswerType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AnswerType> answerTypeList)
        {
            var result = await this.answerTypeService.SaveBulk(answerTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AnswerType/Seek")]
        public async Task<IActionResult> Seek([FromBody] AnswerType answerType)
        {
            var result = await this.answerTypeService.Seek(answerType, this.UserCredit);

			return result.ToActionResult<AnswerType>();
        }

        [HttpGet]
        [Route("AnswerType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.answerTypeService.SeekByValue(seekValue, AnswerType.Informer, this.UserCredit);

			return result.ToActionResult<AnswerType>();
        }

        [HttpPost]
        [Route("AnswerType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AnswerType answerType)
        {
            var result = await this.answerTypeService.Delete(answerType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAnswerTypeItem
        [HttpPost]
        [Route("AnswerType/{answerType_id:int}/AnswerTypeItem")]
        public IActionResult CollectionOfAnswerTypeItem([FromRoute(Name = "answerType_id")] int id, AnswerTypeItem answerTypeItem)
        {
            return this.answerTypeService.CollectionOfAnswerTypeItem(id, answerTypeItem, this.UserCredit).ToActionResult();
        }

		// CollectionOfQuestionaryItem
        [HttpPost]
        [Route("AnswerType/{answerType_id:int}/QuestionaryItem")]
        public IActionResult CollectionOfQuestionaryItem([FromRoute(Name = "answerType_id")] int id, QuestionaryItem questionaryItem)
        {
            return this.answerTypeService.CollectionOfQuestionaryItem(id, questionaryItem, this.UserCredit).ToActionResult();
        }
    }
}