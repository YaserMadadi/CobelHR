using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;



namespace CobelHR.Services.HR.Abstract
{
    public interface IPositionService : ITemporalService<Position>
    {
        DataResult<List<Position>> CollectionOfPosition_Parent(int position_Id, Position position, UserCredit userCredit);

		DataResult<List<PositionAssignment>> CollectionOfPositionAssignment(int position_Id, PositionAssignment positionAssignment, UserCredit userCredit);

		DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment_ProposedPosition(int position_Id, PromotionAssessment promotionAssessment, UserCredit userCredit);

		DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment_CurrentPosition(int position_Id, PromotionAssessment promotionAssessment, UserCredit userCredit);

		DataResult<List<RotationAssessment>> CollectionOfRotationAssessment_ProposedPosition(int position_Id, RotationAssessment rotationAssessment, UserCredit userCredit);

		DataResult<List<RotationAssessment>> CollectionOfRotationAssessment_CurrentPosition(int position_Id, RotationAssessment rotationAssessment, UserCredit userCredit);

		DataResult<List<TargetSetting>> CollectionOfTargetSetting(int position_Id, TargetSetting targetSetting, UserCredit userCredit);

		DataResult<List<Vision>> CollectionOfVision(int position_Id, Vision vision, UserCredit userCredit);
    }
}
