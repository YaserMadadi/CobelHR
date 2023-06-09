
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
    public static class ScoreCell_Action
    {
		
        public static async Task<DataResult<ScoreCell>> SaveAttached(this ScoreCell scoreCell, UserCredit userCredit)
        {
            var permissionType = scoreCell.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(scoreCell.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ScoreCell>(-1, "You don't have Save Permission for ''ScoreCell''", scoreCell);

            return await scoreCell.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ScoreCell>> SaveAttached(this ScoreCell scoreCell, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IScoreCellService scoreCellService = new ScoreCellService();

            var result = await scoreCellService.Save(scoreCell, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ScoreCell>(scoreCell);

            Result childResult = null;

            if(scoreCell.ListOfAppraiseResult.CheckList())
            {
                scoreCell.ListOfAppraiseResult.ForEach(i => i.ScoreCell.Id = result.Id);

                childResult = await scoreCell.ListOfAppraiseResult.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ScoreCell>(scoreCell);
                }
            }

            if(scoreCell.ListOfCellAction.CheckList())
            {
                scoreCell.ListOfCellAction.ForEach(i => i.ScoreCell.Id = result.Id);

                childResult = await scoreCell.ListOfCellAction.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ScoreCell>(scoreCell);
                }
            }

            if(scoreCell.ListOfFinalAppraise.CheckList())
            {
                scoreCell.ListOfFinalAppraise.ForEach(i => i.ScoreCell.Id = result.Id);

                childResult = await scoreCell.ListOfFinalAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ScoreCell>(scoreCell);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ScoreCell>(scoreCell);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ScoreCell>> SaveCollection(this List<ScoreCell> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ScoreCell> result = new SuccessfulDataResult<ScoreCell>();

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
