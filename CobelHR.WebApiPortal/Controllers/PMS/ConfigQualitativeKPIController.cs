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
    public class ConfigQualitativeKPIController : BaseController
    {
        public ConfigQualitativeKPIController(IConfigQualitativeKPIService configQualitativeKPIService)
        {
            this.configQualitativeKPIService = configQualitativeKPIService;
        }

        private IConfigQualitativeKPIService configQualitativeKPIService { get; set; }

        [HttpGet]
        [Route("ConfigQualitativeKPI/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.configQualitativeKPIService.RetrieveById(id, ConfigQualitativeKPI.Informer, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeKPI>();
        }

        [HttpPost]
        [Route("ConfigQualitativeKPI/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.configQualitativeKPIService.RetrieveAll(ConfigQualitativeKPI.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeKPI>();
        }
            

        
        [HttpPost]
        [Route("ConfigQualitativeKPI/Save")]
        public async Task<IActionResult> Save([FromBody] ConfigQualitativeKPI configQualitativeKPI)
        {
            var result = await this.configQualitativeKPIService.Save(configQualitativeKPI, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeKPI>();
        }

        
        [HttpPost]
        [Route("ConfigQualitativeKPI/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ConfigQualitativeKPI configQualitativeKPI)
        {
            var result = await this.configQualitativeKPIService.SaveAttached(configQualitativeKPI, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ConfigQualitativeKPI/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ConfigQualitativeKPI> configQualitativeKPIList)
        {
            var result = await this.configQualitativeKPIService.SaveBulk(configQualitativeKPIList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ConfigQualitativeKPI/Seek")]
        public async Task<IActionResult> Seek([FromBody] ConfigQualitativeKPI configQualitativeKPI)
        {
            var result = await this.configQualitativeKPIService.Seek(configQualitativeKPI, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeKPI>();
        }

        [HttpGet]
        [Route("ConfigQualitativeKPI/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.configQualitativeKPIService.SeekByValue(seekValue, ConfigQualitativeKPI.Informer, this.UserCredit);

			return result.ToActionResult<ConfigQualitativeKPI>();
        }

        [HttpPost]
        [Route("ConfigQualitativeKPI/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ConfigQualitativeKPI configQualitativeKPI)
        {
            var result = await this.configQualitativeKPIService.Delete(configQualitativeKPI, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}