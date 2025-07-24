CREATE TABLE [dbo].[Prescription]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY,
	[DatePrescribed] DATE NOT NULL, 
	[ExpirationDate] DATE NOT NULL,
	[IsActive] BIT NOT NULL, 
	[Medic_Id] INT ,
	[Patient_Id] INT NOT NULL, 
	CONSTRAINT [PK_Presc_Medic_Id] FOREIGN KEY ([Medic_Id])
		REFERENCES [Medic]([User_Id]) ON DELETE SET NULL ,
	CONSTRAINT [PK_Presc_Patient_Id] FOREIGN KEY ([Patient_Id])
		REFERENCES [Patient]([User_Id]) ON DELETE CASCADE

)
