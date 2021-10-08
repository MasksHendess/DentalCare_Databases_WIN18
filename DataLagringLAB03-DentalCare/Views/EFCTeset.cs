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
            while (true)
            {
                ListCustomers();
                Console.WriteLine("Choose Action:\n1.Add Customer" +
                    "\n2. Update Customer\n3. Delete Customer\n4. Exit Application ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                      var customer =  CreateCustomer();
                        SaveCustomer(customer);
                        break;
                    case "2":
                        var customer2 = CreateCustomer();
                        UpdateCustomer(customer2); 
                        break;
                    case "3":
                        Console.WriteLine("Enter customer id:");
                        var id = Console.ReadLine();
                        if(int.TryParse(id, out int idInt))
                        { 
                        DeleteCustomerBySocialSecurityNumber(idInt);
                        }
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();
            }
        }


        public void ListCustomers()
        {
            Console.Clear();
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

        public Customer CreateCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter First Name:\n");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:\n");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Enter Social Security Number:\n");
            customer.SocialSecurityNumber = Console.ReadLine();
            return customer;
        }

        public void SaveCustomer(Customer customer) // Send in a Customer
        {
            using (var db = new DentalCareContext()) // Conect
            {
                db.Customers.Add(customer); // and add him to Customers Table in Database
                db.SaveChanges();           // Gotta Save Bro!

                Console.WriteLine("Customer added!");
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var db = new DentalCareContext())
            {
                var foundCustomer = db.Customers.FirstOrDefault(x => x.FirstName == customer.FirstName);
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

        public void DeleteCustomerBySocialSecurityNumber(int id)// this name tho....
        {
            using (var db = new DentalCareContext()) // Hello DataBase plz give stuff
            {
                var foundCustomer = db.Customers.FirstOrDefault(x => x.Id == id);
                // Serch for guy, find guy kill guy if dont find guy, he dead already.
                if (foundCustomer == null) return; // oneline if statment btw 

                db.Customers.Remove(foundCustomer); // Kill Guy 
                db.SaveChanges();                   // Never Seeing that Guy again... Good Ridance!
            }
        }
    }
}
