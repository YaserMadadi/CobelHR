using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.LAD;
using CobelHR.Services.LAD.Actions;
using CobelHR.Services.LAD.Abstract;

namespace CobelHR.Services.LAD
{
    public class ConclusionTypeService : Service<ConclusionType>, IConclusionTypeService
    {
        public ConclusionTypeService() : base()
        {
        }

        public override async Task<DataResult<ConclusionType>> SaveAttached(ConclusionType conclusionType, UserCredit userCredit)
        {
            return await conclusionType.SaveAttached(userCredit);
        }

        public DataResult<List<Conclusion>> CollectionOfConclusion(int conclusionType_Id, Conclusion conclusion, UserCredit userCredit)
        {
            var procedureName = "[LAD].[ConclusionType.CollectionOfConclusion]";

            return this.CollectionOf<Conclusion>(procedureName,
                                                    new SqlParameter("@Id",conclusionType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", conclusion.ToJson()));
        }
    }
}