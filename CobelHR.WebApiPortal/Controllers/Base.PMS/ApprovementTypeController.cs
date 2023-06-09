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
    public class ApprovementTypeController : BaseController
    {
        public ApprovementTypeController(IApprovementTypeService approvementTypeService)
        {
            this.approvementTypeService = approvementTypeService;
        }

        private IApprovementTypeService approvementTypeService { get; set; }

        [HttpGet]
        [Route("ApprovementType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.approvementTypeService.RetrieveById(id, ApprovementType.Informer, this.UserCredit);

			return result.ToActionResult<ApprovementType>();
        }

        [HttpPost]
        [Route("ApprovementType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.approvementTypeService.RetrieveAll(ApprovementType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ApprovementType>();
        }
            

        
        [HttpPost]
        [Route("ApprovementType/Save")]
        public async Task<IActionResult> Save([FromBody] ApprovementType approvementType)
        {
            var result = await this.approvementTypeService.Save(approvementType, this.UserCredit);

			return result.ToActionResult<ApprovementType>();
        }

        
        [HttpPost]
        [Route("ApprovementType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ApprovementType approvementType)
        {
            var result = await this.approvementTypeService.SaveAttached(approvementType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ApprovementType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ApprovementType> approvementTypeList)
        {
            var result = await this.approvementTypeService.SaveBulk(approvementTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ApprovementType/Seek")]
        public async Task<IActionResult> Seek([FromBody] ApprovementType approvementType)
        {
            var result = await this.approvementTypeService.Seek(approvementType, this.UserCredit);

			return result.ToActionResult<ApprovementType>();
        }

        [HttpGet]
        [Route("ApprovementType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.approvementTypeService.SeekByValue(seekValue, ApprovementType.Informer, this.UserCredit);

			return result.ToActionResult<ApprovementType>();
        }

        [HttpPost]
        [Route("ApprovementType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ApprovementType approvementType)
        {
            var result = await this.approvementTypeService.Delete(approvementType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfVisionApproved
        [HttpPost]
        [Route("ApprovementType/{approvementType_id:int}/VisionApproved")]
        public IActionResult CollectionOfVisionApproved([FromRoute(Name = "approvementType_id")] int id, VisionApproved visionApproved)
        {
            return this.approvementTypeService.CollectionOfVisionApproved(id, visionApproved, this.UserCredit).ToActionResult();
        }
    }
}