using MVVM_Example.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVM_Example.ViewModel
{
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; set; }

        public event Action<object> RequestClose;

        public WorkspaceViewModel()
        {
            CloseCommand = new RelayCommand(OnRequestClose);
        }

        protected virtual void OnRequestClose(object sender)
        {
            if(RequestClose != null)
                this.RequestClose(sender);
        }
    }
}
