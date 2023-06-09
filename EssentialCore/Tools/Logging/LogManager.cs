using EssentialCore.Entities.Core;
using EssentialCore.ExtenssionMethod;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Logging
{
    public class LogManager
    {
        //public LogManager(T ex, SqlCommand command) : this(ex, command.CommandText, command.Parameters.ToJson())
        //{
        //}

        //public LogManager(T ex, string commandName, string parameters)
        //{
        //    this.exception = ex;

        //    this.commandName = commandName;

        //    this.commandParameters = parameters;
        //}

        //private string commandName { get; set; }

        ///// <summary>
        ///// JsonString : Key/Value paire of Parameters ...
        ///// </summary>
        //public string commandParameters { get; set; }


        //private T exception { get; set; }

        //private Entities.Log.Exception GetCurrentLog()
        //{
        //    return this.GetCurrentLog(this.exception);
        //}



        private static Entities.Log.Exception GetCurrentLog(Exception ex, string commandName, string commandParameters)
        {
            var log = new Entities.Log.Exception()
            {
                Date = DateTime.Now,
                Time = DateTime.Now.TimeOfDay,
                CommandName = commandName,
                CommandParameters = commandParameters,
                ExceptionType = ex.GetType().Name,
                ErrorMessage = ex.Message,
                ErrorNumber = 0,
                ErrorCode = 0,
                ExceptionJsonValue = Serializer.JsonSerializerManager.Serialize(ex)
            };

            if (ex is SqlException)
            {
                var sqlException = ex as SqlException;

                log.ErrorCode = sqlException.ErrorCode;
                log.ErrorNumber = sqlException.Number;
            }

            return log;
        }

        public static async Task<bool> Save<T>(T ex, SqlCommand command) where T : Exception
        {
            return await Save<T>(ex, command.CommandText, command.Parameters.ToJson());
        }

        public static async Task<bool> Save<T>(T ex, string commandName, string commandParameters) where T : Exception
        {
            var service = new BusinessLogic.Service<Entities.Log.Exception>();

            var transaction = new DataAccess.CoreTransaction();

            var currentLog = GetCurrentLog(ex, commandName, commandParameters);

            var userCredit = new UserCredit();

            IResult result = null;

            try
            {
                result = await service.Save(currentLog, userCredit, transaction);

                transaction.Commit();
            }
            catch (Exception localEx)
            {
                // Command Exception ( Last Failed Command !!! )
                await WriteToFile(ex, commandName, commandParameters);

                // Log Exception ( Save Log Exception in to DataBase Failed !!! )
                await WriteToFile(localEx, "Saving Log in Database", "");
            }
            finally
            {

            }

            return result.IsSucceeded;
        }

        public static async Task<bool> WriteToFile<T>(T ex, string commandName = "", string commandParameters = "") where T : Exception
        {
            string path = Configuartion.ConfigurationService.GetValue("LogFile\\path");

            if (!System.IO.Directory.Exists(path))

                System.IO.Directory.CreateDirectory(path);

            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                stringBuilder.AppendLine("-------------------------------");

                stringBuilder.AppendLine($"DateTime : {DateTime.Now}");

                stringBuilder.AppendLine("-------------------------------");

                stringBuilder.AppendLine(Serializer.JsonSerializerManager.Serialize(GetCurrentLog(ex, commandName, commandParameters)));

                stringBuilder.AppendLine("-------------------------------");

                await System.IO.File.WriteAllTextAsync($"{path}\\LogFile.txt", stringBuilder.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
