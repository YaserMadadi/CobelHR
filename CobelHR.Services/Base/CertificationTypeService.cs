using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base
{
    public class CertificationTypeService : Service<CertificationType>, ICertificationTypeService
    {
        public CertificationTypeService() : base()
        {
        }

        public override async Task<DataResult<CertificationType>> SaveAttached(CertificationType certificationType, UserCredit userCredit)
        {
            return await certificationType.SaveAttached(userCredit);
        }

        public DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int certificationType_Id, UniversityHistory universityHistory, UserCredit userCredit)
        {
            var procedureName = "[Base].[CertificationType.CollectionOfUniversityHistory]";

            return this.CollectionOf<UniversityHistory>(procedureName,
                                                    new SqlParameter("@Id",certificationType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", universityHistory.ToJson()));
        }
    }
}