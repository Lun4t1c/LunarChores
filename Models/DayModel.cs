using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarChores.Models
{
    public class DayModel
    {
        #region Database properties
        public int Id { get; set; }
        public DateTime day_date { get; set; }
        public bool close_eyes { get; set; }
        public bool take_vitamin { get; set; }
        #endregion
    }
}
