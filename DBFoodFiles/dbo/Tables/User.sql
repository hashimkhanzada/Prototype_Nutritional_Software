CREATE TABLE [dbo].[User]
(
	[Id] NVARCHAR(450) NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(256) NOT NULL, 
    [Email] NVARCHAR(256) NOT NULL, 
    [Height] INT NOT NULL, 
    [Weight] INT NOT NULL, 
    [Age] INT NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL 
)
