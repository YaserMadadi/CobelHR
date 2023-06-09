using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Actions;
using CobelHR.Services.Base.PMS.Abstract;using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS
{
    public class TargetSettingTypeService : Service<TargetSettingType>, ITargetSettingTypeService
    {
        public TargetSettingTypeService() : base()
        {
        }

        public override async Task<DataResult<TargetSettingType>> SaveAttached(TargetSettingType targetSettingType, UserCredit userCredit)
        {
            return await targetSettingType.SaveAttached(userCredit);
        }

        public DataResult<List<TargetSetting>> CollectionOfTargetSetting(int targetSettingType_Id, TargetSetting targetSetting, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[TargetSettingType.CollectionOfTargetSetting]";

            return this.CollectionOf<TargetSetting>(procedureName,
                                                    new SqlParameter("@Id",targetSettingType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", targetSetting.ToJson()));
        }
    }
}