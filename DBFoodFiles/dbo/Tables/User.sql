CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(450) NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(256) NOT NULL, 
    [Email] NVARCHAR(256) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
    [Height] DECIMAL NOT NULL, 
    [Weight] DECIMAL NOT NULL,
    [Age] INT NOT NULL, 
    [Gender] NVARCHAR(10) NOT NULL, 
    [ActivityLevel] NVARCHAR(50) NOT NULL, 
    [MedicalConditions] NVARCHAR(MAX) NULL
)
