using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.HR
{
    public class PositionService : TemporalService<Position>, IPositionService
    {
        public PositionService() : base()
        {
            
        }

        public override async Task<DataResult<Position>> SaveAttached(Position position, UserCredit userCredit)
        {
            return await position.SaveAttached(userCredit);
        }

        public DataResult<List<Position>> CollectionOfPosition_Parent(int position_Id, Position position, UserCredit userCredit)
        {
            var procedureName = "[HR].[Position(Parent).CollectionOfPosition]";

            return this.CollectionOf<Position>(procedureName,
                                                    new SqlParameter("@Id",position_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", position.ToJson()));
        }

		public DataResult<List<PositionAssignment>> CollectionOfPositionAssignment(int position_Id, PositionAssignment positionAssignment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Position.CollectionOfPositionAssignment]";

            return this.CollectionOf<PositionAssignment>(procedureName,
                                                    new SqlParameter("@Id",position_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", positionAssignment.ToJson()));
        }

		public DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment_ProposedPosition(int position_Id, PromotionAssessment promotionAssessment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Position(ProposedPosition).CollectionOfPromotionAssessment]";

            return this.CollectionOf<PromotionAssessment>(procedureName,
                                                    new SqlParameter("@Id",position_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", promotionAssessment.ToJson()));
        }

		public DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment_CurrentPosition(int position_Id, PromotionAssessment promotionAssessment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Position(CurrentPosition).CollectionOfPromotionAssessment]";

            return this.CollectionOf<PromotionAssessment>(procedureName,
                                                    new SqlParameter("@Id",position_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", promotionAssessment.ToJson()));
        }

		public DataResult<List<RotationAssessment>> CollectionOfRotationAssessment_ProposedPosition(int position_Id, RotationAssessment rotationAssessment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Position(ProposedPosition).CollectionOfRotationAssessment]";

            return this.CollectionOf<RotationAssessment>(procedureName,
                                                    new SqlParameter("@Id",position_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", rotationAssessment.ToJson()));
        }

		public DataResult<List<RotationAssessment>> CollectionOfRotationAssessment_CurrentPosition(int position_Id, RotationAssessment rotationAssessment, UserCredit userCredit)
        {
            var procedureName = "[HR].[Position(CurrentPosition).CollectionOfRotationAssessment]";

            return this.CollectionOf<RotationAssessment>(procedureName,
                                                    new SqlParameter("@Id",position_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", rotationAssessment.ToJson()));
        }

		public DataResult<List<TargetSetting>> CollectionOfTargetSetting(int position_Id, TargetSetting targetSetting, UserCredit userCredit)
        {
            var procedureName = "[HR].[Position.CollectionOfTargetSetting]";

            return this.CollectionOf<TargetSetting>(procedureName,
                                                    new SqlParameter("@Id",position_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", targetSetting.ToJson()));
        }

		public DataResult<List<Vision>> CollectionOfVision(int position_Id, Vision vision, UserCredit userCredit)
        {
            var procedureName = "[HR].[Position.CollectionOfVision]";

            return this.CollectionOf<Vision>(procedureName,
                                                    new SqlParameter("@Id",position_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", vision.ToJson()));
        }
    }
}