using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.XCode
{
    public class Message : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("XCode", "Message", "Message");

        #region Constructor
        public Message() : this(0)
        {

        }

        public Message(int id) : this(id, default)
        {

        }

        public Message(int id, byte[] timeStamp) : base(id, timeStamp, Message.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
        public int? Code { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					Code.Validate();
        }
    }
}
