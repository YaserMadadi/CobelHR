using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class AppraiseTypeController : BaseController
    {
        public AppraiseTypeController(IAppraiseTypeService appraiseTypeService)
        {
            this.appraiseTypeService = appraiseTypeService;
        }

        private IAppraiseTypeService appraiseTypeService { get; set; }

        [HttpGet]
        [Route("AppraiseType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.appraiseTypeService.RetrieveById(id, AppraiseType.Informer, this.UserCredit);

			return result.ToActionResult<AppraiseType>();
        }

        [HttpPost]
        [Route("AppraiseType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.appraiseTypeService.RetrieveAll(AppraiseType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AppraiseType>();
        }
            

        
        [HttpPost]
        [Route("AppraiseType/Save")]
        public async Task<IActionResult> Save([FromBody] AppraiseType appraiseType)
        {
            var result = await this.appraiseTypeService.Save(appraiseType, this.UserCredit);

			return result.ToActionResult<AppraiseType>();
        }

        
        [HttpPost]
        [Route("AppraiseType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AppraiseType appraiseType)
        {
            var result = await this.appraiseTypeService.SaveAttached(appraiseType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AppraiseType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AppraiseType> appraiseTypeList)
        {
            var result = await this.appraiseTypeService.SaveBulk(appraiseTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AppraiseType/Seek")]
        public async Task<IActionResult> Seek([FromBody] AppraiseType appraiseType)
        {
            var result = await this.appraiseTypeService.Seek(appraiseType, this.UserCredit);

			return result.ToActionResult<AppraiseType>();
        }

        [HttpGet]
        [Route("AppraiseType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.appraiseTypeService.SeekByValue(seekValue, AppraiseType.Informer, this.UserCredit);

			return result.ToActionResult<AppraiseType>();
        }

        [HttpPost]
        [Route("AppraiseType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AppraiseType appraiseType)
        {
            var result = await this.appraiseTypeService.Delete(appraiseType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAppraiseResult
        [HttpPost]
        [Route("AppraiseType/{appraiseType_id:int}/AppraiseResult")]
        public IActionResult CollectionOfAppraiseResult([FromRoute(Name = "appraiseType_id")] int id, AppraiseResult appraiseResult)
        {
            return this.appraiseTypeService.CollectionOfAppraiseResult(id, appraiseResult, this.UserCredit).ToActionResult();
        }

		// CollectionOfBehavioralAppraise
        [HttpPost]
        [Route("AppraiseType/{appraiseType_id:int}/BehavioralAppraise")]
        public IActionResult CollectionOfBehavioralAppraise([FromRoute(Name = "appraiseType_id")] int id, BehavioralAppraise behavioralAppraise)
        {
            return this.appraiseTypeService.CollectionOfBehavioralAppraise(id, behavioralAppraise, this.UserCredit).ToActionResult();
        }

		// CollectionOfFunctionalAppraise
        [HttpPost]
        [Route("AppraiseType/{appraiseType_id:int}/FunctionalAppraise")]
        public IActionResult CollectionOfFunctionalAppraise([FromRoute(Name = "appraiseType_id")] int id, FunctionalAppraise functionalAppraise)
        {
            return this.appraiseTypeService.CollectionOfFunctionalAppraise(id, functionalAppraise, this.UserCredit).ToActionResult();
        }

		// CollectionOfQualitativeAppraise
        [HttpPost]
        [Route("AppraiseType/{appraiseType_id:int}/QualitativeAppraise")]
        public IActionResult CollectionOfQualitativeAppraise([FromRoute(Name = "appraiseType_id")] int id, QualitativeAppraise qualitativeAppraise)
        {
            return this.appraiseTypeService.CollectionOfQualitativeAppraise(id, qualitativeAppraise, this.UserCredit).ToActionResult();
        }
    }
}