using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MVVM_Example.Model;
using MVVM_Example.Service;

namespace MVVM_Example.ViewModel
{
    class AllCustomersViewModel : WorkspaceViewModel
    {
        private CustomerDataProvider dataProvider;

        public AllCustomersViewModel(CustomerDataProvider provider)
        {
            dataProvider = provider;        
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return dataProvider.Customers;
            }
        }

        public void OnNewCustomerSaveAction(object sender, Customer customer)
        {
            Customers.Add(customer);
        }

        public void CloseWorkspace(object sender)
        {
            OnRequestClose(this);
        }
    }
}
