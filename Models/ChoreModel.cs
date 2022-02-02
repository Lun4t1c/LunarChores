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
        public bool? isDoneToday { get; set; } = null;
        #endregion

        #region Methods
        public void Uncheck()
        {
            throw new NotImplementedException();
        }

        public bool CheckIsDoneToday()
        {
            if (isDoneToday != null) return (bool)isDoneToday;
            else return (bool)(isDoneToday = DataAcces.CheckIsChoreDoneToday(this.Id));
        }
        #endregion
    }
}
