CREATE TABLE [dbo].[Medic]
(
	[User_Id] INT NOT NULL PRIMARY KEY,
	[Inami] VARBINARY(32) NOT NULL,
	[Specialty] NVARCHAR(50) NOT NULL,
	[Is_Subsized] BIT  NOT NULL,
	CONSTRAINT [FK_Medic_Employee_Id] FOREIGN KEY ([User_Id])
			REFERENCES [Employee]([User_Id]) ON DELETE CASCADE
)
