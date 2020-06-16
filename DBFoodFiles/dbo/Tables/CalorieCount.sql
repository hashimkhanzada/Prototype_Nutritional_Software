CREATE TABLE [dbo].[CalorieCount]
(
	[CountId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(450) NOT NULL, 
    [CalorieGoal] DECIMAL NOT NULL, 
    [Date] DATE NOT NULL, 
    [CaloriesConsumed] DECIMAL NULL, 
    [UserRecipeId] INT NULL, 
    [UserFoodId] INT NULL, 
    CONSTRAINT [FK_UserId_CalorieCount_User] FOREIGN KEY (UserId) REFERENCES [User](Id), 
    CONSTRAINT [FK_UserRecipeId_CalorieCount_UserRecipe] FOREIGN KEY ([UserRecipeId]) REFERENCES [UserRecipe]([UserRecipeId]), 
    CONSTRAINT [FK_UserFoodId_CalorieCount_UserFood] FOREIGN KEY ([UserFoodId]) REFERENCES [UserFood]([UserFoodId])

)
