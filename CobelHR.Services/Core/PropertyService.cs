using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Core;
using CobelHR.Services.Core.Actions;
using CobelHR.Services.Core.Abstract;

namespace CobelHR.Services.Core
{
    public class PropertyService : Service<Property>, IPropertyService
    {
        public PropertyService() : base()
        {
        }

        public override async Task<DataResult<Property>> SaveAttached(Property property, UserCredit userCredit)
        {
            return await property.SaveAttached(userCredit);
        }

        public DataResult<List<PropertyOption>> CollectionOfPropertyOption(int property_Id, PropertyOption propertyOption, UserCredit userCredit)
        {
            var procedureName = "[Core].[Property.CollectionOfPropertyOption]";

            return this.CollectionOf<PropertyOption>(procedureName,
                                                    new SqlParameter("@Id",property_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", propertyOption.ToJson()));
        }
    }
}