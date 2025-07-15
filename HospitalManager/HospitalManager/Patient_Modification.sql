CREATE TABLE [dbo].[Patient_Modification]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[UpdateDate] DATE NOT NULL, 
	[Patient_Id] INT NOT NULL, 
	[Employee_Id] INT NOT NULL, 
	CONSTRAINT [FK_PM_Patient_Id] FOREIGN KEY ([Patient_Id])
		REFERENCES [Patient]([User_Id]),
	CONSTRAINT [FK_PM_Employee_Id] FOREIGN KEY ([Employee_Id])
		REFERENCES [Employee]([User_Id])
)
