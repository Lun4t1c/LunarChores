using Caliburn.Micro;
using LunarChores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarChores.ViewModels
{
    public class ChoresControlViewModel : Screen
    {
        #region Properties
        private BindableCollection<ChoreModel> _chores = new BindableCollection<ChoreModel>();
        private BindableCollection<ChoreEntryViewModel> _choreViewModels = new BindableCollection<ChoreEntryViewModel>();

        public BindableCollection<ChoreModel> Chores
        {
            get { return _chores; }
            set { _chores = value; NotifyOfPropertyChange(() => Chores); }
        }        

        public BindableCollection<ChoreEntryViewModel> ChoreViewModels
        {
            get { return _choreViewModels; }
            set { _choreViewModels = value; NotifyOfPropertyChange(() => ChoreViewModels); }
        }
        #endregion

        #region Constructor
        public ChoresControlViewModel()
        {
            Chores = DataAcces.GetAllChores();

            foreach (ChoreModel choreModel in Chores)
                ChoreViewModels.Add(new ChoreEntryViewModel(choreModel));
        }
        #endregion

        #region Methods

        #endregion
    }
}
