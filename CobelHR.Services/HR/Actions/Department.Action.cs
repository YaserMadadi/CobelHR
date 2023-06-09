
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Abstract;


namespace CobelHR.Services.HR.Actions
{
    public static class Department_Action
    {
		
        public static async Task<DataResult<Department>> SaveAttached(this Department department, UserCredit userCredit)
        {
            var permissionType = department.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(department.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Department>(-1, "You don't have Save Permission for ''Department''", department);

            return await department.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Department>> SaveAttached(this Department department, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IDepartmentService departmentService = new DepartmentService();

            var result = await departmentService.Save(department, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Department>(department);

            Result childResult = null;

            if(department.ListOfUnit.CheckList())
            {
                department.ListOfUnit.ForEach(i => i.Department.Id = result.Id);

                childResult = await department.ListOfUnit.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Department>(department);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Department>(department);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Department>> SaveCollection(this List<Department> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Department> result = new SuccessfulDataResult<Department>();

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
