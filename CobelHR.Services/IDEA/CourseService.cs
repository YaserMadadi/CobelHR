using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.IDEA;
using CobelHR.Services.IDEA.Actions;
using CobelHR.Services.IDEA.Abstract;

namespace CobelHR.Services.IDEA
{
    public class CourseService : Service<Course>, ICourseService
    {
        public CourseService() : base()
        {
        }

        public override async Task<DataResult<Course>> SaveAttached(Course course, UserCredit userCredit)
        {
            return await course.SaveAttached(userCredit);
        }

        public DataResult<List<Training>> CollectionOfTraining(int course_Id, Training training, UserCredit userCredit)
        {
            var procedureName = "[IDEA].[Course.CollectionOfTraining]";

            return this.CollectionOf<Training>(procedureName,
                                                    new SqlParameter("@Id",course_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", training.ToJson()));
        }
    }
}