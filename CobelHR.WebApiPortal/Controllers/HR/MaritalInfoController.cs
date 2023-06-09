using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class MaritalInfoController : BaseController
    {
        public MaritalInfoController(IMaritalInfoService maritalInfoService)
        {
            this.maritalInfoService = maritalInfoService;
        }

        private IMaritalInfoService maritalInfoService { get; set; }

        [HttpGet]
        [Route("MaritalInfo/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.maritalInfoService.RetrieveById(id, MaritalInfo.Informer, this.UserCredit);

			return result.ToActionResult<MaritalInfo>();
        }

        [HttpPost]
        [Route("MaritalInfo/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.maritalInfoService.RetrieveAll(MaritalInfo.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<MaritalInfo>();
        }
            

        
        [HttpPost]
        [Route("MaritalInfo/Save")]
        public async Task<IActionResult> Save([FromBody] MaritalInfo maritalInfo)
        {
            var result = await this.maritalInfoService.Save(maritalInfo, this.UserCredit);

			return result.ToActionResult<MaritalInfo>();
        }

        
        [HttpPost]
        [Route("MaritalInfo/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] MaritalInfo maritalInfo)
        {
            var result = await this.maritalInfoService.SaveAttached(maritalInfo, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("MaritalInfo/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<MaritalInfo> maritalInfoList)
        {
            var result = await this.maritalInfoService.SaveBulk(maritalInfoList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("MaritalInfo/Seek")]
        public async Task<IActionResult> Seek([FromBody] MaritalInfo maritalInfo)
        {
            var result = await this.maritalInfoService.Seek(maritalInfo, this.UserCredit);

			return result.ToActionResult<MaritalInfo>();
        }

        [HttpGet]
        [Route("MaritalInfo/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.maritalInfoService.SeekByValue(seekValue, MaritalInfo.Informer, this.UserCredit);

			return result.ToActionResult<MaritalInfo>();
        }

        [HttpPost]
        [Route("MaritalInfo/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] MaritalInfo maritalInfo)
        {
            var result = await this.maritalInfoService.Delete(maritalInfo, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}