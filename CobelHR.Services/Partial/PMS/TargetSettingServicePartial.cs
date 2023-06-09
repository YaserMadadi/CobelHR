using System.Data.SqlClient;
using System.Collections.Generic;
using CobelHR.Services.Partial.PMS.Abstract;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS;
using EssentialCore.Entities;

namespace CobelHR.Services.Partial.PMS
{
    public class TargetSettingServicePartial : TargetSettingService, ITargetSettingServicePartial
    {
        public DataResult<List<FunctionalObjective>> CollectionOfParentalFunctionalObjective(int targetSetting_Id)
        {
           // return this.CollectionOf<FunctionalObjective>(TargetSetting.Informer, targetSetting_Id, null);

            var procedureName = $"[PMS].[TargetSetting.CollectionOfParentalFunctionalObjective]";

            return this.CollectionOf<FunctionalObjective>(procedureName, new SqlParameter("@TargetSetting_Id", targetSetting_Id));
        }

        public DataResult<List<Vision>> CollectionOfVision(int taregtSetting_Id, Vision vision)
        {
            var procedureName = "[PMS].[TargetSetting.CollectionOfVision]";

            return this.CollectionOf<Vision>(procedureName,
                                                    new SqlParameter("@Id", taregtSetting_Id),
                                                    new SqlParameter("@JsonValue", vision.ToJson()));
        }


    }
}
