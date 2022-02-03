using Caliburn.Micro;
using LunarChores.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarChores.ViewModels
{
    public class NotesControlViewModel : Screen
    {
        #region Properties
        private BindableCollection<NoteModel> _notes;
        private Color _highlightColor = Color.Red;
        private BindableCollection<NoteEntryViewModel> _notesViewModels = new BindableCollection<NoteEntryViewModel>();

        public BindableCollection<NoteModel> Notes
        {
            get { return _notes; }
            set { _notes = value; NotifyOfPropertyChange(() => Notes); }
        }        

        public Color HighlightColor
        {
            get { return _highlightColor; }
            set { _highlightColor = value; NotifyOfPropertyChange(() => HighlightColor); }
        }       

        public BindableCollection<NoteEntryViewModel> NotesViewModels
        {
            get { return _notesViewModels; }
            set { _notesViewModels = value; NotifyOfPropertyChange(() => NotesViewModels); }
        }

        #endregion

        #region Constructor
        public NotesControlViewModel()
        {
            Notes = DataAcces.GetAllNotes();

            ReloadViewModels();
        }
        #endregion

        #region Methods
        private void ReloadViewModels()
        {
            NotesViewModels.Clear();
            foreach (NoteModel noteModel in Notes)
            {
                NoteEntryViewModel noteEntryViewModel = new NoteEntryViewModel(noteModel);

                if (noteModel.Is_important) noteEntryViewModel.BackgroundBrush = System.Windows.Media.Brushes.Red;

                NotesViewModels.Add(noteEntryViewModel);
            }
        }

        public void ReloadNotes()
        {
            Console.WriteLine("Reloadibng");
            Notes = DataAcces.GetAllNotes();

            Notes.Clear();
            foreach (NoteModel noteModel in Notes)            
                NotesViewModels.Add(new NoteEntryViewModel(noteModel));
        }

        public void AddNote(NoteModel noteModel)
        {
            Notes.Add(noteModel);
            NotesViewModels.Add(new NoteEntryViewModel(noteModel));
        }
        #endregion
    }
}
