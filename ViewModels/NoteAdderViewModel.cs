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
    public class NoteAdderViewModel : Screen
    {
        #region Properties
        private NotesControlViewModel hViewModel;
        private bool _isImportantCheckBox;
        private string _noteText;

        public bool isImportantCheckBox
        {
            get { return _isImportantCheckBox; }
            set { _isImportantCheckBox = value; NotifyOfPropertyChange(() => isImportantCheckBox); }
        }        

        public string NoteText
        {
            get { return _noteText; }
            set { _noteText = value; NotifyOfPropertyChange(() => NoteText); }
        }

        #endregion

        #region Constructor
        public NoteAdderViewModel(NotesControlViewModel hviewmodel)
        {
            hViewModel = hviewmodel;
            NoteText = "";
            isImportantCheckBox = false;
        }
        #endregion

        #region Methods
        private void Confirm()
        {
            NoteModel noteModel = new NoteModel() { Description = NoteText, Is_important = isImportantCheckBox };
            Console.WriteLine($"{noteModel.Description} - {noteModel.Is_important}");
            DataAcces.InsertNote(noteModel);
            hViewModel?.AddNote(noteModel);
            ((System.Windows.Window)this.GetView()).Close();            
        }
        #endregion

        #region Button clicks
        public void ConfirmButton()
        {
            Confirm();
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
