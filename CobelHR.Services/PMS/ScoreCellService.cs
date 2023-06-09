using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Actions;
using CobelHR.Services.PMS.Abstract;

namespace CobelHR.Services.PMS
{
    public class ScoreCellService : Service<ScoreCell>, IScoreCellService
    {
        public ScoreCellService() : base()
        {
        }

        public override async Task<DataResult<ScoreCell>> SaveAttached(ScoreCell scoreCell, UserCredit userCredit)
        {
            return await scoreCell.SaveAttached(userCredit);
        }

        public DataResult<List<AppraiseResult>> CollectionOfAppraiseResult(int scoreCell_Id, AppraiseResult appraiseResult, UserCredit userCredit)
        {
            var procedureName = "[PMS].[ScoreCell.CollectionOfAppraiseResult]";

            return this.CollectionOf<AppraiseResult>(procedureName,
                                                    new SqlParameter("@Id",scoreCell_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", appraiseResult.ToJson()));
        }

		public DataResult<List<CellAction>> CollectionOfCellAction(int scoreCell_Id, CellAction cellAction, UserCredit userCredit)
        {
            var procedureName = "[PMS].[ScoreCell.CollectionOfCellAction]";

            return this.CollectionOf<CellAction>(procedureName,
                                                    new SqlParameter("@Id",scoreCell_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", cellAction.ToJson()));
        }

		public DataResult<List<FinalAppraise>> CollectionOfFinalAppraise(int scoreCell_Id, FinalAppraise finalAppraise, UserCredit userCredit)
        {
            var procedureName = "[PMS].[ScoreCell.CollectionOfFinalAppraise]";

            return this.CollectionOf<FinalAppraise>(procedureName,
                                                    new SqlParameter("@Id",scoreCell_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", finalAppraise.ToJson()));
        }
    }
}