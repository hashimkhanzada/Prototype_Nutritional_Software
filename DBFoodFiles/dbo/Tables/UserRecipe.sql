CREATE TABLE [dbo].[UserRecipe]
(
	[UserRecipeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(450) NOT NULL, 
    [RecipeId] INT NOT NULL, 
    CONSTRAINT [FK_UserRecipe_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserRecipe_CustomRecipe] FOREIGN KEY ([RecipeId]) REFERENCES [CustomRecipe]([RecipeId])
)
