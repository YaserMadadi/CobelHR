using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;

namespace CobelHR.Services.Base
{
    public class UniversityFieldCategoryService : Service<UniversityFieldCategory>, IUniversityFieldCategoryService
    {
        public UniversityFieldCategoryService() : base()
        {
        }

        public override async Task<DataResult<UniversityFieldCategory>> SaveAttached(UniversityFieldCategory universityFieldCategory, UserCredit userCredit)
        {
            return await universityFieldCategory.SaveAttached(userCredit);
        }

        public DataResult<List<FieldOfStudy>> CollectionOfFieldOfStudy(int universityFieldCategory_Id, FieldOfStudy fieldOfStudy, UserCredit userCredit)
        {
            var procedureName = "[Base].[UniversityFieldCategory.CollectionOfFieldOfStudy]";

            return this.CollectionOf<FieldOfStudy>(procedureName,
                                                    new SqlParameter("@Id",universityFieldCategory_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", fieldOfStudy.ToJson()));
        }
    }
}