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
    public class LanguageAbilityController : BaseController
    {
        public LanguageAbilityController(ILanguageAbilityService languageAbilityService)
        {
            this.languageAbilityService = languageAbilityService;
        }

        private ILanguageAbilityService languageAbilityService { get; set; }

        [HttpGet]
        [Route("LanguageAbility/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.languageAbilityService.RetrieveById(id, LanguageAbility.Informer, this.UserCredit);

			return result.ToActionResult<LanguageAbility>();
        }

        [HttpPost]
        [Route("LanguageAbility/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.languageAbilityService.RetrieveAll(LanguageAbility.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<LanguageAbility>();
        }
            

        
        [HttpPost]
        [Route("LanguageAbility/Save")]
        public async Task<IActionResult> Save([FromBody] LanguageAbility languageAbility)
        {
            var result = await this.languageAbilityService.Save(languageAbility, this.UserCredit);

			return result.ToActionResult<LanguageAbility>();
        }

        
        [HttpPost]
        [Route("LanguageAbility/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] LanguageAbility languageAbility)
        {
            var result = await this.languageAbilityService.SaveAttached(languageAbility, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("LanguageAbility/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<LanguageAbility> languageAbilityList)
        {
            var result = await this.languageAbilityService.SaveBulk(languageAbilityList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("LanguageAbility/Seek")]
        public async Task<IActionResult> Seek([FromBody] LanguageAbility languageAbility)
        {
            var result = await this.languageAbilityService.Seek(languageAbility, this.UserCredit);

			return result.ToActionResult<LanguageAbility>();
        }

        [HttpGet]
        [Route("LanguageAbility/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.languageAbilityService.SeekByValue(seekValue, LanguageAbility.Informer, this.UserCredit);

			return result.ToActionResult<LanguageAbility>();
        }

        [HttpPost]
        [Route("LanguageAbility/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] LanguageAbility languageAbility)
        {
            var result = await this.languageAbilityService.Delete(languageAbility, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}