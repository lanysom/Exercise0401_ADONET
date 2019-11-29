using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Configuration;
using System.Data.SqlClient;

namespace ClientManager.DAL.Tests
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _repos;
        private string _connectionString;

        [TestInitialize]
        public void Initialize()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = 
                    "SET IDENTITY_INSERT Customers ON; " +
                    "INSERT INTO Customers (Id, Firstname, Lastname, Address, Zip, City, Phone, Email) VALUES(1, 'Jens', 'Hansen', 'Hovedgaden 39', '9500', 'Hobro', '98765432', 'jh@iligemaasen.dk'); "+ 
                    "INSERT INTO Customers (Id, Firstname, Lastname, Address, Zip, City, Phone, Email) VALUES(2, 'John', 'Schmidt', 'Solitudevej 98', '9000', 'Aalborg', '87654321', 'akasut@paatorveti.dk'); "+
                    "INSERT INTO Customers (Id, Firstname, Lastname, Address, Zip, City, Phone, Email) VALUES(3, 'Sven', 'Svinsen', 'Ligustervænget 12', '9990', 'Skagen', '76543210', 'oink@triplex.dk'); ";
                cmd.ExecuteNonQuery();
            }

            _repos = new CustomerRepository(_connectionString);                           
        }

        [TestMethod]
        public void GetAllTest()
        { 
            var result = _repos.GetAll();

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetTest()
        {
            var result = _repos.Get(1);

            Assert.IsTrue(result.Id == 1);
            Assert.IsTrue(result.Firstname == "Jens");
            Assert.IsTrue(result.Zip == "9500");
        }

        [TestMethod]
        public void UpdateTest()
        {
            var customer = _repos.Get(1);
            customer.Address = "Paradisæblevej 111";
            customer.Zip = "9210";
            customer.City = "Aalborg SØ";

            var result = _repos.Update(customer);

            Assert.IsTrue(result.Id == 1);
            Assert.IsTrue(result.Address == "Paradisæblevej 111");

            var updatedCustomer = _repos.Get(1);

            Assert.IsTrue(updatedCustomer.Id == 1);
            Assert.IsTrue(updatedCustomer.Address == "Paradisæblevej 111");
        }

        [TestMethod]
        public void InsertTest()
        {
            var customer = new Customer
            {
                Firstname = "Anders",
                Lastname = "And",
                Address = "Paradisæblevej 111",
                Zip = "9999",
                City = "Andeby",
                Phone = "65432109",
                Email = "anders_and@andeby.dk"
            };

            var result = _repos.Insert(customer);

            Assert.IsTrue(result.Id == 4);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var customer = _repos.Get(1);

            var result = _repos.Delete(customer);

            Assert.IsTrue(result);

            var deletedCustomer = _repos.Get(1);

            Assert.IsNull(deletedCustomer);
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Customers; DBCC CHECKIDENT ('Customers', RESEED, 1);";
                cmd.ExecuteNonQuery();
            }

        }
    }
}