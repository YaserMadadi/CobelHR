
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Abstract;
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;
using CobelHR.Services.LAD.Actions;
using CobelHR.Entities.LAD;
using CobelHR.Services.IDEA.Actions;
using CobelHR.Entities.IDEA;
using CobelHR.Services.Core.Actions;
using CobelHR.Entities.Core;


namespace CobelHR.Services.HR.Actions
{
    public static class Employee_Action
    {
		
        public static async Task<DataResult<Employee>> SaveAttached(this Employee employee, UserCredit userCredit)
        {
            var permissionType = employee.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(employee.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Employee>(-1, "You don't have Save Permission for ''Employee''", employee);

            return await employee.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Employee>> SaveAttached(this Employee employee, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IEmployeeService employeeService = new EmployeeService();

            var result = await employeeService.Save(employee, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Employee>(employee);

            Result childResult = null;

            if(employee.ListOfAssessment.CheckList())
            {
                employee.ListOfAssessment.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfAppraiser_BehavioralAppraise.CheckList())
            {
                employee.ListOfAppraiser_BehavioralAppraise.ForEach(i => i.Appraiser.Id = result.Id);

                childResult = await employee.ListOfAppraiser_BehavioralAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfCoaching.CheckList())
            {
                employee.ListOfCoaching.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfCoaching.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfContract.CheckList())
            {
                employee.ListOfContract.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfContract.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfCriticalIncident.CheckList())
            {
                employee.ListOfCriticalIncident.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfCriticalIncident.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfWriter_CriticalIncidentRecognition.CheckList())
            {
                employee.ListOfWriter_CriticalIncidentRecognition.ForEach(i => i.Writer.Id = result.Id);

                childResult = await employee.ListOfWriter_CriticalIncidentRecognition.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfEmployeeDetail.CheckList())
            {
                employee.ListOfEmployeeDetail.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfEmployeeDetail.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfEmployeeEvent.CheckList())
            {
                employee.ListOfEmployeeEvent.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfEmployeeEvent.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfEmployeeNotification.CheckList())
            {
                employee.ListOfEmployeeNotification.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfEmployeeNotification.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfAppraiser_FunctionalAppraise.CheckList())
            {
                employee.ListOfAppraiser_FunctionalAppraise.ForEach(i => i.Appraiser.Id = result.Id);

                childResult = await employee.ListOfAppraiser_FunctionalAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfCommenter_FunctionalKPIComment.CheckList())
            {
                employee.ListOfCommenter_FunctionalKPIComment.ForEach(i => i.Commenter.Id = result.Id);

                childResult = await employee.ListOfCommenter_FunctionalKPIComment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfCommenter_FunctionalObjectiveComment.CheckList())
            {
                employee.ListOfCommenter_FunctionalObjectiveComment.ForEach(i => i.Commenter.Id = result.Id);

                childResult = await employee.ListOfCommenter_FunctionalObjectiveComment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfImpersonate.CheckList())
            {
                employee.ListOfImpersonate.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfImpersonate.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfPositionAssignment.CheckList())
            {
                employee.ListOfPositionAssignment.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfPositionAssignment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfAppraiser_QualitativeAppraise.CheckList())
            {
                employee.ListOfAppraiser_QualitativeAppraise.ForEach(i => i.Appraiser.Id = result.Id);

                childResult = await employee.ListOfAppraiser_QualitativeAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfRoleMember.CheckList())
            {
                employee.ListOfRoleMember.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfRoleMember.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfTargetSetting.CheckList())
            {
                employee.ListOfTargetSetting.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfTargetSetting.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfTraining.CheckList())
            {
                employee.ListOfTraining.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfTraining.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfVision.CheckList())
            {
                employee.ListOfVision.ForEach(i => i.Employee.Id = result.Id);

                childResult = await employee.ListOfVision.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfByEmployee_VisionApproved.CheckList())
            {
                employee.ListOfByEmployee_VisionApproved.ForEach(i => i.ByEmployee.Id = result.Id);

                childResult = await employee.ListOfByEmployee_VisionApproved.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }

            if(employee.ListOfCommentator_VisionComment.CheckList())
            {
                employee.ListOfCommentator_VisionComment.ForEach(i => i.Commentator.Id = result.Id);

                childResult = await employee.ListOfCommentator_VisionComment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Employee>(employee);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Employee>(employee);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Employee>> SaveCollection(this List<Employee> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Employee> result = new SuccessfulDataResult<Employee>();

            foreach (var item in list)
            {
                result = await item.SaveAttached(userCredit, transaction, depth + 1);

                if (result.Id <= 0)

                    break;
            }

            return result;
        }
    }
}
