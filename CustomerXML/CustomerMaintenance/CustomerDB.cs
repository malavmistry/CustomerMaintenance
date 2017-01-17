using System;
using System.Collections.Generic;
using System.Xml;

namespace CustomerMaintenance
{
    /// <summary>
    /// CustomerDB class
    /// </summary>
    public static class CustomerDB
    {

        private const string path =
        @"G:\computer science\applications in .net\CustomerXML\CustomerMaintenance\Customer.xml";
        // TODO: Add code that defines the path for the Customers.xml file

        public static void SaveCustomers(List<Customer> customers)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = (" ");
            // create the XmlWriter object
            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            // write the start of the document
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Customers");
            // write each Product object to the xml file
            foreach (Customer customer in customers)
            {
                xmlOut.WriteStartElement("Customer");
                xmlOut.WriteElementString("FirstName",
                customer.FirstName);
                xmlOut.WriteElementString("LastName",
                customer.LastName);
                xmlOut.WriteElementString("Email",
                Convert.ToString(customer.Email));
                xmlOut.WriteEndElement();
            }
            // write the end tag for the root element
            xmlOut.WriteEndElement();
            // close the XmlWriter object
            xmlOut.Close();


        }

        public static List<Customer> GetCustomers()
        {
            // create the list
            List<Customer> customers = new List<Customer>();
            // create the XmlReaderSettings object
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            // create the XmlReader object
            XmlReader xmlIn = XmlReader.Create(path, settings);
            // read past all nodes to the first Product node
            if (xmlIn.ReadToDescendant("Customer"))
            {
                // create one Product object for each Product node
                do
                {
                    Customer customer = new Customer();
                    xmlIn.ReadStartElement("Customer");
                    customer.FirstName = xmlIn.ReadElementContentAsString();
                    customer.LastName = xmlIn.ReadElementContentAsString();
                    customer.Email = xmlIn.ReadElementContentAsString();
                    customers.Add(customer);
                }
                while (xmlIn.ReadToNextSibling("Customer"));
            }
            // close the XmlReader object
            xmlIn.Close();


            // TODO: Add code that reads data from the Customers.xml file
            // and stores that data in the List<Customer> object

            return customers;
        }
    }
}