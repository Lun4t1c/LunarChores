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
    public class NoteEntryViewModel : Screen
    {
        #region Properties
        private NoteModel _assignedNote;

        public NoteModel AssignedNote
        {
            get { return _assignedNote; }
            set { _assignedNote = value; NotifyOfPropertyChange(() => AssignedNote); }
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
            Console.WriteLine("EDIT");
        }

        private void DeleteAssignedNote()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Button clicks
        public void EditButton()
        {
            EditAssignedNote();
        }

        public void HighlightButton()
        {
            Console.WriteLine("HIGHLIGHT");
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
