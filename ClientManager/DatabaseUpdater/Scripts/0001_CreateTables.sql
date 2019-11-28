CREATE TABLE Customers(
	[Id] int identity(1,1) primary key,
	[Firstname] nvarchar(50) not null,
	[Lastname] nvarchar(50) not null, 
	[Address] nvarchar(50) not null,
	[Zip] nvarchar(4) not null,
	[City] nvarchar(50) not null, 
	[Phone] nvarchar(11) not null,
	[Email] nvarchar(50) not null
)