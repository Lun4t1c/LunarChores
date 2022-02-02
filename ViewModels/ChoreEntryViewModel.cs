using Caliburn.Micro;
using LunarChores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarChores.ViewModels
{
    public class ChoreEntryViewModel : Screen
    {
        #region Properties
        private ChoreModel _assignedChore;

        public ChoreModel AssignedChore
        {
            get { return _assignedChore; }
            set { _assignedChore = value; NotifyOfPropertyChange(() => AssignedChore); }
        }
        #endregion

        #region Constructor
        public ChoreEntryViewModel(ChoreModel choreModel)
        {
            AssignedChore = choreModel;
        }
        #endregion

        #region Methods

        #endregion

        #region Button clicks

        #endregion
    }
}
