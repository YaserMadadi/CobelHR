using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;
using CobelHR.Entities.Core;
using CobelHR.Entities.IDEA;


namespace CobelHR.Services.HR
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        public EmployeeService() : base()
        {
        }

        public override async Task<DataResult<Employee>> SaveAttached(Employee employee, UserCredit userCredit)
        {
            return await employee.SaveAttached(userCredit);
        }

        public DataResult<List<Assessment>> CollectionOfAssessment(int employee_Id, Assessment assessment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfAssessment]";

            return this.CollectionOf<Assessment>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessment.ToJson()));
        }

		public DataResult<List<BehavioralAppraise>> CollectionOfBehavioralAppraise_Appraiser(int employee_Id, BehavioralAppraise behavioralAppraise, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee(Appraiser).CollectionOfBehavioralAppraise]";

            return this.CollectionOf<BehavioralAppraise>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", behavioralAppraise.ToJson()));
        }

		public DataResult<List<Coaching>> CollectionOfCoaching(int employee_Id, Coaching coaching, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfCoaching]";

            return this.CollectionOf<Coaching>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coaching.ToJson()));
        }

		public DataResult<List<Contract>> CollectionOfContract(int employee_Id, Contract contract, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfContract]";

            return this.CollectionOf<Contract>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", contract.ToJson()));
        }

		public DataResult<List<CriticalIncident>> CollectionOfCriticalIncident(int employee_Id, CriticalIncident criticalIncident, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfCriticalIncident]";

            return this.CollectionOf<CriticalIncident>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", criticalIncident.ToJson()));
        }

		public DataResult<List<CriticalIncidentRecognition>> CollectionOfCriticalIncidentRecognition_Writer(int employee_Id, CriticalIncidentRecognition criticalIncidentRecognition, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee(Writer).CollectionOfCriticalIncidentRecognition]";

            return this.CollectionOf<CriticalIncidentRecognition>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", criticalIncidentRecognition.ToJson()));
        }

		public DataResult<List<EmployeeDetail>> CollectionOfEmployeeDetail(int employee_Id, EmployeeDetail employeeDetail, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfEmployeeDetail]";

            return this.CollectionOf<EmployeeDetail>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", employeeDetail.ToJson()));
        }

		public DataResult<List<EmployeeEvent>> CollectionOfEmployeeEvent(int employee_Id, EmployeeEvent employeeEvent, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfEmployeeEvent]";

            return this.CollectionOf<EmployeeEvent>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", employeeEvent.ToJson()));
        }

		public DataResult<List<EmployeeNotification>> CollectionOfEmployeeNotification(int employee_Id, EmployeeNotification employeeNotification, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfEmployeeNotification]";

            return this.CollectionOf<EmployeeNotification>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", employeeNotification.ToJson()));
        }

		public DataResult<List<FunctionalAppraise>> CollectionOfFunctionalAppraise_Appraiser(int employee_Id, FunctionalAppraise functionalAppraise, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee(Appraiser).CollectionOfFunctionalAppraise]";

            return this.CollectionOf<FunctionalAppraise>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalAppraise.ToJson()));
        }

		public DataResult<List<FunctionalKPIComment>> CollectionOfFunctionalKPIComment_Commenter(int employee_Id, FunctionalKPIComment functionalKPIComment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee(Commenter).CollectionOfFunctionalKPIComment]";

            return this.CollectionOf<FunctionalKPIComment>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalKPIComment.ToJson()));
        }

		public DataResult<List<FunctionalObjectiveComment>> CollectionOfFunctionalObjectiveComment_Commenter(int employee_Id, FunctionalObjectiveComment functionalObjectiveComment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee(Commenter).CollectionOfFunctionalObjectiveComment]";

            return this.CollectionOf<FunctionalObjectiveComment>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalObjectiveComment.ToJson()));
        }

		public DataResult<List<Impersonate>> CollectionOfImpersonate(int employee_Id, Impersonate impersonate, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfImpersonate]";

            return this.CollectionOf<Impersonate>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", impersonate.ToJson()));
        }

		public DataResult<List<PositionAssignment>> CollectionOfPositionAssignment(int employee_Id, PositionAssignment positionAssignment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfPositionAssignment]";

            return this.CollectionOf<PositionAssignment>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", positionAssignment.ToJson()));
        }

		public DataResult<List<QualitativeAppraise>> CollectionOfQualitativeAppraise_Appraiser(int employee_Id, QualitativeAppraise qualitativeAppraise, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee(Appraiser).CollectionOfQualitativeAppraise]";

            return this.CollectionOf<QualitativeAppraise>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", qualitativeAppraise.ToJson()));
        }

		public DataResult<List<RoleMember>> CollectionOfRoleMember(int employee_Id, RoleMember roleMember, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfRoleMember]";

            return this.CollectionOf<RoleMember>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", roleMember.ToJson()));
        }

		public DataResult<List<TargetSetting>> CollectionOfTargetSetting(int employee_Id, TargetSetting targetSetting, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfTargetSetting]";

            return this.CollectionOf<TargetSetting>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", targetSetting.ToJson()));
        }

		public DataResult<List<Training>> CollectionOfTraining(int employee_Id, Training training, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfTraining]";

            return this.CollectionOf<Training>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", training.ToJson()));
        }

		public DataResult<List<Vision>> CollectionOfVision(int employee_Id, Vision vision, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee.CollectionOfVision]";

            return this.CollectionOf<Vision>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", vision.ToJson()));
        }

		public DataResult<List<VisionApproved>> CollectionOfVisionApproved_ByEmployee(int employee_Id, VisionApproved visionApproved, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee(ByEmployee).CollectionOfVisionApproved]";

            return this.CollectionOf<VisionApproved>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", visionApproved.ToJson()));
        }

		public DataResult<List<VisionComment>> CollectionOfVisionComment_Commentator(int employee_Id, VisionComment visionComment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Employee(Commentator).CollectionOfVisionComment]";

            return this.CollectionOf<VisionComment>(procedureName,
                                                    new SqlParameter("@Id",employee_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", visionComment.ToJson()));
        }
    }
}