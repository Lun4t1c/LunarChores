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
    public class ChoreAdderViewModel : Screen
    {
        #region Properties
        private string _choreName = "";

        public string ChoreName
        {
            get { return _choreName; }
            set { _choreName = value; NotifyOfPropertyChange(() => ChoreName); }
        }
        #endregion

        #region Constructor
        public ChoreAdderViewModel()
        {

        }
        #endregion

        #region Methods
        private void Confirm()
        {
            ChoreModel choreModel = new ChoreModel() { Name = ChoreName };
            DataAcces.spInsertChore(choreModel);
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
