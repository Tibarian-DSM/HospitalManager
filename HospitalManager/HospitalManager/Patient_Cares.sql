CREATE TABLE [dbo].[Patient_Cares]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[Patient_id] INT NOT NULL,
	[Cares_id] INT,
	CONSTRAINT [PK_PC_Patient_Id] FOREIGN KEY ([Patient_id])
		REFERENCES [Patient]([User_Id]) ON DELETE CASCADE ,
	CONSTRAINT [PK_PC_Cares_id] FOREIGN KEY ([Cares_id])
		REFERENCES [Cares]([Id]) ON DELETE SET NULL
)
