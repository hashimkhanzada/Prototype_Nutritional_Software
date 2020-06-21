CREATE TABLE [dbo].[CustomRecipe]
(
	[RecipeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Calories] DECIMAL NOT NULL, 
    [FoodId] NVARCHAR(50) NULL, 
    [CustomFoodId] INT,
    [RecipeDescription] NVARCHAR(MAX) NULL, 
    [RecipeName] NVARCHAR(50) NOT NULL, 
    [ServingSize] DECIMAL NOT NULL, 
    [UserId] NVARCHAR(450) NOT NULL, 

    CONSTRAINT [FK_CustomRecipe_CustomFood] FOREIGN KEY ([CustomFoodId]) REFERENCES [CustomFood]([CustomFoodId]), 
    CONSTRAINT [FK_CustomRecipe_NzFoodFiles] FOREIGN KEY ([FoodId]) REFERENCES [NzFoodFiles]([FoodId]), 
    CONSTRAINT [FK_CustomRecipe_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
