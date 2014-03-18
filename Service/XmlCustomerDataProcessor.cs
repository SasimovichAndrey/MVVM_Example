using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using MVVM_Example.Model;
using System.IO;

namespace MVVM_Example.Service
{
    public class XmlCustomerDataProcessor : CustomerDataProcessor
    {
        private String fileName;

        private String FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                if (value == "" || value == null)
                    throw new ArgumentNullException("Filename can't be empty or null");
                fileName = value;
            }
        }

        public XmlCustomerDataProcessor(string fileName)
        {
            FileName = fileName;
        }

        public List<Customer> LoadCustomers()
        {
            List<Customer> resultList = new List<Customer>();
            XmlTextReader reader = null;

            try
            {
                reader = new XmlTextReader(fileName);
                reader.ReadStartElement();

                while (reader.Read())
                {
                    if (reader.Name == "Customer")
                    {
                        string firstName = reader.GetAttribute("FirstName");
                        string lastName = reader.GetAttribute("LastName");
                        string email = reader.GetAttribute("Email");
                        Customer newCustomer = new Customer() { FirstName = firstName, LastName = lastName, Email = email };

                        resultList.Add(newCustomer);
                    }
                }
            }
            catch(XmlException ex)
            {
                throw new CustomerDataFileFormatexception("Input file is in incorrect format", ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return resultList;
        }

        public void StoreCustomerList(IEnumerable<Customer> customers)
        {
            throw new NotImplementedException();
        }
    }

    class CustomerDataFileFormatexception : Exception
    {
        public CustomerDataFileFormatexception(string message, Exception innerException) : base(message, innerException) { }
    }
}
