CREATE TABLE [dbo].[Appointement]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
	[Appointement_Date] DATE NOT NULL, 
	[Subject] NVARCHAR(50) NOT NULL, 	
	[Medic_Id] INT NOT NULL,
	[Patient_Id] INT NOT NULL, 
	CONSTRAINT [PK_Appoint_Medic_Id] FOREIGN KEY ([Medic_Id])
		REFERENCES [Medic]([Id]),
	CONSTRAINT [PK_Appoint_Patient_Id] FOREIGN KEY ([Patient_Id])
		REFERENCES [Patient]([Id])
)
