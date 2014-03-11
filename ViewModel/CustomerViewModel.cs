using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM_Example.Command;

namespace MVVM_Example.ViewModel
{
    class CustomerViewModel : WorkSpaceViewModel
    {
        RelayCommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(param => this.Save(),
                        param => this.CanSave);
                }
                return _saveCommand;
            }
        }
    }
}
