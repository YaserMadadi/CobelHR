using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;
using System.Threading.Tasks;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class ConfigTargetSettingController : BaseController
    {
        public ConfigTargetSettingController(IConfigTargetSettingService configTargetSettingService)
        {
            this.configTargetSettingService = configTargetSettingService;
        }

        private IConfigTargetSettingService configTargetSettingService { get; set; }

        [HttpGet]
        [Route("ConfigTargetSetting/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.configTargetSettingService.RetrieveById(id, ConfigTargetSetting.Informer, this.UserCredit);

			return result.ToActionResult<ConfigTargetSetting>();
        }

        [HttpPost]
        [Route("ConfigTargetSetting/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.configTargetSettingService.RetrieveAll(ConfigTargetSetting.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ConfigTargetSetting>();
        }
            

        
        [HttpPost]
        [Route("ConfigTargetSetting/Save")]
        public async Task<IActionResult> Save([FromBody] ConfigTargetSetting configTargetSetting)
        {
            var result = await this.configTargetSettingService.Save(configTargetSetting, this.UserCredit);

			return result.ToActionResult<ConfigTargetSetting>();
        }

        
        [HttpPost]
        [Route("ConfigTargetSetting/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ConfigTargetSetting configTargetSetting)
        {
            var result = await this.configTargetSettingService.SaveAttached(configTargetSetting, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ConfigTargetSetting/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ConfigTargetSetting> configTargetSettingList)
        {
            var result = await this.configTargetSettingService.SaveBulk(configTargetSettingList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ConfigTargetSetting/Seek")]
        public async Task<IActionResult> Seek([FromBody] ConfigTargetSetting configTargetSetting)
        {
            var result = await this.configTargetSettingService.Seek(configTargetSetting, this.UserCredit);

			return result.ToActionResult<ConfigTargetSetting>();
        }

        [HttpGet]
        [Route("ConfigTargetSetting/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.configTargetSettingService.SeekByValue(seekValue, ConfigTargetSetting.Informer, this.UserCredit);

			return result.ToActionResult<ConfigTargetSetting>();
        }

        [HttpPost]
        [Route("ConfigTargetSetting/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ConfigTargetSetting configTargetSetting)
        {
            var result = await this.configTargetSettingService.Delete(configTargetSetting, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfConfigQualitativeObjective
        [HttpPost]
        [Route("ConfigTargetSetting/{configTargetSetting_id:int}/ConfigQualitativeObjective")]
        public IActionResult CollectionOfConfigQualitativeObjective([FromRoute(Name = "configTargetSetting_id")] int id, ConfigQualitativeObjective configQualitativeObjective)
        {
            return this.configTargetSettingService.CollectionOfConfigQualitativeObjective(id, configQualitativeObjective, this.UserCredit).ToActionResult();
        }
    }
}