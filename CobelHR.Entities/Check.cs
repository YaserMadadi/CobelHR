using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Entities
{
    public class Check
    {
        public Check()
        {
            this.Header = "Cobel Darou Corp. [ IS Department ]";

            this.ServiceName = "C O B E L   [ HR.Core ]   S E R V I C E  ( Web API )";

             this.Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();

            this.Technology = "Microsoft .Net 5.0";

            this.Footer = "Developed and Support by Yaser Madadi. IS Department.";
        }
        public string Header { get; set; }

        public string Technology { get; set; }

        public string Version { get; set; }

        public string ServiceName { get; set; }

        public string Footer { get; set; }

        public DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public override string ToString()
        {
            return $@"
    ----------------------------------------------------------------
    {Header}
    ----------------------------------------------------------------

    Service Name    : {ServiceName}

    Service Version : {Version}

    Used Technology : {Technology}

    Current Date    : {CurrentDate.ToLongDateString()}

    Current Time    : {CurrentDate.ToLongTimeString()}

    Status          : Started...

    ----------------------------------------------------------------
    {Footer}
    ----------------------------------------------------------------
                    ";
        }


    }
}
