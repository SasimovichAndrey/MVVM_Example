using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM_Example.Model;

namespace MVVM_Example.Service
{
    public interface CustomerDataProcessor
    {
        List<Customer> LoadCustomers();

        void StoreCustomerList(IEnumerable<Customer> cutomers);
    }
}
