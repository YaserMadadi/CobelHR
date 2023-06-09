
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Pharma.Abstract;
using CobelHR.Entities.PMS.Pharma;
using System.Threading.Tasks;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS.Pharma
{
    [Route("api")]
    public class PharmaConfigTargetSettingController : BaseController
    {
        public PharmaConfigTargetSettingController(IPharmaConfigTargetSettingService configTargetSettingService)
        {
            this.configTargetSettingService = configTargetSettingService;
        }

        private IPharmaConfigTargetSettingService configTargetSettingService { get; set; }

        [HttpGet]
        [Route("PMS.Pharma/PharmaConfigTargetSetting/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.configTargetSettingService.RetrieveById(id, PharmaConfigTargetSetting.Informer, this.UserCredit);

			return result.ToActionResult<PharmaConfigTargetSetting>();
        }

        [HttpPost]
        [Route("PMS.Pharma/PharmaConfigTargetSetting/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.configTargetSettingService.RetrieveAll(PharmaConfigTargetSetting.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PharmaConfigTargetSetting>();
        }
            

        
        [HttpPost]
        [Route("PMS.Pharma/PharmaConfigTargetSetting/Save")]
        public async Task<IActionResult> Save([FromBody] PharmaConfigTargetSetting configTargetSetting)
        {
            var result = await this.configTargetSettingService.Save(configTargetSetting, this.UserCredit);

			return result.ToActionResult<PharmaConfigTargetSetting>();
        }

        
        [HttpPost]
        [Route("PMS.Pharma/PharmaConfigTargetSetting/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PharmaConfigTargetSetting configTargetSetting)
        {
            var result = await this.configTargetSettingService.SaveAttached(configTargetSetting, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PMS.Pharma/PharmaConfigTargetSetting/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PharmaConfigTargetSetting> configTargetSettingList)
        {
            var result = await this.configTargetSettingService.SaveBulk(configTargetSettingList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PMS.Pharma/PharmaConfigTargetSetting/Seek")]
        public async Task<IActionResult> Seek([FromBody] PharmaConfigTargetSetting configTargetSetting)
        {
            var result = await this.configTargetSettingService.Seek(configTargetSetting, this.UserCredit);

			return result.ToActionResult<PharmaConfigTargetSetting>();
        }

        [HttpGet]
        [Route("PMS.Pharma/PharmaConfigTargetSetting/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.configTargetSettingService.SeekByValue(seekValue, PharmaConfigTargetSetting.Informer, this.UserCredit);

			return result.ToActionResult<PharmaConfigTargetSetting>();
        }

        [HttpPost]
        [Route("PMS.Pharma/PharmaConfigTargetSetting/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PharmaConfigTargetSetting configTargetSetting)
        {
            var result = await this.configTargetSettingService.Delete(configTargetSetting, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfConfigQualitativeObjective
        [HttpPost]
        [Route("PMS.Pharma/PharmaConfigTargetSetting/{configTargetSetting_id:int}/ConfigQualitativeObjective")]
        public IActionResult CollectionOfConfigQualitativeObjective([FromRoute(Name = "configTargetSetting_id")] int id, ConfigObjective configObjective)
        {
            return this.configTargetSettingService.CollectionOfConfigObjective(id, configObjective, this.UserCredit).ToActionResult();
        }
    }
}