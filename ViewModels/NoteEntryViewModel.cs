using Caliburn.Micro;
using LunarChores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace LunarChores.ViewModels
{
    public class NoteEntryViewModel : Screen
    {
        #region Properties
        private NoteModel _assignedNote;
        private Brush _backgroundBrush;

        public NoteModel AssignedNote
        {
            get { return _assignedNote; }
            set { _assignedNote = value; NotifyOfPropertyChange(() => AssignedNote); }
        }        

        public Brush BackgroundBrush
        {
            get { return _backgroundBrush; }
            set { _backgroundBrush = value; NotifyOfPropertyChange(() => BackgroundBrush); }
        }
        #endregion

        #region Constructor
        public NoteEntryViewModel(NoteModel noteModel)
        {
            AssignedNote = noteModel;
        }
        #endregion

        #region Methods
        private void EditAssignedNote()
        {
            throw new NotImplementedException();
        }

        private void DeleteAssignedNote()
        {
            AssignedNote.Delete();
        }

        private void HighlightAssignedNote()
        {
            AssignedNote.SwitchIsImportant();
        }
        #endregion

        #region Button clicks
        public void EditButton()
        {
            EditAssignedNote();
        }

        public void HighlightButton()
        {
            HighlightAssignedNote();
        }

        public void DeleteButton()
        {
            DeleteAssignedNote();
        }
        #endregion

        #region Input
        public void ucDoubleClick()
        {
            DeleteAssignedNote();
        }
        #endregion
    }
}
