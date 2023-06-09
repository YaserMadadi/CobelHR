using EssentialCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Entities.Partial.HR
{
    public class OrgChart : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "OrgChart", "Organization Chart");

        #region Constructor
        public OrgChart() : this(0)
        {

        }

        public OrgChart(int id) : this(id, default)
        {

        }

        public OrgChart(int id, byte[] timeStamp) : base(id, timeStamp, OrgChart.Informer)
        {

        }

        #endregion

        #region Properties

        public string Title { get; set; }

        public string Name { get; set; }

        public int Pid { get; set; }

        #endregion


    }
}
