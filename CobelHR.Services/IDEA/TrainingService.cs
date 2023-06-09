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
    public class TrainingService : Service<Training>, ITrainingService
    {
        public TrainingService() : base()
        {
        }

        public override async Task<DataResult<Training>> SaveAttached(Training training, UserCredit userCredit)
        {
            return await training.SaveAttached(userCredit);
        }

        
    }
}