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
    public class ShellViewModel : Conductor<object>
    {
        #region Properties
        public string CurrentDayString { get { return CurrentDay.day_date.ToLongDateString(); } }
        private DayModel _currentDay;
        private Screen _currentViewModel;

        public DayModel CurrentDay
        {
            get { return _currentDay; }
            set { _currentDay = value; NotifyOfPropertyChange(() => CurrentDay); }
        }        

        public Screen CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; NotifyOfPropertyChange(() => CurrentViewModel); }
        }
        #endregion

        #region Constructor
        public ShellViewModel()
        {
            CurrentDay = DataAcces.GetLastDay();
            Console.WriteLine(CurrentDay.day_date.ToLongDateString());

            //DataAcces.spCreateNewDay();
        }
        #endregion

        #region Methods
        private void AddNote()
        {
            ShowNotes();

            IWindowManager manager = new WindowManager();
            manager.ShowWindowAsync(new ViewModels.NoteAdderViewModel( ((NotesControlViewModel)CurrentViewModel) ));
        }

        private void AddChore()
        {
            throw new NotImplementedException();
        }

        private void AddStreak()
        {
            throw new NotImplementedException();
        }

        private void ShowNotes()
        {
            if (CurrentViewModel?.GetType() == typeof(NotesControlViewModel))
                return;

            CurrentViewModel = new NotesControlViewModel();
            ActivateItemAsync(CurrentViewModel);
        }

        private void ShowChores()
        {
            if (CurrentViewModel?.GetType() == typeof(ChoresControlViewModel))
                return;

            CurrentViewModel = new ChoresControlViewModel();
            ActivateItemAsync(CurrentViewModel);
        }

        private void ShowStreaks()
        {
            if (CurrentViewModel?.GetType() == typeof(StreaksControlViewModel))
                return;

            CurrentViewModel = new StreaksControlViewModel();
            ActivateItemAsync(CurrentViewModel);
        }
        #endregion

        #region Button clicks
        public void AddNoteButton()
        {
            AddNote();
        }

        public void AddChoreButton()
        {
            AddChore();
        }

        public void AddStreakButton()
        {
            AddStreak();
        }

        public void NotesButton()
        {
            ShowNotes();
        }

        public void ChoresButton()
        {
            ShowChores();
        }

        public void StreaksButton()
        {
            ShowStreaks();
        }
        #endregion

        #region Input
        public void ExecuteFilterView(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;
            if (keyArgs != null)
            {
                if (keyArgs.Key == Key.Space)
                {
                    AddNote();
                }
            }
        }
        #endregion
    }
}
