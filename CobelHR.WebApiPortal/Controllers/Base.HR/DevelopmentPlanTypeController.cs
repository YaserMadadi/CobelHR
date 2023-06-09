using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Abstract;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class DevelopmentPlanTypeController : BaseController
    {
        public DevelopmentPlanTypeController(IDevelopmentPlanTypeService developmentPlanTypeService)
        {
            this.developmentPlanTypeService = developmentPlanTypeService;
        }

        private IDevelopmentPlanTypeService developmentPlanTypeService { get; set; }

        [HttpGet]
        [Route("DevelopmentPlanType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.developmentPlanTypeService.RetrieveById(id, DevelopmentPlanType.Informer, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanType>();
        }

        [HttpPost]
        [Route("DevelopmentPlanType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.developmentPlanTypeService.RetrieveAll(DevelopmentPlanType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanType>();
        }



        [HttpPost]
        [Route("DevelopmentPlanType/Save")]
        public async Task<IActionResult> Save([FromBody] DevelopmentPlanType developmentPlanType)
        {
            var result = await this.developmentPlanTypeService.Save(developmentPlanType, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanType>();
        }


        [HttpPost]
        [Route("DevelopmentPlanType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] DevelopmentPlanType developmentPlanType)
        {
            var result = await this.developmentPlanTypeService.SaveAttached(developmentPlanType, this.UserCredit);

			return result.ToActionResult();
        }


        [HttpPost]
        [Route("DevelopmentPlanType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<DevelopmentPlanType> developmentPlanTypeList)
        {
            var result = await this.developmentPlanTypeService.SaveBulk(developmentPlanTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("DevelopmentPlanType/Seek")]
        public async Task<IActionResult> Seek([FromBody] DevelopmentPlanType developmentPlanType)
        {
            var result = await this.developmentPlanTypeService.Seek(developmentPlanType, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanType>();
        }

        [HttpGet]
        [Route("DevelopmentPlanType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.developmentPlanTypeService.SeekByValue(seekValue, DevelopmentPlanType.Informer, this.UserCredit);

			return result.ToActionResult<DevelopmentPlanType>();
        }

        [HttpPost]
        [Route("DevelopmentPlanType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] DevelopmentPlanType developmentPlanType)
        {
            var result = await this.developmentPlanTypeService.Delete(developmentPlanType, id, this.UserCredit);

			return result.ToActionResult();
        }


    }
}