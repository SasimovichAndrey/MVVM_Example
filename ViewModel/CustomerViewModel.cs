using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM_Example.Command;
using System.Windows.Input;
using MVVM_Example.Model;

namespace MVVM_Example.ViewModel
{
    public class CustomerViewModel : WorkspaceViewModel
    {
        #region Fields

        private Customer customer;

        private RelayCommand saveCommand;

        #endregion //Fields

        #region Properties

        public String FirstName
        {
            get
            {
                return customer.FirstName;
            }
            set
            {
                this.customer.FirstName = value;
                base.OnPropertyChanged("FirstName");
            }
        }
        public String LastName
        {
            get
            {
                return customer.LastName;
            }
            set
            {
                this.customer.LastName = value;
                base.OnPropertyChanged("LastName");
            }
        }
        public String Email
        {
            get
            {
                return customer.Email;
            }
            set
            {
                this.customer.Email = value;
                base.OnPropertyChanged("Email");
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return saveCommand;
            }
        }

        #endregion

        public event Action<object, Customer> SaveAction;

        public CustomerViewModel(Customer customer)
        {
            this.customer = customer;
            this.saveCommand = new RelayCommand(OnRequestSave);
        }

        public void OnCloseWorkspace(object sender) 
        {
            OnRequestClose(this);
        }

        public void OnRequestSave(object sender)
        {
            if(SaveAction != null)
                SaveAction(this, customer);
        }
    }
}
