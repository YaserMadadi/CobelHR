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
    public class SchoolLevelController : BaseController
    {
        public SchoolLevelController(ISchoolLevelService schoolLevelService)
        {
            this.schoolLevelService = schoolLevelService;
        }

        private ISchoolLevelService schoolLevelService { get; set; }

        [HttpGet]
        [Route("SchoolLevel/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.schoolLevelService.RetrieveById(id, SchoolLevel.Informer, this.UserCredit);

			return result.ToActionResult<SchoolLevel>();
        }

        [HttpPost]
        [Route("SchoolLevel/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.schoolLevelService.RetrieveAll(SchoolLevel.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<SchoolLevel>();
        }
            

        
        [HttpPost]
        [Route("SchoolLevel/Save")]
        public async Task<IActionResult> Save([FromBody] SchoolLevel schoolLevel)
        {
            var result = await this.schoolLevelService.Save(schoolLevel, this.UserCredit);

			return result.ToActionResult<SchoolLevel>();
        }   

        
        [HttpPost]
        [Route("SchoolLevel/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] SchoolLevel schoolLevel)
        {
            var result = await this.schoolLevelService.SaveAttached(schoolLevel, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("SchoolLevel/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<SchoolLevel> schoolLevelList)
        {
            var result = await this.schoolLevelService.SaveBulk(schoolLevelList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("SchoolLevel/Seek")]
        public async Task<IActionResult> Seek([FromBody] SchoolLevel schoolLevel)
        {
            var result = await this.schoolLevelService.Seek(schoolLevel, this.UserCredit);

			return result.ToActionResult<SchoolLevel>();
        }

        [HttpGet]
        [Route("SchoolLevel/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.schoolLevelService.SeekByValue(seekValue, SchoolLevel.Informer, this.UserCredit);

			return result.ToActionResult<SchoolLevel>();
        }

        [HttpPost]
        [Route("SchoolLevel/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] SchoolLevel schoolLevel)
        {
            var result = await this.schoolLevelService.Delete(schoolLevel, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfSchoolHistory
        [HttpPost]
        [Route("SchoolLevel/{schoolLevel_id:int}/SchoolHistory")]
        public IActionResult CollectionOfSchoolHistory([FromRoute(Name = "schoolLevel_id")] int id, SchoolHistory schoolHistory)
        {
            return this.schoolLevelService.CollectionOfSchoolHistory(id, schoolHistory, this.UserCredit).ToActionResult();
        }
    }
}