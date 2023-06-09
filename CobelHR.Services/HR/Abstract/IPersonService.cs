using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;using CobelHR.Entities.LAD;
using CobelHR.Entities.Core;



namespace CobelHR.Services.HR.Abstract
{
    public interface IPersonService : IService<Person>
    {
        DataResult<List<CoachingQuestionary>> CollectionOfCoachingQuestionary_ResponsiblePerson(int person_Id, CoachingQuestionary coachingQuestionary, UserCredit userCredit);

		DataResult<List<Employee>> CollectionOfEmployee(int person_Id, Employee employee, UserCredit userCredit);

		DataResult<List<Habitancy>> CollectionOfHabitancy(int person_Id, Habitancy habitancy, UserCredit userCredit);

		DataResult<List<LanguageAbility>> CollectionOfLanguageAbility(int person_Id, LanguageAbility languageAbility, UserCredit userCredit);

		DataResult<List<Log>> CollectionOfLog(int person_Id, Log log, UserCredit userCredit);

		DataResult<List<MaritalInfo>> CollectionOfMaritalInfo(int person_Id, MaritalInfo maritalInfo, UserCredit userCredit);

		DataResult<List<MilitaryService>> CollectionOfMilitaryService(int person_Id, MilitaryService militaryService, UserCredit userCredit);

		DataResult<List<Passport>> CollectionOfPassport(int person_Id, Passport passport, UserCredit userCredit);

		DataResult<List<PersonCertificate>> CollectionOfPersonCertificate(int person_Id, PersonCertificate personCertificate, UserCredit userCredit);

		DataResult<List<PersonConnection>> CollectionOfPersonConnection(int person_Id, PersonConnection personConnection, UserCredit userCredit);

		DataResult<List<PersonDrivingLicense>> CollectionOfPersonDrivingLicense(int person_Id, PersonDrivingLicense personDrivingLicense, UserCredit userCredit);

		DataResult<List<Relative>> CollectionOfRelative_Peson(int person_Id, Relative relative, UserCredit userCredit);

		DataResult<List<SchoolHistory>> CollectionOfSchoolHistory(int person_Id, SchoolHistory schoolHistory, UserCredit userCredit);

		DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int person_Id, UniversityHistory universityHistory, UserCredit userCredit);

		DataResult<List<UserAccount>> CollectionOfUserAccount(int person_Id, UserAccount userAccount, UserCredit userCredit);

		DataResult<List<WorkExperience>> CollectionOfWorkExperience(int person_Id, WorkExperience workExperience, UserCredit userCredit);
    }
}
