CREATE TABLE [dbo].[UserFood]
(
	[UserFoodId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] NVARCHAR(450) NOT NULL, 
    [FoodId] NVARCHAR(50) NULL, 
    [CustomFoodId] INT NULL, 
    [Date] DATE NOT NULL, 
    [Quantity] DECIMAL NULL, 
    CONSTRAINT [FK_UserFood_NzFoodFiles] FOREIGN KEY ([FoodId]) REFERENCES [NzFoodFiles]([FoodId]), 
    CONSTRAINT [FK_UserFood_CustomFood] FOREIGN KEY ([CustomFoodId]) REFERENCES [CustomFood]([CustomFoodId]), 
    CONSTRAINT [FK_UserFood_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
