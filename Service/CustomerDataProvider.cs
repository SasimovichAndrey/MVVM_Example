using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using MVVM_Example.Model;

namespace MVVM_Example.Service
{
    public class CustomerDataProvider
    {
        private ObservableCollection<Customer> customers;
        private CustomerDataProcessor dataProcessor;

        public CustomerDataProvider(CustomerDataProcessor dataProcessor)
        {
            customers = new ObservableCollection<Customer>();
            List<Customer> loadedCustomers = dataProcessor.LoadCustomers();

            foreach (Customer customer in loadedCustomers)
            {
                customers.Add(customer);
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return customers;
            }
        }
    }
}
