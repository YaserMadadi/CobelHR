using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;
using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;
using CobelHR.Entities.Core;
using CobelHR.Entities.IDEA;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class EmployeeController : BaseController
    {
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        private IEmployeeService employeeService { get; set; }

        [HttpGet]
        [Route("Employee/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.employeeService.RetrieveById(id, Employee.Informer, this.UserCredit);

			return result.ToActionResult<Employee>();
        }

        [HttpPost]
        [Route("Employee/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.employeeService.RetrieveAll(Employee.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Employee>();
        }



        [HttpPost]
        [Route("Employee/Save")]
        public async Task<IActionResult> Save([FromBody] Employee employee)
        {
            var result = await this.employeeService.Save(employee, this.UserCredit);

			return result.ToActionResult<Employee>();
        }


        [HttpPost]
        [Route("Employee/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Employee employee)
        {
            var result = await this.employeeService.SaveAttached(employee, this.UserCredit);

			return result.ToActionResult();
        }


        [HttpPost]
        [Route("Employee/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Employee> employeeList)
        {
            var result = await this.employeeService.SaveBulk(employeeList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Employee/Seek")]
        public async Task<IActionResult> Seek([FromBody] Employee employee)
        {
            var result = await this.employeeService.Seek(employee, this.UserCredit);

			return result.ToActionResult<Employee>();
        }

        [HttpGet]
        [Route("Employee/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.employeeService.SeekByValue(seekValue, Employee.Informer, this.UserCredit);

			return result.ToActionResult<Employee>();
        }

        [HttpPost]
        [Route("Employee/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Employee employee)
        {
            var result = await this.employeeService.Delete(employee, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAssessment
        //[HttpPost]
        //[Route("Employee/{employee_id:int}/Assessment")]
        //public IActionResult CollectionOfAssessment([FromRoute(Name = "employee_id")] int id, Assessment assessment)
        //{
        //    return this.employeeService.CollectionOfAssessment(id, assessment, this.UserCredit).ToActionResult();
        //}

        // CollectionOfBehavioralAppraise_Appraiser
        [HttpPost]
        [Route("Appraiser/{employee_id:int}/BehavioralAppraise")]
        public IActionResult CollectionOfBehavioralAppraise_Appraiser([FromRoute(Name = "employee_id")] int id, BehavioralAppraise behavioralAppraise)
        {
            return this.employeeService.CollectionOfBehavioralAppraise_Appraiser(id, behavioralAppraise, this.UserCredit).ToActionResult();
        }

        // CollectionOfCoaching
        //[HttpPost]
        //[Route("Employee/{employee_id:int}/Coaching")]
        //public IActionResult CollectionOfCoaching([FromRoute(Name = "employee_id")] int id, Coaching coaching)
        //{
        //    return this.employeeService.CollectionOfCoaching(id, coaching, this.UserCredit).ToActionResult();
        //}

        // CollectionOfContract
        [HttpPost]
        [Route("Employee/{employee_id:int}/Contract")]
        public IActionResult CollectionOfContract([FromRoute(Name = "employee_id")] int id, Contract contract)
        {
            return this.employeeService.CollectionOfContract(id, contract, this.UserCredit).ToActionResult();
        }

        // CollectionOfCriticalIncident
        [HttpPost]
        [Route("Employee/{employee_id:int}/CriticalIncident")]
        public IActionResult CollectionOfCriticalIncident([FromRoute(Name = "employee_id")] int id, CriticalIncident criticalIncident)
        {
            return this.employeeService.CollectionOfCriticalIncident(id, criticalIncident, this.UserCredit).ToActionResult();
        }

        // CollectionOfCriticalIncidentRecognition_Writer
        [HttpPost]
        [Route("Writer/{employee_id:int}/CriticalIncidentRecognition")]
        public IActionResult CollectionOfCriticalIncidentRecognition_Writer([FromRoute(Name = "employee_id")] int id, CriticalIncidentRecognition criticalIncidentRecognition)
        {
            return this.employeeService.CollectionOfCriticalIncidentRecognition_Writer(id, criticalIncidentRecognition, this.UserCredit).ToActionResult();
        }

        // CollectionOfEmployeeDetail
        [HttpPost]
        [Route("Employee/{employee_id:int}/EmployeeDetail")]
        public IActionResult CollectionOfEmployeeDetail([FromRoute(Name = "employee_id")] int id, EmployeeDetail employeeDetail)
        {
            return this.employeeService.CollectionOfEmployeeDetail(id, employeeDetail, this.UserCredit).ToActionResult();
        }

        // CollectionOfEmployeeEvent
        [HttpPost]
        [Route("Employee/{employee_id:int}/EmployeeEvent")]
        public IActionResult CollectionOfEmployeeEvent([FromRoute(Name = "employee_id")] int id, EmployeeEvent employeeEvent)
        {
            return this.employeeService.CollectionOfEmployeeEvent(id, employeeEvent, this.UserCredit).ToActionResult();
        }

        // CollectionOfEmployeeNotification
        [HttpPost]
        [Route("Employee/{employee_id:int}/EmployeeNotification")]
        public IActionResult CollectionOfEmployeeNotification([FromRoute(Name = "employee_id")] int id, EmployeeNotification employeeNotification)
        {
            return this.employeeService.CollectionOfEmployeeNotification(id, employeeNotification, this.UserCredit).ToActionResult();
        }

        // CollectionOfFunctionalAppraise_Appraiser
        [HttpPost]
        [Route("Appraiser/{employee_id:int}/FunctionalAppraise")]
        public IActionResult CollectionOfFunctionalAppraise_Appraiser([FromRoute(Name = "employee_id")] int id, FunctionalAppraise functionalAppraise)
        {
            return this.employeeService.CollectionOfFunctionalAppraise_Appraiser(id, functionalAppraise, this.UserCredit).ToActionResult();
        }

        // CollectionOfFunctionalKPIComment_Commenter
        [HttpPost]
        [Route("Commenter/{employee_id:int}/FunctionalKPIComment")]
        public IActionResult CollectionOfFunctionalKPIComment_Commenter([FromRoute(Name = "employee_id")] int id, FunctionalKPIComment functionalKPIComment)
        {
            return this.employeeService.CollectionOfFunctionalKPIComment_Commenter(id, functionalKPIComment, this.UserCredit).ToActionResult();
        }

        // CollectionOfFunctionalObjectiveComment_Commenter
        [HttpPost]
        [Route("Commenter/{employee_id:int}/FunctionalObjectiveComment")]
        public IActionResult CollectionOfFunctionalObjectiveComment_Commenter([FromRoute(Name = "employee_id")] int id, FunctionalObjectiveComment functionalObjectiveComment)
        {
            return this.employeeService.CollectionOfFunctionalObjectiveComment_Commenter(id, functionalObjectiveComment, this.UserCredit).ToActionResult();
        }

        // CollectionOfImpersonate
        [HttpPost]
        [Route("Employee/{employee_id:int}/Impersonate")]
        public IActionResult CollectionOfImpersonate([FromRoute(Name = "employee_id")] int id, Impersonate impersonate)
        {
            return this.employeeService.CollectionOfImpersonate(id, impersonate, this.UserCredit).ToActionResult();
        }

        // CollectionOfPositionAssignment
        [HttpPost]
        [Route("Employee/{employee_id:int}/PositionAssignment")]
        public IActionResult CollectionOfPositionAssignment([FromRoute(Name = "employee_id")] int id, PositionAssignment positionAssignment)
        {
            return this.employeeService.CollectionOfPositionAssignment(id, positionAssignment, this.UserCredit).ToActionResult();
        }

        // CollectionOfQualitativeAppraise_Appraiser
        [HttpPost]
        [Route("Appraiser/{employee_id:int}/QualitativeAppraise")]
        public IActionResult CollectionOfQualitativeAppraise_Appraiser([FromRoute(Name = "employee_id")] int id, QualitativeAppraise qualitativeAppraise)
        {
            return this.employeeService.CollectionOfQualitativeAppraise_Appraiser(id, qualitativeAppraise, this.UserCredit).ToActionResult();
        }

        // CollectionOfRoleMember
        [HttpPost]
        [Route("Employee/{employee_id:int}/RoleMember")]
        public IActionResult CollectionOfRoleMember([FromRoute(Name = "employee_id")] int id, RoleMember roleMember)
        {
            return this.employeeService.CollectionOfRoleMember(id, roleMember, this.UserCredit).ToActionResult();
        }

        // Collection Of TargetSetting
        [HttpPost]
        [Route("Employee/{employee_id:int}/TargetSetting")]
        public IActionResult CollectionOfTargetSetting([FromRoute(Name = "employee_id")] int id, TargetSetting targetSetting)
        {
            return this.employeeService.CollectionOfTargetSetting(id, targetSetting, this.UserCredit).ToActionResult();
        }

        // Collection Of Training
        [HttpPost]
        [Route("Employee/{employee_id:int}/Training")]
        public IActionResult CollectionOfTraining([FromRoute(Name = "employee_id")] int id, Training training)
        {
            return this.employeeService.CollectionOfTraining(id, training, this.UserCredit).ToActionResult();
        }

        // Collection Of Vision
        [HttpPost]
        [Route("Employee/{employee_id:int}/Vision")]
        public IActionResult CollectionOfVision([FromRoute(Name = "employee_id")] int id, Vision vision)
        {
            return this.employeeService.CollectionOfVision(id, vision, this.UserCredit).ToActionResult();
        }

        // CollectionOfVisionApproved_ByEmployee
        [HttpPost]
        [Route("ByEmployee/{employee_id:int}/VisionApproved")]
        public IActionResult CollectionOfVisionApproved_ByEmployee([FromRoute(Name = "employee_id")] int id, VisionApproved visionApproved)
        {
            return this.employeeService.CollectionOfVisionApproved_ByEmployee(id, visionApproved, this.UserCredit).ToActionResult();
        }

        // CollectionOfVisionComment_Commentator
        [HttpPost]
        [Route("Commentator/{employee_id:int}/VisionComment")]
        public IActionResult CollectionOfVisionComment_Commentator([FromRoute(Name = "employee_id")] int id, VisionComment visionComment)
        {
            return this.employeeService.CollectionOfVisionComment_Commentator(id, visionComment, this.UserCredit).ToActionResult();
        }
    }
}