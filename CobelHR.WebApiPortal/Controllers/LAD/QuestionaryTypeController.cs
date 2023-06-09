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
    public class QuestionaryTypeController : BaseController
    {
        public QuestionaryTypeController(IQuestionaryTypeService questionaryTypeService)
        {
            this.questionaryTypeService = questionaryTypeService;
        }

        private IQuestionaryTypeService questionaryTypeService { get; set; }

        [HttpGet]
        [Route("QuestionaryType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.questionaryTypeService.RetrieveById(id, QuestionaryType.Informer, this.UserCredit);

			return result.ToActionResult<QuestionaryType>();
        }

        [HttpPost]
        [Route("QuestionaryType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.questionaryTypeService.RetrieveAll(QuestionaryType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<QuestionaryType>();
        }
            

        
        [HttpPost]
        [Route("QuestionaryType/Save")]
        public async Task<IActionResult> Save([FromBody] QuestionaryType questionaryType)
        {
            var result = await this.questionaryTypeService.Save(questionaryType, this.UserCredit);

			return result.ToActionResult<QuestionaryType>();
        }

        
        [HttpPost]
        [Route("QuestionaryType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] QuestionaryType questionaryType)
        {
            var result = await this.questionaryTypeService.SaveAttached(questionaryType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("QuestionaryType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<QuestionaryType> questionaryTypeList)
        {
            var result = await this.questionaryTypeService.SaveBulk(questionaryTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("QuestionaryType/Seek")]
        public async Task<IActionResult> Seek([FromBody] QuestionaryType questionaryType)
        {
            var result = await this.questionaryTypeService.Seek(questionaryType, this.UserCredit);

			return result.ToActionResult<QuestionaryType>();
        }

        [HttpGet]
        [Route("QuestionaryType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.questionaryTypeService.SeekByValue(seekValue, QuestionaryType.Informer, this.UserCredit);

			return result.ToActionResult<QuestionaryType>();
        }

        [HttpPost]
        [Route("QuestionaryType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] QuestionaryType questionaryType)
        {
            var result = await this.questionaryTypeService.Delete(questionaryType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfCoachingQuestionary
        [HttpPost]
        [Route("QuestionaryType/{questionaryType_id:int}/CoachingQuestionary")]
        public IActionResult CollectionOfCoachingQuestionary([FromRoute(Name = "questionaryType_id")] int id, CoachingQuestionary coachingQuestionary)
        {
            return this.questionaryTypeService.CollectionOfCoachingQuestionary(id, coachingQuestionary, this.UserCredit).ToActionResult();
        }

		// CollectionOfQuestionaryItem
        [HttpPost]
        [Route("QuestionaryType/{questionaryType_id:int}/QuestionaryItem")]
        public IActionResult CollectionOfQuestionaryItem([FromRoute(Name = "questionaryType_id")] int id, QuestionaryItem questionaryItem)
        {
            return this.questionaryTypeService.CollectionOfQuestionaryItem(id, questionaryItem, this.UserCredit).ToActionResult();
        }
    }
}