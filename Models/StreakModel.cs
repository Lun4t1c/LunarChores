using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarChores.Models
{
    public class StreakModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Methods
        public void reset()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
