CREATE TABLE [dbo].[NzFoodFiles]
(
	[FoodId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ShortName] NVARCHAR(256) NOT NULL, 
    [ServingSize] NUMERIC NOT NULL, 
    [Energy] NUMERIC NOT NULL, 
    [Carbohydrates] NUMERIC NOT NULL, 
    [Protein] NUMERIC NOT NULL, 
    [Fat] NUMERIC NOT NULL, 
    [Sugar] NUMERIC NOT NULL, 
    [Sodium] NUMERIC NOT NULL
)
