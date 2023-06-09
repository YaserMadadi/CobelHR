using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class DrivingLicenseTypeController : BaseController
    {
        public DrivingLicenseTypeController(IDrivingLicenseTypeService drivingLicenseTypeService)
        {
            this.drivingLicenseTypeService = drivingLicenseTypeService;
        }

        private IDrivingLicenseTypeService drivingLicenseTypeService { get; set; }

        [HttpGet]
        [Route("DrivingLicenseType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.drivingLicenseTypeService.RetrieveById(id, DrivingLicenseType.Informer, this.UserCredit);

			return result.ToActionResult<DrivingLicenseType>();
        }

        [HttpPost]
        [Route("DrivingLicenseType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.drivingLicenseTypeService.RetrieveAll(DrivingLicenseType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<DrivingLicenseType>();
        }
            

        
        [HttpPost]
        [Route("DrivingLicenseType/Save")]
        public async Task<IActionResult> Save([FromBody] DrivingLicenseType drivingLicenseType)
        {
            var result = await this.drivingLicenseTypeService.Save(drivingLicenseType, this.UserCredit);

			return result.ToActionResult<DrivingLicenseType>();
        }

        
        [HttpPost]
        [Route("DrivingLicenseType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] DrivingLicenseType drivingLicenseType)
        {
            var result = await this.drivingLicenseTypeService.SaveAttached(drivingLicenseType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("DrivingLicenseType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<DrivingLicenseType> drivingLicenseTypeList)
        {
            var result = await this.drivingLicenseTypeService.SaveBulk(drivingLicenseTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("DrivingLicenseType/Seek")]
        public async Task<IActionResult> Seek([FromBody] DrivingLicenseType drivingLicenseType)
        {
            var result = await this.drivingLicenseTypeService.Seek(drivingLicenseType, this.UserCredit);

			return result.ToActionResult<DrivingLicenseType>();
        }

        [HttpGet]
        [Route("DrivingLicenseType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.drivingLicenseTypeService.SeekByValue(seekValue, DrivingLicenseType.Informer, this.UserCredit);

			return result.ToActionResult<DrivingLicenseType>();
        }

        [HttpPost]
        [Route("DrivingLicenseType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] DrivingLicenseType drivingLicenseType)
        {
            var result = await this.drivingLicenseTypeService.Delete(drivingLicenseType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPersonDrivingLicense
        [HttpPost]
        [Route("DrivingLicenseType/{drivingLicenseType_id:int}/PersonDrivingLicense")]
        public IActionResult CollectionOfPersonDrivingLicense([FromRoute(Name = "drivingLicenseType_id")] int id, PersonDrivingLicense personDrivingLicense)
        {
            return this.drivingLicenseTypeService.CollectionOfPersonDrivingLicense(id, personDrivingLicense, this.UserCredit).ToActionResult();
        }
    }
}