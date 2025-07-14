CREATE TABLE [dbo].[Nurse]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Grade] NVARCHAR(16) NOT NULL, 
	[Employee_Id] INT NOT NULL,
	CONSTRAINT [FK_Nurse_Employee_Id] FOREIGN KEY ([Employee_Id])
			REFERENCES [Employee]([Id])
)
