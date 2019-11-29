using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Configuration;

namespace ClientManager.DAL.Tests
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        private string _connectionString;

        [TestInitialize]
        public void Initialize()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var repos = new CustomerRepository(_connectionString);
                       
            var result = repos.GetAll();
        }

        [TestMethod()]
        public void GetTest()
        {
            var repos = new CustomerRepository(_connectionString);

            var result = repos.Get(1);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var repos = new CustomerRepository(_connectionString);

            var result = repos.Update(null);
        }

        [TestMethod()]
        public void InsertTest()
        {
            var repos = new CustomerRepository(_connectionString);

            var result = repos.Insert(null);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var repos = new CustomerRepository(_connectionString);

            var result = repos.Delete(null);
        }
    }
}