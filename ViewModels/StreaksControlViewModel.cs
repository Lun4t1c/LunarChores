using Caliburn.Micro;
using LunarChores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarChores.ViewModels
{
    public class StreaksControlViewModel : Screen
    {
        #region Properties
        private BindableCollection<StreakModel> _streaks = new BindableCollection<StreakModel>();
        private BindableCollection<StreakEntryViewModel> _streaksViewModels = new BindableCollection<StreakEntryViewModel>();

        public BindableCollection<StreakModel> Streaks
        {
            get { return _streaks; }
            set { _streaks = value; NotifyOfPropertyChange(() => Streaks); }
        }        

        public BindableCollection<StreakEntryViewModel> StreaksViewModels
        {
            get { return _streaksViewModels; }
            set { _streaksViewModels = value; NotifyOfPropertyChange(() => StreaksViewModels); }
        }
        #endregion


        #region Constructor
        public StreaksControlViewModel()
        {
            Streaks = DataAcces.GetAllStreaks();
            RealoadViewModels();
        }
        #endregion


        #region Methods
        private void RealoadViewModels()
        {
            StreaksViewModels.Clear();
            foreach (StreakModel streakModel in Streaks)
                StreaksViewModels.Add(new StreakEntryViewModel(streakModel));
        }
        #endregion
    }
}
