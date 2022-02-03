using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarChores.Models
{
    public class NoteModel
    {
        #region Database columns
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Is_important { get; set; }
        #endregion

        #region Methods
        public void SwitchIsImportant()
        {
            DataAcces.HighlightNote(this);
        }

        public void UpdateDescription()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            DataAcces.DeleteNote(this);
        }
        #endregion
    }
}
