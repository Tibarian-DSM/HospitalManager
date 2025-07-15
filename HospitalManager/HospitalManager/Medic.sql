CREATE TABLE [dbo].[Medic]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Inami] VARBINARY(32) NOT NULL,
	[Specialty] NVARCHAR(50) NOT NULL,
	[Is_Subsized] BIT  NOT NULL,
	[Employee_Id] INT NOT NULL, 
	CONSTRAINT [FK_Medic_Employee_Id] FOREIGN KEY ([Employee_Id])
			REFERENCES [Employee]([User_id])
)
