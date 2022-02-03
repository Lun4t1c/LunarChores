using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarChores.Models
{
    public class ChoreModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Properties
        private bool? _isDoneToday = null;

        public bool? IsDoneToday
        {
            get 
            {
                if (_isDoneToday != null) return _isDoneToday; 
                else return _isDoneToday = DataAcces.CheckIsChoreDoneToday(this);
            }
        }
        #endregion

        #region Methods
        public void Uncheck()
        {
            DataAcces.UncheckChore(this);
        }
        #endregion
    }
}
