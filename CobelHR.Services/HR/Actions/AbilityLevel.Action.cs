
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


namespace CobelHR.Services.HR.Actions
{
    public static class AbilityLevel_Action
    {
		
        public static async Task<DataResult<AbilityLevel>> SaveAttached(this AbilityLevel abilityLevel, UserCredit userCredit)
        {
            var permissionType = abilityLevel.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(abilityLevel.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AbilityLevel>(-1, "You don't have Save Permission for ''AbilityLevel''", abilityLevel);

            return await abilityLevel.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AbilityLevel>> SaveAttached(this AbilityLevel abilityLevel, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAbilityLevelService abilityLevelService = new AbilityLevelService();

            var result = await abilityLevelService.Save(abilityLevel, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AbilityLevel>(abilityLevel);

            Result childResult = null;

            if(abilityLevel.ListOfListeningLevel_LanguageAbility.CheckList())
            {
                abilityLevel.ListOfListeningLevel_LanguageAbility.ForEach(i => i.ListeningLevel.Id = result.Id);

                childResult = await abilityLevel.ListOfListeningLevel_LanguageAbility.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AbilityLevel>(abilityLevel);
                }
            }

            if(abilityLevel.ListOfSpeackingLevel_LanguageAbility.CheckList())
            {
                abilityLevel.ListOfSpeackingLevel_LanguageAbility.ForEach(i => i.SpeackingLevel.Id = result.Id);

                childResult = await abilityLevel.ListOfSpeackingLevel_LanguageAbility.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AbilityLevel>(abilityLevel);
                }
            }

            if(abilityLevel.ListOfReadingLevel_LanguageAbility.CheckList())
            {
                abilityLevel.ListOfReadingLevel_LanguageAbility.ForEach(i => i.ReadingLevel.Id = result.Id);

                childResult = await abilityLevel.ListOfReadingLevel_LanguageAbility.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AbilityLevel>(abilityLevel);
                }
            }

            if(abilityLevel.ListOfWritingLevel_LanguageAbility.CheckList())
            {
                abilityLevel.ListOfWritingLevel_LanguageAbility.ForEach(i => i.WritingLevel.Id = result.Id);

                childResult = await abilityLevel.ListOfWritingLevel_LanguageAbility.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AbilityLevel>(abilityLevel);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<AbilityLevel>(abilityLevel);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AbilityLevel>> SaveCollection(this List<AbilityLevel> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AbilityLevel> result = new SuccessfulDataResult<AbilityLevel>();

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
