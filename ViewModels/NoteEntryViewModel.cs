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
        private NotesControlViewModel ControlViewModel = null;

        private NoteModel _assignedNote;
        private Brush _backgroundBrush;
        private bool _isEdited = false;
        private string _editTextBox;

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

        public bool isEdited
        {
            get { return _isEdited; }
            set { _isEdited = value; NotifyOfPropertyChange(() => isEdited); }
        }

        public string EditTextBox
        {
            get { return _editTextBox; }
            set { _editTextBox = value; NotifyOfPropertyChange(() => EditTextBox); }
        }

        #endregion

        #region Constructor
        public NoteEntryViewModel(NoteModel noteModel, NotesControlViewModel controlViewModel = null)
        {
            AssignedNote = noteModel;
            ControlViewModel = controlViewModel;
        }
        #endregion

        #region Methods
        private void EditAssignedNote()
        {
            isEdited = true;
            EditTextBox = AssignedNote.Description;
        }

        private void DeleteAssignedNote()
        {
            AssignedNote.Delete();
        }

        private void HighlightAssignedNote()
        {
            AssignedNote.SwitchIsImportant();
        }

        private void ConfirmEdit()
        {
            isEdited = false;
            Console.WriteLine($"New text = {EditTextBox}");

            DataAcces.UpdateNoteText(AssignedNote, EditTextBox);
            AssignedNote.Description = EditTextBox;

            NotifyOfPropertyChange(() => AssignedNote);
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
            HighlightAssignedNote();
        }

        public void EditTextBoxPreviewKeyDown(ActionExecutionContext context)
        {
            var keyArgs = context.EventArgs as KeyEventArgs;
            if (keyArgs != null)
            {
                if (keyArgs.Key == Key.Enter)
                {
                    ConfirmEdit();
                }
            }
        }
        #endregion
    }
}
