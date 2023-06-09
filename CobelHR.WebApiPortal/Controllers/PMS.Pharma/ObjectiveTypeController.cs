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
    public class ObjectiveTypeController : BaseController
    {
        public ObjectiveTypeController(IObjectiveTypeService objectiveTypeService)
        {
            this.objectiveTypeService = objectiveTypeService;
        }

        private IObjectiveTypeService objectiveTypeService { get; set; }

        [HttpGet]
        [Route("ObjectiveType/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.objectiveTypeService.RetrieveById(id, ObjectiveType.Informer, this.UserCredit);

			return result.ToActionResult<ObjectiveType>();
        }

        [HttpPost]
        [Route("ObjectiveType/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.objectiveTypeService.RetrieveAll(ObjectiveType.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<ObjectiveType>();
        }
            

        
        [HttpPost]
        [Route("ObjectiveType/Save")]
        public async Task<IActionResult> Save([FromBody] ObjectiveType objectiveType)
        {
            var result = await this.objectiveTypeService.Save(objectiveType, this.UserCredit);

			return result.ToActionResult<ObjectiveType>();
        }

        
        [HttpPost]
        [Route("ObjectiveType/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] ObjectiveType objectiveType)
        {
            var result = await this.objectiveTypeService.SaveAttached(objectiveType, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("ObjectiveType/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<ObjectiveType> objectiveTypeList)
        {
            var result = await this.objectiveTypeService.SaveBulk(objectiveTypeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("ObjectiveType/Seek")]
        public async Task<IActionResult> Seek([FromBody] ObjectiveType objectiveType)
        {
            var result = await this.objectiveTypeService.Seek(objectiveType, this.UserCredit);

			return result.ToActionResult<ObjectiveType>();
        }

        [HttpGet]
        [Route("ObjectiveType/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.objectiveTypeService.SeekByValue(seekValue, ObjectiveType.Informer, this.UserCredit);

			return result.ToActionResult<ObjectiveType>();
        }

        [HttpPost]
        [Route("ObjectiveType/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] ObjectiveType objectiveType)
        {
            var result = await this.objectiveTypeService.Delete(objectiveType, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfObjective
        [HttpPost]
        [Route("ObjectiveType/{objectiveType_id:int}/Objective")]
        public IActionResult CollectionOfObjective([FromRoute(Name = "objectiveType_id")] int id, Objective objective)
        {
            return this.objectiveTypeService.CollectionOfObjective(id, objective, this.UserCredit).ToActionResult();
        }
    }
}