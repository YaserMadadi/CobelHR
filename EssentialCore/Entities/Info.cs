using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities
{
    public class Info
    {
        public Info() : this(string.Empty, string.Empty)
        {

        }
        public Info(string schema, string name)
        {
            this.Schema = schema;

            this.Name = name;
        }

        public Info(string schema, string name, string title) : this(schema, name)
        {
            this.Title = title ?? $"{schema}.{name }";// string.IsNullOrWhiteSpace(title) ? $"{schema}.{name}" : title.Trim();
        }

        public string Schema { get; init; }

        public string Name { get; init; }

        [JsonIgnore]
        public string Title { get; set; }

        public string FullName
        {
            get
            {
                return $"{Schema}.{Name}";
            }
        }
    }
}
