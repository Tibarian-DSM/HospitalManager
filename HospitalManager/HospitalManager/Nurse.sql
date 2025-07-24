CREATE TABLE [dbo].[Nurse]
(
	[User_Id] INT NOT NULL PRIMARY KEY,
	[Grade] NVARCHAR(16) NOT NULL, 
	CONSTRAINT [FK_Nurse_Employee_Id] FOREIGN KEY ([User_Id])
			REFERENCES [Employee]([User_Id]) ON DELETE CASCADE
)
