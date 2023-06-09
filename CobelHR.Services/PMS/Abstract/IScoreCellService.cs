using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IScoreCellService : IService<ScoreCell>
    {
        DataResult<List<AppraiseResult>> CollectionOfAppraiseResult(int scoreCell_Id, AppraiseResult appraiseResult, UserCredit userCredit);

		DataResult<List<CellAction>> CollectionOfCellAction(int scoreCell_Id, CellAction cellAction, UserCredit userCredit);

		DataResult<List<FinalAppraise>> CollectionOfFinalAppraise(int scoreCell_Id, FinalAppraise finalAppraise, UserCredit userCredit);
    }
}
