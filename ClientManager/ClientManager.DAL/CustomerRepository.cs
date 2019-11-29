using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Customers";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Customer
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Firstname = reader["Firstname"] as string,
                        Lastname = reader["Lastname"] as string,
                        Address = reader["Address"] as string,
                        Zip = reader["Zip"] as string,
                        City = reader["City"] as string,
                        Phone = reader["Phone"] as string,
                        Email = reader["Email"] as string
                    };
                }
            }
        }

        public Customer Get(int id)
        {
            // TODO: 2. Implement the method so it returns the customer with the specified id.
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Customers WHERE Id = @id";
                cmd.Parameters.AddWithValue("id", id);

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Customer
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Firstname = reader["Firstname"] as string,
                        Lastname = reader["Lastname"] as string,
                        Address = reader["Address"] as string,
                        Zip = reader["Zip"] as string,
                        City = reader["City"] as string,
                        Phone = reader["Phone"] as string,
                        Email = reader["Email"] as string
                    };
                }
                return null;
            }
        }

        public Customer Update(Customer customer)
        {
            // TODO: 3. Update the customer in the database with the provided data and return the updated customer object
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Customers SET " +
                    "Firstname = @firstname, " +
                    "Lastname = @lastname, " +
                    "Address = @address, " +
                    "Zip = @zip, " +
                    "City = @city, " +
                    "Phone = @phone, " +
                    "Email = @email " +
                    "WHERE Id = @id";
                cmd.Parameters.AddWithValue("firstname", customer.Firstname);
                cmd.Parameters.AddWithValue("lastname", customer.Lastname);
                cmd.Parameters.AddWithValue("address", customer.Address);
                cmd.Parameters.AddWithValue("zip", customer.Zip);
                cmd.Parameters.AddWithValue("city", customer.City);
                cmd.Parameters.AddWithValue("phone", customer.Phone);
                cmd.Parameters.AddWithValue("email", customer.Email);
                cmd.Parameters.AddWithValue("id", customer.Id);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    return customer;
                }
                throw new RepositoryException("Data was not updated");
            }
        }

        public Customer Insert(Customer customer)
        {
            // TODO: 4. Insert a new customer into the database with the provided data and return the new customer object 
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText =
                    "INSERT INTO Customers " +
                    "VALUES(@firstname, @lastname, @address, @zip, @city, @phone, @email); " +
                    "SELECT SCOPE_IDENTITY(); ";

                cmd.Parameters.AddWithValue("firstname", customer.Firstname);
                cmd.Parameters.AddWithValue("lastname", customer.Lastname);
                cmd.Parameters.AddWithValue("address", customer.Address);
                cmd.Parameters.AddWithValue("zip", customer.Zip);
                cmd.Parameters.AddWithValue("city", customer.City);
                cmd.Parameters.AddWithValue("phone", customer.Phone);
                cmd.Parameters.AddWithValue("email", customer.Email);

                customer.Id = Convert.ToInt32(cmd.ExecuteScalar());

                if (customer.Id > 0)
                {
                    return customer;
                }
                throw new RepositoryException("Data was not inserted");
            }
        }

        public bool Delete(Customer customer)
        {
            // TODO: 5. Delete the customer defined in the provided customer object from the database and return a value indicating the success/failure of the operation

            throw new NotImplementedException();
        }
    }
}
