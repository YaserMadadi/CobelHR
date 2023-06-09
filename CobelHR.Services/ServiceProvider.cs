using Microsoft.Extensions.DependencyInjection;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Security.JWT;
using EssentialCore.Tools.Security.Service;
using CobelHR.Services.Base.Abstract;
using CobelHR.Services.Base;
using CobelHR.Services.Core.Abstract;
using CobelHR.Services.Core;
using CobelHR.Services.HR.Abstract;
using CobelHR.Services.HR;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Services.PMS;

using CobelHR.Services.PMS.Pharma.Abstract;
using CobelHR.Services.PMS.Pharma;

using CobelHR.Services.LAD.Abstract;
using CobelHR.Services.LAD;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Services.Base.HR;
using CobelHR.Services.IDEA.Abstract;
using CobelHR.Services.IDEA;
using CobelHR.Services.XCode.Abstract;
using CobelHR.Services.XCode;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Services.Base.PMS;
using CobelHR.Services.Partial.HR.Abstract;
using CobelHR.Services.Partial.HR;
using CobelHR.Services.Partial.PMS.Abstract;
using CobelHR.Services.Partial.PMS;

using CobelHR.Services.Partial.Core.Abstract;
using CobelHR.Services.Partial.Core;
using CobelHR.Entities.PMS.Pharma;

namespace CobelHR.Services
{
    public static class ServiceProvider
    {

        private static void LoadPartial(IServiceCollection services)
        {
            services.AddScoped<IEmployeeServicePartial, EmployeeServicePartial>();
            services.AddScoped<ITargetSettingServicePartial, TargetSettingServicePartial>();
            services.AddScoped<ILogServicePartial, LogServicePartial>();
        }


