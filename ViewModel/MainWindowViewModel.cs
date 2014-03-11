using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using MVVM_Example.ViewModel;

namespace MVVM_Example.ViewModel
{
    public class MainWindowViewModel : WorkspaceViewModel
    {
        #region Fields

        private ObservableCollection<WorkspaceViewModel> _workspaces;
        private ObservableCollection<CommandViewModel> _commands;

        #endregion //Fields

        #region Properties

        public ObservableCollection<CommandViewModel> Commands
        {
            get
            {
                if (_commands == null)
                {
                    _commands = new ObservableCollection<CommandViewModel>();
                }

                return _commands;
            }

        }

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        #endregion //Properties

        public MainWindowViewModel(String path) : base()
        {
        }

        protected void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        protected void OnWorkspaceRequestClose(object sender)
        {
            this.Workspaces.Remove(sender as WorkspaceViewModel);
        }
    }
}
