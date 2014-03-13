using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using MVVM_Example.ViewModel;
using MVVM_Example.Command;
using MVVM_Example.Model;
using MVVM_Example.Service;

namespace MVVM_Example.ViewModel
{
    public class MainWindowViewModel : WorkspaceViewModel
    {
        #region Fields

        private ObservableCollection<WorkspaceViewModel> _workspaces;
        private ObservableCollection<CommandViewModel> _commands;
        private CustomerDataProvider dataProvider;

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

        public MainWindowViewModel() : base()
        {
            dataProvider = new CustomerDataProvider();

            CommandViewModel cvAllCustomerModel = new CommandViewModel("All Customers", new RelayCommand(AddNewAllCustomersWokspace, AddAllCutomersViewCanExecute));
            CommandViewModel cvNewCustomerModel = new CommandViewModel("New Customer", new RelayCommand(AddNewCustomerWorkspace));
            Commands.Add(cvAllCustomerModel);
            Commands.Add(cvNewCustomerModel);
        }

        protected void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
            {
                foreach (WorkspaceViewModel workspace in e.NewItems)
                {
                    workspace.RequestClose += this.OnWorkspaceRequestClose;
                    if(workspace is AllCustomersViewModel)
                    {
                        foreach (WorkspaceViewModel ws in _workspaces)
                        {
                            if (ws is CustomerViewModel)
                            {
                                ((CustomerViewModel)ws).SaveAction += ((AllCustomersViewModel)workspace).OnNewCustomerSaveAction;
                            }
                        }
                    }
                    else if (workspace is CustomerViewModel)
                    {
                        foreach (WorkspaceViewModel ws in _workspaces)
                        {
                            if (ws is AllCustomersViewModel)
                            {
                                ((CustomerViewModel)workspace).SaveAction += ((AllCustomersViewModel)ws).OnNewCustomerSaveAction;
                            }
                        }
                    }
                }
            }


            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }

        protected void OnWorkspaceRequestClose(object sender)
        {
            this.Workspaces.Remove(sender as WorkspaceViewModel);
        }

        public void AddNewAllCustomersWokspace(object sender)
        {
            AllCustomersViewModel model = new AllCustomersViewModel(dataProvider){DisplayName = "All Customers"};
            RelayCommand closeCommand = new RelayCommand(model.CloseWorkspace);
            model.CloseCommand = closeCommand;

            Workspaces.Add(model);
        }

        private bool AddAllCutomersViewCanExecute(object sender)
        {
            foreach (WorkspaceViewModel model in _workspaces)
            {
                if (model is AllCustomersViewModel)
                    return false;
            }
            return true;
        }

        public void AddNewCustomerWorkspace(object sender)
        {
            CustomerViewModel model = new CustomerViewModel(new Customer()) { DisplayName = "New Customer" };
            RelayCommand closeCommand = new RelayCommand(model.OnCloseWorkspace);
            model.CloseCommand = closeCommand;

            Workspaces.Add(model);
        }
    }
}
