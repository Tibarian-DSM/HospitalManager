CREATE TABLE [dbo].[Employee_Service]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
	[Employee_Id] INT NOT NULL, 
	[Service_Id] INT , 
	CONSTRAINT [FK_ES_Employee_ID] FOREIGN KEY ([Employee_Id])
				REFERENCES [Employee]([User_Id]) ON DELETE CASCADE, 
	CONSTRAINT [FK_ES_Service_ID] FOREIGN KEY ([Service_Id])
				REFERENCES [Service]([Id]) ON DELETE SET NULL, 
)
