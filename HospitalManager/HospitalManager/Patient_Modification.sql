CREATE TABLE [dbo].[Patient_Modification]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[UpdateDate] DATE NOT NULL, 
	[Patient_Id] INT, 
	[Employee_Id] INT, 
	CONSTRAINT [FK_PM_Patient_Id] FOREIGN KEY ([Patient_Id])
		REFERENCES [Patient]([User_id]) ON DELETE SET NULL,
	CONSTRAINT [FK_PM_Employee_Id] FOREIGN KEY ([Employee_Id])
		REFERENCES [Employee]([User_Id]) ON DELETE SET NULL
)
