CREATE TABLE [dbo].[Employee]
(
	[User_Id] INT  NOT NULL PRIMARY KEY, 
	[Contract] NVARCHAR(32) NOT NULL, 
	[HireDate] DATE NOT NULL, 
	[ContractEnd] DATE, 
	CONSTRAINT [FK_Employee_User_Id] FOREIGN KEY ([User_Id]) 
			REFERENCES [User]([Id])ON DELETE CASCADE
)
