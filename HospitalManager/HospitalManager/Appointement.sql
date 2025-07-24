CREATE TABLE [dbo].[Appointement]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
	[Appointement_Date] DATE NOT NULL, 
	[Subject] NVARCHAR(50) NOT NULL, 	
	[Medic_Id] INT ,
	[Patient_Id] INT, 
	CONSTRAINT [PK_Appoint_Medic_Id] FOREIGN KEY ([Medic_Id])
		REFERENCES [Medic]([User_Id]) ON DELETE SET NULL ,
	CONSTRAINT [PK_Appoint_Patient_Id] FOREIGN KEY ([Patient_Id])
		REFERENCES [Patient]([User_Id]) ON DELETE SET NULL
)
