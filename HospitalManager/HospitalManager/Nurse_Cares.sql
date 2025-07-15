CREATE TABLE [dbo].[Nurse_Cares]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Nurse_id] INT NOT NULL,
	[Cares_id] INT NOT NULL,
	CONSTRAINT [PK_NC_Nurse_Id] FOREIGN KEY ([Nurse_id])
		REFERENCES [Nurse]([User_Id]),
	CONSTRAINT [PK_NC_Cares_id] FOREIGN KEY ([Cares_id])
		REFERENCES [Cares]([Id])
)