        public static void Load(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserClass, UserClass>();

            services.AddScoped<IOrgChartService, OrgChartService>();

            #region Base

            // Base Services
            services.AddScoped<ICertificationTypeService, CertificationTypeService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IConnectionTypeService, ConnectionTypeService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDrivingLicenseTypeService, DrivingLicenseTypeService>();
            services.AddScoped<IEducationSystemService, EducationSystemService>();
            services.AddScoped<IExcemptionTypeService, ExcemptionTypeService>();
            services.AddScoped<IFieldCategoryService, FieldCategoryService>();
            services.AddScoped<IFieldOfStudyService, FieldOfStudyService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IHabitancyTypeService, HabitancyTypeService>();
            services.AddScoped<IHealthStatusService, HealthStatusService>();
            services.AddScoped<IHoldingSectionService, HoldingSectionService>();
            services.AddScoped<IInclusiveTypeService, InclusiveTypeService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IMilitaryServiceStatusService, MilitaryServiceStatusService>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IQuarterService, QuarterService>();
            services.AddScoped<IReligionService, ReligionService>();
            services.AddScoped<ISchoolLevelService, SchoolLevelService>();
            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<IUniversityDegreeService, UniversityDegreeService>();
            services.AddScoped<IUniversityFieldCategoryService, UniversityFieldCategoryService>();
            services.AddScoped<IYearService, YearService>();
            services.AddScoped<IYearQuarterService, YearQuarterService>();

            #endregion

            #region Base.HR

            // Base.HR Services
            services.AddScoped<IContractTypeService, ContractTypeService>();
            services.AddScoped<IDevelopmentPlanTypeService, DevelopmentPlanTypeService>();
            services.AddScoped<IEmploymentStatusService, EmploymentStatusService>();
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<IMaritalStatusService, MaritalStatusService>();
            services.AddScoped<IPositionCategoryService, PositionCategoryService>();
            services.AddScoped<IPositionDivisionService, PositionDivisionService>();
            services.AddScoped<IRelativeTypeService, RelativeTypeService>();

            #endregion

            #region Base.PMS

            // Base.PMS Services
            services.AddScoped<IAppraiseTypeService, AppraiseTypeService>();
            services.AddScoped<IApprovementTypeService, ApprovementTypeService>();
            services.AddScoped<IApproverTypeService, ApproverTypeService>();
            services.AddScoped<ICurrentSituationService, CurrentSituationService>();
            services.AddScoped<IDesirableSituationService, DesirableSituationService>();
            services.AddScoped<IDevelopmentPlanPriorityService, DevelopmentPlanPriorityService>();
            services.AddScoped<IExpectedLevelService, ExpectedLevelService>();
            services.AddScoped<IMeasurementUnitService, MeasurementUnitService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ITargetSettingTypeService, TargetSettingTypeService>();
            services.AddScoped<ITargetSettingModeService, TargetSettingModeService>();
            #endregion

            #region Core

            // Core Services
            services.AddScoped<IBadgeService, BadgeService>();
            services.AddScoped<IBadgeTypeService, BadgeTypeService>();
            services.AddScoped<IEntityService, EntityService>();
            services.AddScoped<IImpersonateService, ImpersonateService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuItemService, MenuItemService>();
            services.AddScoped<IMenuItemTypeService, MenuItemTypeService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IPropertyOptionService, PropertyOptionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleMemberService, RoleMemberService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<ISubSystemService, SubSystemService>();
            services.AddScoped<IUserAccountService, UserAccountService>();

            #endregion

            #region HR

            // HR Services
            services.AddScoped<IAbilityLevelService, AbilityLevelService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeDetailService, EmployeeDetailService>();
            services.AddScoped<IEmployeeEventService, EmployeeEventService>();
            services.AddScoped<IEmployeeNotificationService, EmployeeNotificationService>();
            services.AddScoped<IHabitancyService, HabitancyService>();
            services.AddScoped<ILanguageAbilityService, LanguageAbilityService>();
            services.AddScoped<ILevelService, LevelService>();
            services.AddScoped<IMaritalInfoService, MaritalInfoService>();
            services.AddScoped<IMilitaryServiceService, MilitaryServiceService>();
            services.AddScoped<IMilitaryServiceExcemptionService, MilitaryServiceExcemptionService>();
            services.AddScoped<IMilitaryServiceInclusiveService, MilitaryServiceInclusiveService>();
            services.AddScoped<IPassportService, PassportService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonCertificateService, PersonCertificateService>();
            services.AddScoped<IPersonConnectionService, PersonConnectionService>();
            services.AddScoped<IPersonDrivingLicenseService, PersonDrivingLicenseService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IPositionAssignmentService, PositionAssignmentService>();
            services.AddScoped<IPositionAssignmentRepealService, PositionAssignmentRepealService>();
            services.AddScoped<IRelativeService, RelativeService>();
            services.AddScoped<ISchoolHistoryService, SchoolHistoryService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUniversityHistoryService, UniversityHistoryService>();
            services.AddScoped<IUniversityTerminateService, UniversityTerminateService>();
            services.AddScoped<IWorkExperienceService, WorkExperienceService>();

            #endregion

            #region IDEA

            // IDEA Services
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITrainingService, TrainingService>();

            #endregion

            #region LAD

            // LAD Services
            services.AddScoped<IAnswerTypeService, AnswerTypeService>();
            services.AddScoped<IAnswerTypeItemService, AnswerTypeItemService>();
            services.AddScoped<IAssessmentService, AssessmentService>();
            services.AddScoped<IAssessmentCoachingService, AssessmentCoachingService>();
            services.AddScoped<IAssessmentScoreService, AssessmentScoreService>();
            services.AddScoped<IAssessmentTrainingService, AssessmentTrainingService>();
            services.AddScoped<IAssessmentTypeService, AssessmentTypeService>();
            services.AddScoped<IAssessorService, AssessorService>();
            services.AddScoped<IAssessorConnectionLineService, AssessorConnectionLineService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<ICoachConnectionLineService, CoachConnectionLineService>();
            services.AddScoped<ICoachingService, CoachingService>();
            services.AddScoped<ICoachingQuestionaryService, CoachingQuestionaryService>();
            services.AddScoped<ICoachingQuestionaryAnsweredService, CoachingQuestionaryAnsweredService>();
            services.AddScoped<ICoachingQuestionaryDetailService, CoachingQuestionaryDetailService>();
            services.AddScoped<ICoachingSessionService, CoachingSessionService>();
            services.AddScoped<IConclusionService, ConclusionService>();
            services.AddScoped<IConclusionTypeService, ConclusionTypeService>();
            services.AddScoped<IDevelopmentGoalService, DevelopmentGoalService>();
            services.AddScoped<IFeedbackSessionService, FeedbackSessionService>();
            services.AddScoped<IPromotionAssessmentService, PromotionAssessmentService>();
            services.AddScoped<IPromotionResultService, PromotionResultService>();
            services.AddScoped<IQuestionaryItemService, QuestionaryItemService>();
            services.AddScoped<IQuestionaryTypeService, QuestionaryTypeService>();
            services.AddScoped<IRotationAssessmentService, RotationAssessmentService>();

            #endregion

            #region PMS

            // PMS Services
            services.AddScoped<IAppraisalApproverConfigService, AppraisalApproverConfigService>();
            services.AddScoped<IAppraiseResultService, AppraiseResultService>();
            services.AddScoped<IBehavioralAppraiseService, BehavioralAppraiseService>();
            services.AddScoped<IBehavioralKPIService, BehavioralKPIService>();
            services.AddScoped<IBehavioralObjectiveService, BehavioralObjectiveService>();
            services.AddScoped<ICellActionService, CellActionService>();
            services.AddScoped<ICompetencyItemService, CompetencyItemService>();
            services.AddScoped<ICompetencyItemKPIService, CompetencyItemKPIService>();
            services.AddScoped<IConfigQualitativeKPIService, ConfigQualitativeKPIService>();
            services.AddScoped<IConfigQualitativeObjectiveService, ConfigQualitativeObjectiveService>();
            services.AddScoped<IConfigTargetSettingService, ConfigTargetSettingService>();
            services.AddScoped<ICriticalIncidentService, CriticalIncidentService>();
            services.AddScoped<ICriticalIncidentRecognitionService, CriticalIncidentRecognitionService>();
            services.AddScoped<ICriticalIncidentTypeService, CriticalIncidentTypeService>();
            services.AddScoped<IDevelopmentPlanCompetencyService, DevelopmentPlanCompetencyService>();
            services.AddScoped<IFinalAppraiseService, FinalAppraiseService>();
            services.AddScoped<IFunctionalAppraiseService, FunctionalAppraiseService>();
            services.AddScoped<IFunctionalKPIService, FunctionalKPIService>();
            services.AddScoped<IFunctionalKPICommentService, FunctionalKPICommentService>();
            services.AddScoped<IFunctionalObjectiveService, FunctionalObjectiveService>();
            services.AddScoped<IFunctionalObjectiveCommentService, FunctionalObjectiveCommentService>();
            services.AddScoped<IIndividualDevelopmentPlanService, IndividualDevelopmentPlanService>();
            services.AddScoped<IObjectiveWeightNonOperationalService, ObjectiveWeightNonOperationalService>();
            services.AddScoped<IQualitativeAppraiseService, QualitativeAppraiseService>();
            services.AddScoped<IQualitativeKPIService, QualitativeKPIService>();
            services.AddScoped<IQualitativeObjectiveService, QualitativeObjectiveService>();
            services.AddScoped<IQuantitativeAppraiseService, QuantitativeAppraiseService>();
            services.AddScoped<IScoreCellService, ScoreCellService>();
            services.AddScoped<IStrategicObjectveService, StrategicObjectveService>();
            services.AddScoped<ITargetSettingService, TargetSettingService>();
            services.AddScoped<IVisionService, VisionService>();
            services.AddScoped<IVisionApprovedService, VisionApprovedService>();
            services.AddScoped<IVisionCommentService, VisionCommentService>();

            #endregion

            #region PMS.Pharma

            services.AddScoped<IAppraiseService, AppraiseService>();
            services.AddScoped<IConfigKPIService, ConfigKPIService>();
            services.AddScoped<IConfigObjectiveService, ConfigObjectiveService>();
            services.AddScoped<IKPIService, KPIService>();
            services.AddScoped<IObjectiveService, ObjectiveService>();
            services.AddScoped<IObjectiveTypeService, ObjectiveTypeService>();
            services.AddScoped<IPharmaConfigTargetSettingService, PharmaConfigTargetSettingService>();

            #endregion

            #region XCode

            // XCode Services
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ISynonymService, SynonymService>();

            #endregion

            LoadPartial(services);

        }
    }
}
