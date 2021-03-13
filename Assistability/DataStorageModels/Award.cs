/// <summary>
/// Nathaniel Webber
/// Created: 2021/03/08
/// 
/// This is a storage model for the Award Objects
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorageModels
{
    public class Award
    {
        public int AwardID { get; set; }
        public string AwardName { get; set; }
        public string AwardDescription { get; set; }
        public int? GoalID { get; set; }
        public int? GoalTypeID { get; set; }
        public bool? Active { get; set; }
    }
}
