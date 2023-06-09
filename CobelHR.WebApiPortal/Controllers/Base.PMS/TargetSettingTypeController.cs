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
    public class TargetSettingTypeController : BaseController
    {
        public TargetSettingTypeController(ITargetSettingTypeService targetSettingTypeService)
        {
            this.targetSettingTypeService = targetSettingTypeService;
        }

        private ITargetSettingTypeService targetSettingTypeService { get; set; }

        [HttpGet]
        [Route("TargetSettingType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.targetSettingTypeService.RetrieveById(id, TargetSettingType.Informer, this.UserCredit);

			return result.ToActionResult<TargetSettingType>();
        }

        [HttpPost]
        [Route("TargetSettingType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.targetSettingTypeService.RetrieveAll(TargetSettingType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<TargetSettingType>();
        }
            

        
        [HttpPost]
        [Route("TargetSettingType/Save")]
        public async Task<IActionResult> Save([FromBody] TargetSettingType targetSettingType)
        {
            var result = await this.targetSettingTypeService.Save(targetSettingType, this.UserCredit);

			return result.ToActionResult<TargetSettingType>();
        }

        
        [HttpPost]
        [Route("TargetSettingType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] TargetSettingType targetSettingType)
        {
            var result = await this.targetSettingTypeService.SaveAttached(targetSettingType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("TargetSettingType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<TargetSettingType> targetSettingTypeList)
        {
            var result = await this.targetSettingTypeService.SaveBulk(targetSettingTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("TargetSettingType/Seek")]
        public async Task<IActionResult> Seek([FromBody] TargetSettingType targetSettingType)
        {
            var result = await this.targetSettingTypeService.Seek(targetSettingType, this.UserCredit);

			return result.ToActionResult<TargetSettingType>();
        }

        [HttpGet]
        [Route("TargetSettingType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.targetSettingTypeService.SeekByValue(seekValue, TargetSettingType.Informer, this.UserCredit);

			return result.ToActionResult<TargetSettingType>();
        }

        [HttpPost]
        [Route("TargetSettingType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] TargetSettingType targetSettingType)
        {
            var result = await this.targetSettingTypeService.Delete(targetSettingType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfTargetSetting
        [HttpPost]
        [Route("TargetSettingType/{targetSettingType_id:int}/TargetSetting")]
        public IActionResult CollectionOfTargetSetting([FromRoute(Name = "targetSettingType_id")] int id, TargetSetting targetSetting)
        {
            return this.targetSettingTypeService.CollectionOfTargetSetting(id, targetSetting, this.UserCredit).ToActionResult();
        }
    }
}