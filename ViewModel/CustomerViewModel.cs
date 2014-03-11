using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM_Example.Command;
using System.Windows.Input;

namespace MVVM_Example.ViewModel
{
    class CustomerViewModel : WorkspaceViewModel
    {
        RelayCommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                //if (_saveCommand == null)
                //{
                //    _saveCommand = new RelayCommand(param => this.Save(),
                //        param => this.CanSave);
                //}
                return _saveCommand;
            }
        }
    }
}
