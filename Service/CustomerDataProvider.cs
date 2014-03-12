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

        public CustomerDataProvider()
        {
            customers = new ObservableCollection<Customer>();
            
            // DEBUG!
            customers.Add(new Customer() { FirstName = "Siarhey", LastName = "Kovalchik", Email = "sk@gmail.by" });
            customers.Add(new Customer() { FirstName = "Miha", LastName = "Kovalchik", Email = "sk@gmail.by" });
            customers.Add(new Customer() { FirstName = "Slava", LastName = "Kovalchik", Email = "sk@gmail.by" });
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
