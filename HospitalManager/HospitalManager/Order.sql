CREATE TABLE [dbo].[Order]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[OrderDate] DATE NOT NULL, 
	[Status] NVARCHAR(32) NOT NULL DEFAULT 'Active',
	[Employee_Id] INT NOT NULL, 
	CONSTRAINT [FK_Order_Employee_Id] FOREIGN KEY ([Employee_Id])
		REFERENCES [Employee]([User_Id])
)
