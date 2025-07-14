CREATE TABLE [dbo].[Employee]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
	[Contract] NVARCHAR(32) NOT NULL, 
	[HireDate] DATE NOT NULL, 
	[ContractEnd] DATE,
	[User_Id] INT NOT NULL , 
	CONSTRAINT [FK_Employee_User_Id] FOREIGN KEY ([User_Id]) 
			REFERENCES [User]([Id])
)
