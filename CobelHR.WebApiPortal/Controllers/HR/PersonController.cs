using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;
using CobelHR.Entities.LAD;
using CobelHR.Entities.Core;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class PersonController : BaseController
    {
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        private IPersonService personService { get; set; }

        [HttpGet]
        [Route("Person/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.personService.RetrieveById(id, Person.Informer, this.UserCredit);

			return result.ToActionResult<Person>();
        }

        [HttpPost]
        [Route("Person/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.personService.RetrieveAll(Person.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Person>();
        }
            

        
        [HttpPost]
        [Route("Person/Save")]
        public async Task<IActionResult> Save([FromBody] Person person)
        {
            var result = await this.personService.Save(person, this.UserCredit);

			return result.ToActionResult<Person>();
        }

        
        [HttpPost]
        [Route("Person/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Person person)
        {
            var result = await this.personService.SaveAttached(person, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Person/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Person> personList)
        {
            var result = await this.personService.SaveBulk(personList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Person/Seek")]
        public async Task<IActionResult> Seek([FromBody] Person person)
        {
            var result = await this.personService.Seek(person, this.UserCredit);

			return result.ToActionResult<Person>();
        }

        [HttpGet]
        [Route("Person/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.personService.SeekByValue(seekValue, Person.Informer, this.UserCredit);

			return result.ToActionResult<Person>();
        }

        [HttpPost]
        [Route("Person/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Person person)
        {
            var result = await this.personService.Delete(person, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfCoachingQuestionary_ResponsiblePerson
        //[HttpPost]
        //[Route("ResponsiblePerson/{person_id:int}/CoachingQuestionary")]
        //public IActionResult CollectionOfCoachingQuestionary_ResponsiblePerson([FromRoute(Name = "person_id")] int id, CoachingQuestionary coachingQuestionary)
        //{
        //    return this.personService.CollectionOfCoachingQuestionary_ResponsiblePerson(id, coachingQuestionary, this.UserCredit).ToActionResult();
        //}

		// CollectionOfEmployee
        [HttpPost]
        [Route("Person/{person_id:int}/Employee")]
        public IActionResult CollectionOfEmployee([FromRoute(Name = "person_id")] int id, Employee employee)
        {
            return this.personService.CollectionOfEmployee(id, employee, this.UserCredit).ToActionResult();
        }

		// CollectionOfHabitancy
        [HttpPost]
        [Route("Person/{person_id:int}/Habitancy")]
        public IActionResult CollectionOfHabitancy([FromRoute(Name = "person_id")] int id, Habitancy habitancy)
        {
            return this.personService.CollectionOfHabitancy(id, habitancy, this.UserCredit).ToActionResult();
        }

		// CollectionOfLanguageAbility
        [HttpPost]
        [Route("Person/{person_id:int}/LanguageAbility")]
        public IActionResult CollectionOfLanguageAbility([FromRoute(Name = "person_id")] int id, LanguageAbility languageAbility)
        {
            return this.personService.CollectionOfLanguageAbility(id, languageAbility, this.UserCredit).ToActionResult();
        }

		// CollectionOfLog
        [HttpPost]
        [Route("Person/{person_id:int}/Log")]
        public IActionResult CollectionOfLog([FromRoute(Name = "person_id")] int id, Log log)
        {
            return this.personService.CollectionOfLog(id, log, this.UserCredit).ToActionResult();
        }

		// CollectionOfMaritalInfo
        [HttpPost]
        [Route("Person/{person_id:int}/MaritalInfo")]
        public IActionResult CollectionOfMaritalInfo([FromRoute(Name = "person_id")] int id, MaritalInfo maritalInfo)
        {
            return this.personService.CollectionOfMaritalInfo(id, maritalInfo, this.UserCredit).ToActionResult();
        }

		// CollectionOfMilitaryService
        [HttpPost]
        [Route("Person/{person_id:int}/MilitaryService")]
        public IActionResult CollectionOfMilitaryService([FromRoute(Name = "person_id")] int id, MilitaryService militaryService)
        {
            return this.personService.CollectionOfMilitaryService(id, militaryService, this.UserCredit).ToActionResult();
        }

		// CollectionOfPassport
        [HttpPost]
        [Route("Person/{person_id:int}/Passport")]
        public IActionResult CollectionOfPassport([FromRoute(Name = "person_id")] int id, Passport passport)
        {
            return this.personService.CollectionOfPassport(id, passport, this.UserCredit).ToActionResult();
        }

		// CollectionOfPersonCertificate
        [HttpPost]
        [Route("Person/{person_id:int}/PersonCertificate")]
        public IActionResult CollectionOfPersonCertificate([FromRoute(Name = "person_id")] int id, PersonCertificate personCertificate)
        {
            return this.personService.CollectionOfPersonCertificate(id, personCertificate, this.UserCredit).ToActionResult();
        }

		// CollectionOfPersonConnection
        [HttpPost]
        [Route("Person/{person_id:int}/PersonConnection")]
        public IActionResult CollectionOfPersonConnection([FromRoute(Name = "person_id")] int id, PersonConnection personConnection)
        {
            return this.personService.CollectionOfPersonConnection(id, personConnection, this.UserCredit).ToActionResult();
        }

		// CollectionOfPersonDrivingLicense
        [HttpPost]
        [Route("Person/{person_id:int}/PersonDrivingLicense")]
        public IActionResult CollectionOfPersonDrivingLicense([FromRoute(Name = "person_id")] int id, PersonDrivingLicense personDrivingLicense)
        {
            return this.personService.CollectionOfPersonDrivingLicense(id, personDrivingLicense, this.UserCredit).ToActionResult();
        }

		// CollectionOfRelative_Peson
        [HttpPost]
        [Route("Peson/{person_id:int}/Relative")]
        public IActionResult CollectionOfRelative_Peson([FromRoute(Name = "person_id")] int id, Relative relative)
        {
            return this.personService.CollectionOfRelative_Peson(id, relative, this.UserCredit).ToActionResult();
        }

		// CollectionOfSchoolHistory
        [HttpPost]
        [Route("Person/{person_id:int}/SchoolHistory")]
        public IActionResult CollectionOfSchoolHistory([FromRoute(Name = "person_id")] int id, SchoolHistory schoolHistory)
        {
            return this.personService.CollectionOfSchoolHistory(id, schoolHistory, this.UserCredit).ToActionResult();
        }

		// CollectionOfUniversityHistory
        [HttpPost]
        [Route("Person/{person_id:int}/UniversityHistory")]
        public IActionResult CollectionOfUniversityHistory([FromRoute(Name = "person_id")] int id, UniversityHistory universityHistory)
        {
            return this.personService.CollectionOfUniversityHistory(id, universityHistory, this.UserCredit).ToActionResult();
        }

		// CollectionOfUserAccount
        [HttpPost]
        [Route("Person/{person_id:int}/UserAccount")]
        public IActionResult CollectionOfUserAccount([FromRoute(Name = "person_id")] int id, UserAccount userAccount)
        {
            return this.personService.CollectionOfUserAccount(id, userAccount, this.UserCredit).ToActionResult();
        }

		// CollectionOfWorkExperience
        [HttpPost]
        [Route("Person/{person_id:int}/WorkExperience")]
        public IActionResult CollectionOfWorkExperience([FromRoute(Name = "person_id")] int id, WorkExperience workExperience)
        {
            return this.personService.CollectionOfWorkExperience(id, workExperience, this.UserCredit).ToActionResult();
        }
    }
}