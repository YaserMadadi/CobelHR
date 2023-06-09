using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Core
{
    public class ExceptionLog : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "ExceptionLog", "Exception Log");

        #region Constructor
        public ExceptionLog() : this(0)
        {

        }

        public ExceptionLog(int id) : this(id, default)
        {

        }

        public ExceptionLog(int id, byte[] timeStamp) : base(id, timeStamp, ExceptionLog.Informer)
        {

        }

        #endregion

        #region Properties

		
        public DateTime Date { get; set; }
		
        public TimeSpan Time { get; set; }

        public string CommandName { get; set; }

        public string ExceptionType { get; set; }

        public string ErrorMessage { get; set; }

        public int ErrorNumber { get; set; }

        public int ErrorCode { get; set; }

        public string JsonValue { get; set; }


        #endregion

        #region    List Of Related Entities

        [JsonIgnore]
		public List<CommandParameter> ListOfCommandParameter { get; set; }

        #endregion


        public override bool Validate()
        {
            return this.CommandName.Validate() &&
                    this.ExceptionType.Validate() &&
                    this.ErrorMessage.Validate() &&
                    this.JsonValue.Validate();

        }
    }
}
