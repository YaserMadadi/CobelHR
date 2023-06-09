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
    public class DepartmentController : BaseController
    {
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        private IDepartmentService departmentService { get; set; }

        [HttpGet]
        [Route("Department/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.departmentService.RetrieveById(id, Department.Informer, this.UserCredit);

			return result.ToActionResult<Department>();
        }

        [HttpPost]
        [Route("Department/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.departmentService.RetrieveAll(Department.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Department>();
        }
            

        
        [HttpPost]
        [Route("Department/Save")]
        public async Task<IActionResult> Save([FromBody] Department department)
        {
            var result = await this.departmentService.Save(department, this.UserCredit);

			return result.ToActionResult<Department>();
        }

        
        [HttpPost]
        [Route("Department/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Department department)
        {
            var result = await this.departmentService.SaveAttached(department, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Department/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Department> departmentList)
        {
            var result = await this.departmentService.SaveBulk(departmentList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Department/Seek")]
        public async Task<IActionResult> Seek([FromBody] Department department)
        {
            var result = await this.departmentService.Seek(department, this.UserCredit);

			return result.ToActionResult<Department>();
        }

        [HttpGet]
        [Route("Department/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.departmentService.SeekByValue(seekValue, Department.Informer, this.UserCredit);

			return result.ToActionResult<Department>();
        }

        [HttpPost]
        [Route("Department/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Department department)
        {
            var result = await this.departmentService.Delete(department, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfUnit
        [HttpPost]
        [Route("Department/{department_id:int}/Unit")]
        public IActionResult CollectionOfUnit([FromRoute(Name = "department_id")] int id, Unit unit)
        {
            return this.departmentService.CollectionOfUnit(id, unit, this.UserCredit).ToActionResult();
        }
    }
}