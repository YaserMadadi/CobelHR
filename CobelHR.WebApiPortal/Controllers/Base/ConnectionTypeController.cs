using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class ConnectionTypeController : BaseController
    {
        public ConnectionTypeController(IConnectionTypeService connectionTypeService)
        {
            this.connectionTypeService = connectionTypeService;
        }

        private IConnectionTypeService connectionTypeService { get; set; }

        [HttpGet]
        [Route("ConnectionType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.connectionTypeService.RetrieveById(id, ConnectionType.Informer, this.UserCredit);

			return result.ToActionResult<ConnectionType>();
        }

        [HttpPost]
        [Route("ConnectionType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.connectionTypeService.RetrieveAll(ConnectionType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ConnectionType>();
        }
            

        
        [HttpPost]
        [Route("ConnectionType/Save")]
        public async Task<IActionResult> Save([FromBody] ConnectionType connectionType)
        {
            var result = await this.connectionTypeService.Save(connectionType, this.UserCredit);

			return result.ToActionResult<ConnectionType>();
        }

        
        [HttpPost]
        [Route("ConnectionType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ConnectionType connectionType)
        {
            var result = await this.connectionTypeService.SaveAttached(connectionType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ConnectionType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ConnectionType> connectionTypeList)
        {
            var result = await this.connectionTypeService.SaveBulk(connectionTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ConnectionType/Seek")]
        public async Task<IActionResult> Seek([FromBody] ConnectionType connectionType)
        {
            var result = await this.connectionTypeService.Seek(connectionType, this.UserCredit);

			return result.ToActionResult<ConnectionType>();
        }

        [HttpGet]
        [Route("ConnectionType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.connectionTypeService.SeekByValue(seekValue, ConnectionType.Informer, this.UserCredit);

			return result.ToActionResult<ConnectionType>();
        }

        [HttpPost]
        [Route("ConnectionType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ConnectionType connectionType)
        {
            var result = await this.connectionTypeService.Delete(connectionType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAssessorConnectionLine
        [HttpPost]
        [Route("ConnectionType/{connectionType_id:int}/AssessorConnectionLine")]
        public IActionResult CollectionOfAssessorConnectionLine([FromRoute(Name = "connectionType_id")] int id, AssessorConnectionLine assessorConnectionLine)
        {
            return this.connectionTypeService.CollectionOfAssessorConnectionLine(id, assessorConnectionLine, this.UserCredit).ToActionResult();
        }

		// CollectionOfCoachConnectionLine
        [HttpPost]
        [Route("ConnectionType/{connectionType_id:int}/CoachConnectionLine")]
        public IActionResult CollectionOfCoachConnectionLine([FromRoute(Name = "connectionType_id")] int id, CoachConnectionLine coachConnectionLine)
        {
            return this.connectionTypeService.CollectionOfCoachConnectionLine(id, coachConnectionLine, this.UserCredit).ToActionResult();
        }

		// CollectionOfPersonConnection
        [HttpPost]
        [Route("ConnectionType/{connectionType_id:int}/PersonConnection")]
        public IActionResult CollectionOfPersonConnection([FromRoute(Name = "connectionType_id")] int id, PersonConnection personConnection)
        {
            return this.connectionTypeService.CollectionOfPersonConnection(id, personConnection, this.UserCredit).ToActionResult();
        }
    }
}