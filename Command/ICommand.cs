using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM_Example.Command
{
    class ICommand
    {
        public bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter);
    }
}
