
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


namespace CobelHR.Services.HR.Actions
{
    public static class Position_Action
    {
		
        public static async Task<DataResult<Position>> SaveAttached(this Position position, UserCredit userCredit)
        {
            var permissionType = position.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(position.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Position>(-1, "You don't have Save Permission for ''Position''", position);

            return await position.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Position>> SaveAttached(this Position position, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPositionService positionService = new PositionService();

            var result = await positionService.Save(position, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Position>(position);

            Result childResult = null;

           

            if(position.ListOfChildPosition.CheckList())
            {
                position.ListOfChildPosition.ForEach(i => i.Parent.Id = result.Id);

                childResult = await position.ListOfChildPosition.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Position>(position);
                }
            }

            if(position.ListOfPositionAssignment.CheckList())
            {
                position.ListOfPositionAssignment.ForEach(i => i.Position.Id = result.Id);

                childResult = await position.ListOfPositionAssignment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Position>(position);
                }
            }

            if(position.ListOfProposedPosition_PromotionAssessment.CheckList())
            {
                position.ListOfProposedPosition_PromotionAssessment.ForEach(i => i.ProposedPosition.Id = result.Id);

                childResult = await position.ListOfProposedPosition_PromotionAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Position>(position);
                }
            }

            if(position.ListOfCurrentPosition_PromotionAssessment.CheckList())
            {
                position.ListOfCurrentPosition_PromotionAssessment.ForEach(i => i.CurrentPosition.Id = result.Id);

                childResult = await position.ListOfCurrentPosition_PromotionAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Position>(position);
                }
            }

            if(position.ListOfProposedPosition_RotationAssessment.CheckList())
            {
                position.ListOfProposedPosition_RotationAssessment.ForEach(i => i.ProposedPosition.Id = result.Id);

                childResult = await position.ListOfProposedPosition_RotationAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Position>(position);
                }
            }

            if(position.ListOfCurrentPosition_RotationAssessment.CheckList())
            {
                position.ListOfCurrentPosition_RotationAssessment.ForEach(i => i.CurrentPosition.Id = result.Id);

                childResult = await position.ListOfCurrentPosition_RotationAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Position>(position);
                }
            }

            if(position.ListOfTargetSetting.CheckList())
            {
                position.ListOfTargetSetting.ForEach(i => i.Position.Id = result.Id);

                childResult = await position.ListOfTargetSetting.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Position>(position);
                }
            }

            if(position.ListOfVision.CheckList())
            {
                position.ListOfVision.ForEach(i => i.Position.Id = result.Id);

                childResult = await position.ListOfVision.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Position>(position);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Position>(position);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Position>> SaveCollection(this List<Position> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Position> result = new SuccessfulDataResult<Position>();

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
