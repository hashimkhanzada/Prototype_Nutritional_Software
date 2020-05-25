CREATE TABLE [dbo].[CustomFood]
(
	[FoodId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Calories] INT NOT NULL, 
    [ServingSize] NVARCHAR(50) NOT NULL, 
    [UserId] INT NOT NULL
)
