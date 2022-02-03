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
            Console.WriteLine($"{AssignedChore.Name} - {AssignedChore.IsDoneToday}");
        }
        #endregion

        #region Methods
        private void Uncheck()
        {
            System.Windows.MessageBoxResult dialogResult = System.Windows.MessageBox.Show($"Are you sure?", "", System.Windows.MessageBoxButton.YesNo);
            if (dialogResult == System.Windows.MessageBoxResult.Yes)
            {
                AssignedChore.Uncheck();
            }
            else if (dialogResult == System.Windows.MessageBoxResult.No)
                return;
        }
        #endregion

        #region Button clicks
        public void UncheckButton()
        {
            Console.WriteLine("CLICK");
            Uncheck();
        }
        #endregion
    }
}
