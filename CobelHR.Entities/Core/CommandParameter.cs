using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Core
{
    public class CommandParameter : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "CommandParameter", "Command Parameter");

        #region Constructor
        public CommandParameter() : this(0)
        {

        }

        public CommandParameter(int id) : this(id, default)
        {

        }

        public CommandParameter(int id, byte[] timeStamp) : base(id, timeStamp, CommandParameter.Informer)
        {

        }

        #endregion

        #region Properties


        public Core.ExceptionLog ExceptionLog { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string TypeName { get; set; }

        #endregion

        #region    List Of Related Entities

        #endregion


        public override bool Validate()
        {
            return this.ExceptionLog.Validate() &&
                    this.Name.Validate() &&
                    this.TypeName.Validate();
        }
    }
}
