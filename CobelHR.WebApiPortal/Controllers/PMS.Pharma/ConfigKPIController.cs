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
    [Route("api/PMS.Pharma")]
    public class ConfigKPIController : BaseController
    {
        public ConfigKPIController(IConfigKPIService configKPIService)
        {
            this.configKPIService = configKPIService;
        }

        private IConfigKPIService configKPIService { get; set; }

        [HttpGet]
        [Route("ConfigKPI/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.configKPIService.RetrieveById(id, ConfigKPI.Informer, this.UserCredit);

			return result.ToActionResult<ConfigKPI>();
        }

        [HttpPost]
        [Route("ConfigKPI/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.configKPIService.RetrieveAll(ConfigKPI.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ConfigKPI>();
        }
            

        
        [HttpPost]
        [Route("ConfigKPI/Save")]
        public async Task<IActionResult> Save([FromBody] ConfigKPI configKPI)
        {
            var result = await this.configKPIService.Save(configKPI, this.UserCredit);

			return result.ToActionResult<ConfigKPI>();
        }

        
        [HttpPost]
        [Route("ConfigKPI/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ConfigKPI configKPI)
        {
            var result = await this.configKPIService.SaveAttached(configKPI, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ConfigKPI/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ConfigKPI> configKPIList)
        {
            var result = await this.configKPIService.SaveBulk(configKPIList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ConfigKPI/Seek")]
        public async Task<IActionResult> Seek([FromBody] ConfigKPI configKPI)
        {
            var result = await this.configKPIService.Seek(configKPI, this.UserCredit);

			return result.ToActionResult<ConfigKPI>();
        }

        [HttpGet]
        [Route("ConfigKPI/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.configKPIService.SeekByValue(seekValue, ConfigKPI.Informer, this.UserCredit);

			return result.ToActionResult<ConfigKPI>();
        }

        [HttpPost]
        [Route("ConfigKPI/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ConfigKPI configKPI)
        {
            var result = await this.configKPIService.Delete(configKPI, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}