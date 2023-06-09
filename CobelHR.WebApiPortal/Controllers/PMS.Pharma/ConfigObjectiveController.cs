using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Pharma.Abstract;
using CobelHR.Entities.PMS.Pharma;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS.Pharma
{
    [Route("api/PMS")]
    public class ConfigObjectiveController : BaseController
    {
        public ConfigObjectiveController(IConfigObjectiveService configObjectiveService)
        {
            this.configObjectiveService = configObjectiveService;
        }

        private IConfigObjectiveService configObjectiveService { get; set; }

        [HttpGet]
        [Route("ConfigObjective/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.configObjectiveService.RetrieveById(id, ConfigObjective.Informer, this.UserCredit);

			return result.ToActionResult<ConfigObjective>();
        }

        [HttpPost]
        [Route("ConfigObjective/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.configObjectiveService.RetrieveAll(ConfigObjective.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ConfigObjective>();
        }
            

        
        [HttpPost]
        [Route("ConfigObjective/Save")]
        public async Task<IActionResult> Save([FromBody] ConfigObjective configObjective)
        {
            var result = await this.configObjectiveService.Save(configObjective, this.UserCredit);

			return result.ToActionResult<ConfigObjective>();
        }

        
        [HttpPost]
        [Route("ConfigObjective/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ConfigObjective configObjective)
        {
            var result = await this.configObjectiveService.SaveAttached(configObjective, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ConfigObjective/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ConfigObjective> configObjectiveList)
        {
            var result = await this.configObjectiveService.SaveBulk(configObjectiveList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ConfigObjective/Seek")]
        public async Task<IActionResult> Seek([FromBody] ConfigObjective configObjective)
        {
            var result = await this.configObjectiveService.Seek(configObjective, this.UserCredit);

			return result.ToActionResult<ConfigObjective>();
        }

        [HttpGet]
        [Route("ConfigObjective/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.configObjectiveService.SeekByValue(seekValue, ConfigObjective.Informer, this.UserCredit);

			return result.ToActionResult<ConfigObjective>();
        }

        [HttpPost]
        [Route("ConfigObjective/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ConfigObjective configObjective)
        {
            var result = await this.configObjectiveService.Delete(configObjective, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfConfigKPI
        [HttpPost]
        [Route("ConfigObjective/{configObjective_id:int}/ConfigKPI")]
        public IActionResult CollectionOfConfigKPI([FromRoute(Name = "configObjective_id")] int id, ConfigKPI configKPI)
        {
            return this.configObjectiveService.CollectionOfConfigKPI(id, configKPI, this.UserCredit).ToActionResult();
        }
    }
}