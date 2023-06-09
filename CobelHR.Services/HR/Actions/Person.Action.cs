
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
using CobelHR.Services.LAD.Actions;
using CobelHR.Entities.LAD;
using CobelHR.Services.Core.Actions;
using CobelHR.Entities.Core;


namespace CobelHR.Services.HR.Actions
{
    public static class Person_Action
    {
		
        public static async Task<DataResult<Person>> SaveAttached(this Person person, UserCredit userCredit)
        {
            var permissionType = person.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(person.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Person>(-1, "You don't have Save Permission for ''Person''", person);

            return await person.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Person>> SaveAttached(this Person person, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPersonService personService = new PersonService();

            var result = await personService.Save(person, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Person>(person);

            Result childResult = null;

            if(person.ListOfResponsiblePerson_CoachingQuestionary.CheckList())
            {
                person.ListOfResponsiblePerson_CoachingQuestionary.ForEach(i => i.ResponsiblePerson.Id = result.Id);

                childResult = await person.ListOfResponsiblePerson_CoachingQuestionary.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfEmployee.CheckList())
            {
                person.ListOfEmployee.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfEmployee.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfHabitancy.CheckList())
            {
                person.ListOfHabitancy.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfHabitancy.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfLanguageAbility.CheckList())
            {
                person.ListOfLanguageAbility.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfLanguageAbility.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfLog.CheckList())
            {
                person.ListOfLog.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfLog.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfMaritalInfo.CheckList())
            {
                person.ListOfMaritalInfo.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfMaritalInfo.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfMilitaryService.CheckList())
            {
                person.ListOfMilitaryService.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfMilitaryService.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfPassport.CheckList())
            {
                person.ListOfPassport.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfPassport.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfPersonCertificate.CheckList())
            {
                person.ListOfPersonCertificate.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfPersonCertificate.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfPersonConnection.CheckList())
            {
                person.ListOfPersonConnection.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfPersonConnection.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfPersonDrivingLicense.CheckList())
            {
                person.ListOfPersonDrivingLicense.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfPersonDrivingLicense.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfPeson_Relative.CheckList())
            {
                person.ListOfPeson_Relative.ForEach(i => i.Peson.Id = result.Id);

                childResult = await person.ListOfPeson_Relative.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfSchoolHistory.CheckList())
            {
                person.ListOfSchoolHistory.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfSchoolHistory.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfUniversityHistory.CheckList())
            {
                person.ListOfUniversityHistory.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfUniversityHistory.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfUserAccount.CheckList())
            {
                person.ListOfUserAccount.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfUserAccount.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }

            if(person.ListOfWorkExperience.CheckList())
            {
                person.ListOfWorkExperience.ForEach(i => i.Person.Id = result.Id);

                childResult = await person.ListOfWorkExperience.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Person>(person);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Person>(person);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Person>> SaveCollection(this List<Person> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Person> result = new SuccessfulDataResult<Person>();

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
