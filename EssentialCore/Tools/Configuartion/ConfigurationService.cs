using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Configuartion
{
    public class ConfigurationService
    {
        public static IConfiguration Configuration { get; set; }

        public static T ReadSection<T>(string sectionName)
        {
            return Configuration.GetSection(sectionName).Get<T>();
        }

        public static string GetValue(string key)
        {
            return Configuration[key];
        }
    }
}
