using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;
using CobelHR.Entities.Core;
using CobelHR.Entities.IDEA;



namespace CobelHR.Services.HR.Abstract
{
    public interface IEmployeeService : IService<Employee>
    {
        DataResult<List<Assessment>> CollectionOfAssessment(int employee_Id, Assessment assessment, UserCredit userCredit);

		DataResult<List<BehavioralAppraise>> CollectionOfBehavioralAppraise_Appraiser(int employee_Id, BehavioralAppraise behavioralAppraise, UserCredit userCredit);

		DataResult<List<Coaching>> CollectionOfCoaching(int employee_Id, Coaching coaching, UserCredit userCredit);

		DataResult<List<Contract>> CollectionOfContract(int employee_Id, Contract contract, UserCredit userCredit);

		DataResult<List<CriticalIncident>> CollectionOfCriticalIncident(int employee_Id, CriticalIncident criticalIncident, UserCredit userCredit);

		DataResult<List<CriticalIncidentRecognition>> CollectionOfCriticalIncidentRecognition_Writer(int employee_Id, CriticalIncidentRecognition criticalIncidentRecognition, UserCredit userCredit);

		DataResult<List<EmployeeDetail>> CollectionOfEmployeeDetail(int employee_Id, EmployeeDetail employeeDetail, UserCredit userCredit);

		DataResult<List<EmployeeEvent>> CollectionOfEmployeeEvent(int employee_Id, EmployeeEvent employeeEvent, UserCredit userCredit);

		DataResult<List<EmployeeNotification>> CollectionOfEmployeeNotification(int employee_Id, EmployeeNotification employeeNotification, UserCredit userCredit);

		DataResult<List<FunctionalAppraise>> CollectionOfFunctionalAppraise_Appraiser(int employee_Id, FunctionalAppraise functionalAppraise, UserCredit userCredit);

		DataResult<List<FunctionalKPIComment>> CollectionOfFunctionalKPIComment_Commenter(int employee_Id, FunctionalKPIComment functionalKPIComment, UserCredit userCredit);

		DataResult<List<FunctionalObjectiveComment>> CollectionOfFunctionalObjectiveComment_Commenter(int employee_Id, FunctionalObjectiveComment functionalObjectiveComment, UserCredit userCredit);

		DataResult<List<Impersonate>> CollectionOfImpersonate(int employee_Id, Impersonate impersonate, UserCredit userCredit);

		DataResult<List<PositionAssignment>> CollectionOfPositionAssignment(int employee_Id, PositionAssignment positionAssignment, UserCredit userCredit);

		DataResult<List<QualitativeAppraise>> CollectionOfQualitativeAppraise_Appraiser(int employee_Id, QualitativeAppraise qualitativeAppraise, UserCredit userCredit);

		DataResult<List<RoleMember>> CollectionOfRoleMember(int employee_Id, RoleMember roleMember, UserCredit userCredit);

		DataResult<List<TargetSetting>> CollectionOfTargetSetting(int employee_Id, TargetSetting targetSetting, UserCredit userCredit);

		DataResult<List<Training>> CollectionOfTraining(int employee_Id, Training training, UserCredit userCredit);

		DataResult<List<Vision>> CollectionOfVision(int employee_Id, Vision vision, UserCredit userCredit);

		DataResult<List<VisionApproved>> CollectionOfVisionApproved_ByEmployee(int employee_Id, VisionApproved visionApproved, UserCredit userCredit);

		DataResult<List<VisionComment>> CollectionOfVisionComment_Commentator(int employee_Id, VisionComment visionComment, UserCredit userCredit);
    }
}
