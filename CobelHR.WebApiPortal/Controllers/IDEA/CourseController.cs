using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.IDEA.Abstract;
using CobelHR.Entities.IDEA;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.IDEA
{
    [Route("api/IDEA")]
    public class CourseController : BaseController
    {
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        private ICourseService courseService { get; set; }

        [HttpGet]
        [Route("Course/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.courseService.RetrieveById(id, Course.Informer, this.UserCredit);

			return result.ToActionResult<Course>();
        }

        [HttpPost]
        [Route("Course/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.courseService.RetrieveAll(Course.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Course>();
        }
            

        
        [HttpPost]
        [Route("Course/Save")]
        public async Task<IActionResult> Save([FromBody] Course course)
        {
            var result = await this.courseService.Save(course, this.UserCredit);

			return result.ToActionResult<Course>();
        }

        
        [HttpPost]
        [Route("Course/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Course course)
        {
            var result = await this.courseService.SaveAttached(course, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Course/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Course> courseList)
        {
            var result = await this.courseService.SaveBulk(courseList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Course/Seek")]
        public async Task<IActionResult> Seek([FromBody] Course course)
        {
            var result = await this.courseService.Seek(course, this.UserCredit);

			return result.ToActionResult<Course>();
        }

        [HttpGet]
        [Route("Course/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.courseService.SeekByValue(seekValue, Course.Informer, this.UserCredit);

			return result.ToActionResult<Course>();
        }

        [HttpPost]
        [Route("Course/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Course course)
        {
            var result = await this.courseService.Delete(course, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfTraining
        [HttpPost]
        [Route("Course/{course_id:int}/Training")]
        public IActionResult CollectionOfTraining([FromRoute(Name = "course_id")] int id, Training training)
        {
            return this.courseService.CollectionOfTraining(id, training, this.UserCredit).ToActionResult();
        }
    }
}