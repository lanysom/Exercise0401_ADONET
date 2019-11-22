# Exercise0401 ADO.NET
Implementation of basic CRUD operations in a Data Access Layer

You are working as a software developer. Your team is developing an application that can manage a customer database and your task is to implement the operations in the data access layer (DAL). 

You find the application code in this repository so you will need to clone or download it by clicking the *Clone or download* button.

There are five methods that you should implement:
1. **GetAll()**   
   This method must return a list of all the customers in the database
1. **Get(int id)**   
   This method must return a customer based on an id provided as a parameter
1. **Insert(Customer customer)**   
   This method must insert a new row in the Customer table with data from a Customer object provided as a parameter. The method must return the object with the generated data from the database.
1. **Update(Customer customer)**
   This method must update a row in the Customer table with data from a Customer object provided as a parameter. The method must return the updated object.
1. **Delete(Customer customer)**   
   This method must delete a row in the Customer table based on data from a Customer object provided as a parameter. The method must return a value indicating if the operation went well or not.

**HINT!** The methods that you must implement are marked with a *TODO* comment in the code to make it easier for you to find using the task list in Visual Studio
