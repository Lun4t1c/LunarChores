using Caliburn.Micro;
using LunarChores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarChores.ViewModels
{
    public class StreakEntryViewModel : Screen
    {
        #region Properties
        private StreakModel _assignedStreak;

        public StreakModel AssignedStreak
        {
            get { return _assignedStreak; }
            set { _assignedStreak = value; NotifyOfPropertyChange(() => AssignedStreak); }
        }
        #endregion

        #region Constructor
        public StreakEntryViewModel(StreakModel streakModel)
        {
            AssignedStreak = streakModel;
        }
        #endregion

        #region Methods
        private void ResetAssignedStreak()
        {
            AssignedStreak.Reset();
        }
        #endregion

        #region Button clicks
        public void ResetButton()
        {
            Console.WriteLine("CLICK");
            ResetAssignedStreak();
        }
        #endregion
    }
}
