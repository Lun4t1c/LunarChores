using Caliburn.Micro;
using LunarChores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LunarChores.ViewModels
{
    public class StreakAdderViewModel : Screen
    {
        #region Properties
        private string _streakName;

        public string StreakName
        {
            get { return _streakName; }
            set { _streakName = value; NotifyOfPropertyChange(() => StreakName); }
        }
        #endregion

        #region Constructor
        public StreakAdderViewModel()
        {

        }
        #endregion

        #region Methods
        private void Confirm()
        {
            StreakModel streakModel = new StreakModel() { Name = StreakName };
            DataAcces.spInsertStreak(streakModel);
            ((System.Windows.Window)this.GetView()).Close();
        }
        #endregion

        #region Input
        public void ExecuteFilterView(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;
            if (keyArgs != null)
            {
                if (keyArgs.Key == Key.Enter)
                {
                    Confirm();
                }
            }
        }
        #endregion
    }
}
