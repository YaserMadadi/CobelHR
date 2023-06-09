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
    public class TargetSettingModeService : Service<TargetSettingMode>, ITargetSettingModeService
    {
        public TargetSettingModeService() : base()
        {
        }

        //public override async Task<DataResult<TargetSettingMode>> SaveAttached(TargetSettingMode targetSettingMode, UserCredit userCredit)
        //{
        //    return await targetSettingMode.SaveAttached(userCredit);
        //}

        public DataResult<List<TargetSetting>> CollectionOfTargetSetting(int targetSettingMode_Id, TargetSetting targetSetting, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[TargetSettingMode.CollectionOfTargetSetting]";

            return this.CollectionOf<TargetSetting>(procedureName,
                                                    new SqlParameter("@Id", targetSettingMode_Id), 
                                                    new SqlParameter("@jsonValue", targetSetting.ToJson()));
        }
    }
}