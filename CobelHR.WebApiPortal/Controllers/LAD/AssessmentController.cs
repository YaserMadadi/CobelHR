using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.LAD.Abstract;
using CobelHR.Entities.LAD;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.LAD
{
    [Route("api/LAD")]
    public class AssessmentController : BaseController
    {
        public AssessmentController(IAssessmentService assessmentService)
        {
            this.assessmentService = assessmentService;
        }

        private IAssessmentService assessmentService { get; set; }

        [HttpGet]
        [Route("Assessment/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.assessmentService.RetrieveById(id, Assessment.Informer, this.UserCredit);

			return result.ToActionResult<Assessment>();
        }

        [HttpPost]
        [Route("Assessment/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.assessmentService.RetrieveAll(Assessment.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Assessment>();
        }
            

        
        [HttpPost]
        [Route("Assessment/Save")]
        public async Task<IActionResult> Save([FromBody] Assessment assessment)
        {
            var result = await this.assessmentService.Save(assessment, this.UserCredit);

			return result.ToActionResult<Assessment>();
        }

        
        [HttpPost]
        [Route("Assessment/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Assessment assessment)
        {
            var result = await this.assessmentService.SaveAttached(assessment, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Assessment/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Assessment> assessmentList)
        {
            var result = await this.assessmentService.SaveBulk(assessmentList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Assessment/Seek")]
        public async Task<IActionResult> Seek([FromBody] Assessment assessment)
        {
            var result = await this.assessmentService.Seek(assessment, this.UserCredit);

			return result.ToActionResult<Assessment>();
        }

        [HttpGet]
        [Route("Assessment/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.assessmentService.SeekByValue(seekValue, Assessment.Informer, this.UserCredit);

			return result.ToActionResult<Assessment>();
        }

        [HttpPost]
        [Route("Assessment/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Assessment assessment)
        {
            var result = await this.assessmentService.Delete(assessment, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAssessmentCoaching
        [HttpPost]
        [Route("Assessment/{assessment_id:int}/AssessmentCoaching")]
        public IActionResult CollectionOfAssessmentCoaching([FromRoute(Name = "assessment_id")] int id, AssessmentCoaching assessmentCoaching)
        {
            return this.assessmentService.CollectionOfAssessmentCoaching(id, assessmentCoaching, this.UserCredit).ToActionResult();
        }

		// CollectionOfAssessmentScore
        [HttpPost]
        [Route("Assessment/{assessment_id:int}/AssessmentScore")]
        public IActionResult CollectionOfAssessmentScore([FromRoute(Name = "assessment_id")] int id, AssessmentScore assessmentScore)
        {
            return this.assessmentService.CollectionOfAssessmentScore(id, assessmentScore, this.UserCredit).ToActionResult();
        }

		// CollectionOfAssessmentTraining
        [HttpPost]
        [Route("Assessment/{assessment_id:int}/AssessmentTraining")]
        public IActionResult CollectionOfAssessmentTraining([FromRoute(Name = "assessment_id")] int id, AssessmentTraining assessmentTraining)
        {
            return this.assessmentService.CollectionOfAssessmentTraining(id, assessmentTraining, this.UserCredit).ToActionResult();
        }

		// CollectionOfCoachingQuestionary
        [HttpPost]
        [Route("Assessment/{assessment_id:int}/CoachingQuestionary")]
        public IActionResult CollectionOfCoachingQuestionary([FromRoute(Name = "assessment_id")] int id, CoachingQuestionary coachingQuestionary)
        {
            return this.assessmentService.CollectionOfCoachingQuestionary(id, coachingQuestionary, this.UserCredit).ToActionResult();
        }

		// CollectionOfConclusion
        [HttpPost]
        [Route("Assessment/{assessment_id:int}/Conclusion")]
        public IActionResult CollectionOfConclusion([FromRoute(Name = "assessment_id")] int id, Conclusion conclusion)
        {
            return this.assessmentService.CollectionOfConclusion(id, conclusion, this.UserCredit).ToActionResult();
        }

		// CollectionOfDevelopmentGoal
        [HttpPost]
        [Route("Assessment/{assessment_id:int}/DevelopmentGoal")]
        public IActionResult CollectionOfDevelopmentGoal([FromRoute(Name = "assessment_id")] int id, DevelopmentGoal developmentGoal)
        {
            return this.assessmentService.CollectionOfDevelopmentGoal(id, developmentGoal, this.UserCredit).ToActionResult();
        }

		// CollectionOfFeedbackSession
        [HttpPost]
        [Route("Assessment/{assessment_id:int}/FeedbackSession")]
        public IActionResult CollectionOfFeedbackSession([FromRoute(Name = "assessment_id")] int id, FeedbackSession feedbackSession)
        {
            return this.assessmentService.CollectionOfFeedbackSession(id, feedbackSession, this.UserCredit).ToActionResult();
        }

		// CollectionOfPromotionAssessment
        [HttpPost]
        [Route("Assessment/{assessment_id:int}/PromotionAssessment")]
        public IActionResult CollectionOfPromotionAssessment([FromRoute(Name = "assessment_id")] int id, PromotionAssessment promotionAssessment)
        {
            return this.assessmentService.CollectionOfPromotionAssessment(id, promotionAssessment, this.UserCredit).ToActionResult();
        }

		// CollectionOfRotationAssessment
        [HttpPost]
        [Route("Assessment/{assessment_id:int}/RotationAssessment")]
        public IActionResult CollectionOfRotationAssessment([FromRoute(Name = "assessment_id")] int id, RotationAssessment rotationAssessment)
        {
            return this.assessmentService.CollectionOfRotationAssessment(id, rotationAssessment, this.UserCredit).ToActionResult();
        }
    }
}