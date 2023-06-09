
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.IDEA;
using CobelHR.Services.IDEA.Abstract;


namespace CobelHR.Services.IDEA.Actions
{
    public static class Course_Action
    {
		
        public static async Task<DataResult<Course>> SaveAttached(this Course course, UserCredit userCredit)
        {
            var permissionType = course.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(course.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Course>(-1, "You don't have Save Permission for ''Course''", course);

            return await course.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Course>> SaveAttached(this Course course, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICourseService courseService = new CourseService();

            var result = await courseService.Save(course, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Course>(course);

            Result childResult = null;

            if(course.ListOfTraining.CheckList())
            {
                course.ListOfTraining.ForEach(i => i.Course.Id = result.Id);

                childResult = await course.ListOfTraining.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Course>(course);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Course>(course);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Course>> SaveCollection(this List<Course> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Course> result = new SuccessfulDataResult<Course>();

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
