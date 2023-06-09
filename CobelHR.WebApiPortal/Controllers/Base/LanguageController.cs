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
    public class LanguageController : BaseController
    {
        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        private ILanguageService languageService { get; set; }

        [HttpGet]
        [Route("Language/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.languageService.RetrieveById(id, Language.Informer, this.UserCredit);

			return result.ToActionResult<Language>();
        }

        [HttpPost]
        [Route("Language/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.languageService.RetrieveAll(Language.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Language>();
        }
            

        
        [HttpPost]
        [Route("Language/Save")]
        public async Task<IActionResult> Save([FromBody] Language language)
        {
            var result = await this.languageService.Save(language, this.UserCredit);

			return result.ToActionResult<Language>();
        }

        
        [HttpPost]
        [Route("Language/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Language language)
        {
            var result = await this.languageService.SaveAttached(language, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Language/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Language> languageList)
        {
            var result = await this.languageService.SaveBulk(languageList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Language/Seek")]
        public async Task<IActionResult> Seek([FromBody] Language language)
        {
            var result = await this.languageService.Seek(language, this.UserCredit);

			return result.ToActionResult<Language>();
        }

        [HttpGet]
        [Route("Language/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.languageService.SeekByValue(seekValue, Language.Informer, this.UserCredit);

			return result.ToActionResult<Language>();
        }

        [HttpPost]
        [Route("Language/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Language language)
        {
            var result = await this.languageService.Delete(language, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfLanguageAbility
        [HttpPost]
        [Route("Language/{language_id:int}/LanguageAbility")]
        public IActionResult CollectionOfLanguageAbility([FromRoute(Name = "language_id")] int id, LanguageAbility languageAbility)
        {
            return this.languageService.CollectionOfLanguageAbility(id, languageAbility, this.UserCredit).ToActionResult();
        }
    }
}