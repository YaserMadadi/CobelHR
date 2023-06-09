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
    public class FieldCategoryService : Service<FieldCategory>, IFieldCategoryService
    {
        public FieldCategoryService() : base()
        {
        }

        public override async Task<DataResult<FieldCategory>> SaveAttached(FieldCategory fieldCategory, UserCredit userCredit)
        {
            return await fieldCategory.SaveAttached(userCredit);
        }

        public DataResult<List<PersonCertificate>> CollectionOfPersonCertificate(int fieldCategory_Id, PersonCertificate personCertificate, UserCredit userCredit)
        {
            var procedureName = "[Base].[FieldCategory.CollectionOfPersonCertificate]";

            return this.CollectionOf<PersonCertificate>(procedureName,
                                                    new SqlParameter("@Id",fieldCategory_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", personCertificate.ToJson()));
        }
    }
}