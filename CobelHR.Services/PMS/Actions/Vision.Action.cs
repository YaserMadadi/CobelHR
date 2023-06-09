
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;


namespace CobelHR.Services.PMS.Actions
{
    public static class Vision_Action
    {
		
        public static async Task<DataResult<Vision>> SaveAttached(this Vision vision, UserCredit userCredit)
        {
            var permissionType = vision.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(vision.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Vision>(-1, "You don't have Save Permission for ''Vision''", vision);

            return await vision.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Vision>> SaveAttached(this Vision vision, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IVisionService visionService = new VisionService();

            var result = await visionService.Save(vision, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Vision>(vision);

            Result childResult = null;

            if(vision.ListOfIndividualDevelopmentPlan.CheckList())
            {
                vision.ListOfIndividualDevelopmentPlan.ForEach(i => i.Vision.Id = result.Id);

                childResult = await vision.ListOfIndividualDevelopmentPlan.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Vision>(vision);
                }
            }

            if(vision.ListOfVisionApproved.CheckList())
            {
                vision.ListOfVisionApproved.ForEach(i => i.Vision.Id = result.Id);

                childResult = await vision.ListOfVisionApproved.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Vision>(vision);
                }
            }

            if(vision.ListOfVisionComment.CheckList())
            {
                vision.ListOfVisionComment.ForEach(i => i.Vision.Id = result.Id);

                childResult = await vision.ListOfVisionComment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Vision>(vision);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Vision>(vision);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Vision>> SaveCollection(this List<Vision> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Vision> result = new SuccessfulDataResult<Vision>();

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
