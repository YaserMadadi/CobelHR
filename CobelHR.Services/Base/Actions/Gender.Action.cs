
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Abstract;
using CobelHR.Services.LAD.Actions;
using CobelHR.Entities.LAD;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.Actions
{
    public static class Gender_Action
    {
		
        public static async Task<DataResult<Gender>> SaveAttached(this Gender gender, UserCredit userCredit)
        {
            var permissionType = gender.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(gender.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Gender>(-1, "You don't have Save Permission for ''Gender''", gender);

            return await gender.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Gender>> SaveAttached(this Gender gender, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IGenderService genderService = new GenderService();

            var result = await genderService.Save(gender, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Gender>(gender);

            Result childResult = null;

            if(gender.ListOfAssessor.CheckList())
            {
                gender.ListOfAssessor.ForEach(i => i.Gender.Id = result.Id);

                childResult = await gender.ListOfAssessor.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Gender>(gender);
                }
            }

            if(gender.ListOfCoach.CheckList())
            {
                gender.ListOfCoach.ForEach(i => i.Gender.Id = result.Id);

                childResult = await gender.ListOfCoach.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Gender>(gender);
                }
            }

            if(gender.ListOfPerson.CheckList())
            {
                gender.ListOfPerson.ForEach(i => i.Gender.Id = result.Id);

                childResult = await gender.ListOfPerson.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Gender>(gender);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Gender>(gender);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Gender>> SaveCollection(this List<Gender> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Gender> result = new SuccessfulDataResult<Gender>();

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
