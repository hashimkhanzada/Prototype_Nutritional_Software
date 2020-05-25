CREATE TABLE [dbo].[CustomRecipe]
(
	[RecipeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Calories] INT NOT NULL, 
    [FoodId] INT NOT NULL, 
    [RecipeDescription] NVARCHAR(256) NOT NULL, 
    [RecipeName] NVARCHAR(50) NOT NULL, 
    [ServingSize] NVARCHAR(50) NOT NULL, 
    [UserId] INT NOT NULL
)
