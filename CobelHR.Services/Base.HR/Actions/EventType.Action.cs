
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR.Actions
{
    public static class EventType_Action
    {
		
        public static async Task<DataResult<EventType>> SaveAttached(this EventType eventType, UserCredit userCredit)
        {
            var permissionType = eventType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(eventType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<EventType>(-1, "You don't have Save Permission for ''EventType''", eventType);

            return await eventType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<EventType>> SaveAttached(this EventType eventType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IEventTypeService eventTypeService = new EventTypeService();

            var result = await eventTypeService.Save(eventType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<EventType>(eventType);

            Result childResult = null;

            if(eventType.ListOfEmployeeEvent.CheckList())
            {
                eventType.ListOfEmployeeEvent.ForEach(i => i.EventType.Id = result.Id);

                childResult = await eventType.ListOfEmployeeEvent.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<EventType>(eventType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<EventType>(eventType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<EventType>> SaveCollection(this List<EventType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<EventType> result = new SuccessfulDataResult<EventType>();

            foreach (var item in list)
            {
                result = await item.SaveAttached(userCredit, transaction, depth + 1);

                if (result.Id <= 0)

                    break;
            }

            return result;
        }
    }
}
