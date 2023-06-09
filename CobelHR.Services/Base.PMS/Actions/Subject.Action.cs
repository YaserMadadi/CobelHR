
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS.Actions
{
    public static class Subject_Action
    {
		
        public static async Task<DataResult<Subject>> SaveAttached(this Subject subject, UserCredit userCredit)
        {
            var permissionType = subject.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(subject.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Subject>(-1, "You don't have Save Permission for ''Subject''", subject);

            return await subject.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Subject>> SaveAttached(this Subject subject, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ISubjectService subjectService = new SubjectService();

            var result = await subjectService.Save(subject, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Subject>(subject);

            Result childResult = null;

            if(subject.ListOfIndividualDevelopmentPlan.CheckList())
            {
                subject.ListOfIndividualDevelopmentPlan.ForEach(i => i.Subject.Id = result.Id);

                childResult = await subject.ListOfIndividualDevelopmentPlan.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Subject>(subject);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Subject>(subject);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Subject>> SaveCollection(this List<Subject> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Subject> result = new SuccessfulDataResult<Subject>();

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
