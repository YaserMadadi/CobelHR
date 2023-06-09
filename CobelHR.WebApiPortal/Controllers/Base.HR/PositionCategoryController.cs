using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.PMS;
using CobelHR.Entities.HR;
using Pharma = CobelHR.Entities.PMS.Pharma;

using System.Threading.Tasks;
using CobelHR.Entities.PMS.Pharma;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class PositionCategoryController : BaseController
    {
        public PositionCategoryController(IPositionCategoryService positionCategoryService)
        {
            this.positionCategoryService = positionCategoryService;
        }

        private IPositionCategoryService positionCategoryService { get; set; }

        [HttpGet]
        [Route("PositionCategory/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.positionCategoryService.RetrieveById(id, PositionCategory.Informer, this.UserCredit);

			return result.ToActionResult<PositionCategory>();
        }

        [HttpPost]
        [Route("PositionCategory/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.positionCategoryService.RetrieveAll(PositionCategory.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PositionCategory>();
        }
            

        
        [HttpPost]
        [Route("PositionCategory/Save")]
        public async Task<IActionResult> Save([FromBody] PositionCategory positionCategory)
        {
            var result = await this.positionCategoryService.Save(positionCategory, this.UserCredit);

			return result.ToActionResult<PositionCategory>();
        }

        
        [HttpPost]
        [Route("PositionCategory/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PositionCategory positionCategory)
        {
            var result = await this.positionCategoryService.SaveAttached(positionCategory, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PositionCategory/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PositionCategory> positionCategoryList)
        {
            var result = await this.positionCategoryService.SaveBulk(positionCategoryList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PositionCategory/Seek")]
        public async Task<IActionResult> Seek([FromBody] PositionCategory positionCategory)
        {
            var result = await this.positionCategoryService.Seek(positionCategory, this.UserCredit);

			return result.ToActionResult<PositionCategory>();
        }

        [HttpGet]
        [Route("PositionCategory/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.positionCategoryService.SeekByValue(seekValue, PositionCategory.Informer, this.UserCredit);

			return result.ToActionResult<PositionCategory>();
        }

        [HttpPost]
        [Route("PositionCategory/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PositionCategory positionCategory)
        {
            var result = await this.positionCategoryService.Delete(positionCategory, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAppraisalApproverConfig
        [HttpPost]
        [Route("PositionCategory/{positionCategory_id:int}/AppraisalApproverConfig")]
        public IActionResult CollectionOfAppraisalApproverConfig([FromRoute(Name = "positionCategory_id")] int id, AppraisalApproverConfig appraisalApproverConfig)
        {
            return this.positionCategoryService.CollectionOfAppraisalApproverConfig(id, appraisalApproverConfig, this.UserCredit).ToActionResult();
        }

        // CollectionOfPosition
        [HttpPost]
        [Route("PositionCategory/{positionCategory_id:int}/Position")]
        public IActionResult CollectionOfPosition([FromRoute(Name = "positionCategory_id")] int id, Position position)
        {
            return this.positionCategoryService.CollectionOfPosition(id, position, this.UserCredit).ToActionResult();
        }

        // CollectionOfUnit
        [HttpPost]
        [Route("PositionCategory/{positionCategory_id:int}/ConfigTargetSetting")]
        public IActionResult CollectionOfConfigTargetSetting([FromRoute(Name = "positionCategory_id")] int id, ConfigTargetSetting configTargetSetting)
        {
            return this.positionCategoryService.CollectionOfConfigTargetSetting(id, configTargetSetting, this.UserCredit).ToActionResult();
        }

        // CollectionOfUnit
        [HttpPost]
        [Route("PositionCategory/{positionCategory_id:int}/PharmaConfigTargetSetting")]
        public IActionResult CollectionOfPharmaConfigTargetSetting([FromRoute(Name = "positionCategory_id")] int id, PharmaConfigTargetSetting pharmaConfigTargetSetting)
        {
            return this.positionCategoryService.CollectionOfPharmaConfigTargetSetting(id, pharmaConfigTargetSetting, this.UserCredit).ToActionResult();
        }
    }
}