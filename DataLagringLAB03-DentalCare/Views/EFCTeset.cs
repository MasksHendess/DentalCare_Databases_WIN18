using DataLagringLAB03_DentalCare.Domain;
using System;
using System.Linq;

namespace DataLagringLAB03_DentalCare.Views
{
    class EFCTest
    {
        public void EntetyCoreTesting()
        {
            Console.Title = "DataLagringLAB03: Sunspear DentalCare";
            Console.ForegroundColor = ConsoleColor.Green;

            //var JohnConnington = new Customer("John", "Connigton", "214-1234"); // Test Object (dont put the dick in it)
            ////SaveCustomer(JohnConnington); // use this to add new Customers to the Table
            //JohnConnington.SocialSecurityNumber = "11111-11111"; // Change stuff, cuz hey everything is public
            ////UpdateCustomer(JohnConnington);// Updates the guy
            ////ListCustomers(); // Lists the guys
            ////Console.ReadKey(); 
            //DeleteCustomerBySocialSecurityNumber(JohnConnington.SocialSecurityNumber); // write a SSN to Delete
            while(true)
            {
                Console.WriteLine("Choose Action:\n1. List Customers\n2. Add Customer" +
                    "\n3. Update Customer\n4. Delete Customer ");
           var choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        ListCustomers();
                        break;
                    case "2":
                        SaveCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        DeleteCustomerBySocialSecurityNumber();
                        break;
                    }
                   ListCustomers();
            Console.ReadKey();
            }
        }


        public void ListCustomers()
        {
            Console.WriteLine("Customers in Database:\n");
            using (var db = new DentalCareContext())// Connecting to Database
            {
                var customerList = db.Customers.ToList(); // Loads the Table Customers to a List

                foreach (var customer in customerList) // cw customerlist (with info from Database!)
                {
                    Console.WriteLine($"{customer.FirstName} {customer.LastName}, {customer.SocialSecurityNumber}, {customer.Id}");
                }
            }
        }

        public void SaveCustomer(Customer customer) // Send in a Customer
        {
            using (var db = new DentalCareContext()) // Conect
            {
                db.Customers.Add(customer); // and add him to Customers Table in Database
                db.SaveChanges();           // Gotta Save Bro!
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var db = new DentalCareContext())
            {
                var foundCustomer = db.Customers.FirstOrDefault(x => x.Id == customer.Id);
                // Serch trough database find guy or dont find guy
                if (foundCustomer == null) // Dont find guy? Do nothing
                {
                    return;
                }
                foundCustomer.FirstName = customer.FirstName; // Found Guy? New values!
                foundCustomer.LastName = customer.LastName;
                foundCustomer.SocialSecurityNumber = customer.SocialSecurityNumber;

                db.SaveChanges(); // And as always if you changes something you save something
            }
        }

        public void DeleteCustomerBySocialSecurityNumber(string socialSecurityNumber)// this name tho....
        {
            using (var db = new DentalCareContext()) // Hello DataBase plz give stuff
            {
                var foundCustomer = db.Customers.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);
                // Serch for guy, find guy kill guy if dont find guy, he dead already.
                if (foundCustomer == null) return; // oneline if statment btw 

                db.Customers.Remove(foundCustomer); // Kill Guy 
                db.SaveChanges();                   // Never Seeing that Guy again... Good Ridance!
            }
        }
    }
}
