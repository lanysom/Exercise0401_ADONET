using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManager.DAL
{
    public class CustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Customer> GetAll()
        {
            // TODO: 1. Implement the method so it return a list of all the customers in the database

            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            // TODO: 2. Implement the method so it returns the customer with the specified id.

            throw new NotImplementedException();
        }

        public Customer Update(Customer customer)
        {
            // TODO: 3. Update the customer in the database with the provided data and return the updated customer object

            throw new NotImplementedException();
        }

        public Customer Insert(Customer customer)
        {
            // TODO: 4. Insert a new customer into the database with the provided data and return the new customer object 

            throw new NotImplementedException();
        }

        public bool Delete(Customer customer)
        {
            // TODO: 5. Delete the customer defined in the provided customer object from the database and return a value indicating the success/failure of the operation

            throw new NotImplementedException();
        }
    }
}
