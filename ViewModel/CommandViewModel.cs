using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM_Example.Command;

namespace MVVM_Example.ViewModel
{
    class CommandViewModel : ViewModelBase
    {
        public CommandViewModel(string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            base.DisplayName = displayName;
            this.Command = command;
        }

        public ICommand Command { get; private set; }
    }
}
