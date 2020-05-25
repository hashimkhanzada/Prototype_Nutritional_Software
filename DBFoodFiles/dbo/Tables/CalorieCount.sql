CREATE TABLE [dbo].[CalorieCount]
(
	[CountId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [CalorieGoal] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [CaloriesConsumed] INT NOT NULL, 
    [RecipeId] INT NULL, 
    [FoodId] INT NULL
)
