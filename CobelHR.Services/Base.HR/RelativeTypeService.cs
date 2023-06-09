using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Actions;
using CobelHR.Services.Base.HR.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR
{
    public class RelativeTypeService : Service<RelativeType>, IRelativeTypeService
    {
        public RelativeTypeService() : base()
        {
        }

        public override async Task<DataResult<RelativeType>> SaveAttached(RelativeType relativeType, UserCredit userCredit)
        {
            return await relativeType.SaveAttached(userCredit);
        }

        public DataResult<List<Relative>> CollectionOfRelative_RelationType(int relativeType_Id, Relative relative, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[RelativeType(RelationType).CollectionOfRelative]";

            return this.CollectionOf<Relative>(procedureName,
                                                    new SqlParameter("@Id",relativeType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", relative.ToJson()));
        }
    }
}