using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Entities.Base.PMS;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.PMS
{
    [Route("api/Base.PMS")]
    public class TargetSettingModeController : BaseController
    {
        public TargetSettingModeController(ITargetSettingModeService targetSettingModeService)
        {
            this.targetSettingModeService = targetSettingModeService;
        }

        private ITargetSettingModeService targetSettingModeService { get; set; }

        [HttpGet]
        [Route("TargetSettingMode/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.targetSettingModeService.RetrieveById(id, TargetSettingMode.Informer, this.UserCredit);

			return result.ToActionResult<TargetSettingMode>();
        }

        [HttpPost]
        [Route("TargetSettingMode/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.targetSettingModeService.RetrieveAll(TargetSettingMode.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<TargetSettingMode>();
        }
            

        
        [HttpPost]
        [Route("TargetSettingMode/Save")]
        public async Task<IActionResult> Save([FromBody] TargetSettingMode TargetSettingMode)
        {
            var result = await this.targetSettingModeService.Save(TargetSettingMode, this.UserCredit);

			return result.ToActionResult<TargetSettingMode>();
        }

        
        [HttpPost]
        [Route("TargetSettingMode/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] TargetSettingMode TargetSettingMode)
        {
            var result = await this.targetSettingModeService.SaveAttached(TargetSettingMode, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("TargetSettingMode/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<TargetSettingMode> TargetSettingModeList)
        {
            var result = await this.targetSettingModeService.SaveBulk(TargetSettingModeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("TargetSettingMode/Seek")]
        public async Task<IActionResult> Seek([FromBody] TargetSettingMode TargetSettingMode)
        {
            var result = await this.targetSettingModeService.Seek(TargetSettingMode, this.UserCredit);

			return result.ToActionResult<TargetSettingMode>();
        }

        [HttpGet]
        [Route("TargetSettingMode/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.targetSettingModeService.SeekByValue(seekValue, TargetSettingMode.Informer, this.UserCredit);

			return result.ToActionResult<TargetSettingMode>();
        }

        [HttpPost]
        [Route("TargetSettingMode/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] TargetSettingMode TargetSettingMode)
        {
            var result = await this.targetSettingModeService.Delete(TargetSettingMode, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfTargetSetting
        [HttpPost]
        [Route("TargetSettingMode/{TargetSettingMode_id:int}/TargetSetting")]
        public IActionResult CollectionOfTargetSetting([FromRoute(Name = "TargetSettingMode_id")] int id, TargetSetting targetSetting)
        {
            return this.targetSettingModeService.CollectionOfTargetSetting(id, targetSetting, this.UserCredit).ToActionResult();
        }
    }
}