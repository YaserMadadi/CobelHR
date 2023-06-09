using EssentialCore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Entities
{
    public class CheckConnection
    {

        public string CheckConnectionAction()
        {
            return ConnectionManager.CheckConnection();
        }

        public override string ToString()
        {
            var connection =  EssentialCore.Tools.Configuartion.ConfigurationService.ReadSection<Connection>("Connection");


            return $@"
    Server          : {connection.Server}
    DataBase Name   : {connection.DataBase}
";
        }
    }
}
