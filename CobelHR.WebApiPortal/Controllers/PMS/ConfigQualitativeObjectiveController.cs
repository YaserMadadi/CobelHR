using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class ConfigQualitativeObjectiveController : BaseController
    {
        public ConfigQualitativeObjectiveController(IConfigQualitativeObjectiveService configQualitativeObjectiveService)
        {
            this.configQualitativeObjectiveService = configQualitativeObjectiveService;
        }

        private IConfigQualitativeObjectiveService configQualitativeObjectiveService { get; set; }

        [HttpGet]
        [Route("ConfigQualitativeObjective/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.configQualitativeObjectiveService.RetrieveById(id, ConfigQualitativeObjective.Informer, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeObjective>();
        }

        [HttpPost]
        [Route("ConfigQualitativeObjective/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.configQualitativeObjectiveService.RetrieveAll(ConfigQualitativeObjective.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeObjective>();
        }
            

        
        [HttpPost]
        [Route("ConfigQualitativeObjective/Save")]
        public async Task<IActionResult> Save([FromBody] ConfigQualitativeObjective configQualitativeObjective)
        {
            var result = await this.configQualitativeObjectiveService.Save(configQualitativeObjective, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeObjective>();
        }

        
        [HttpPost]
        [Route("ConfigQualitativeObjective/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ConfigQualitativeObjective configQualitativeObjective)
        {
            var result = await this.configQualitativeObjectiveService.SaveAttached(configQualitativeObjective, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ConfigQualitativeObjective/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ConfigQualitativeObjective> configQualitativeObjectiveList)
        {
            var result = await this.configQualitativeObjectiveService.SaveBulk(configQualitativeObjectiveList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ConfigQualitativeObjective/Seek")]
        public async Task<IActionResult> Seek([FromBody] ConfigQualitativeObjective configQualitativeObjective)
        {
            var result = await this.configQualitativeObjectiveService.Seek(configQualitativeObjective, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeObjective>();
        }

        [HttpGet]
        [Route("ConfigQualitativeObjective/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.configQualitativeObjectiveService.SeekByValue(seekValue, ConfigQualitativeObjective.Informer, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeObjective>();
        }

        [HttpPost]
        [Route("ConfigQualitativeObjective/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ConfigQualitativeObjective configQualitativeObjective)
        {
            var result = await this.configQualitativeObjectiveService.Delete(configQualitativeObjective, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfConfigQualitativeKPI
        [HttpPost]
        [Route("ConfigQualitativeObjective/{configQualitativeObjective_id:int}/ConfigQualitativeKPI")]
        public IActionResult CollectionOfConfigQualitativeKPI([FromRoute(Name = "configQualitativeObjective_id")] int id, ConfigQualitativeKPI configQualitativeKPI)
        {
            return this.configQualitativeObjectiveService.CollectionOfConfigQualitativeKPI(id, configQualitativeKPI, this.UserCredit).ToActionResult();
        }
    }
}