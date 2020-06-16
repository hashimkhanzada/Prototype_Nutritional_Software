CREATE TABLE [dbo].[NzFoodFiles]
(
	[FoodId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [ShortName] NVARCHAR(256) NOT NULL, 
    [ServingSize] DECIMAL NOT NULL, 
    [Energy] DECIMAL NOT NULL, 
    [Carbohydrates] DECIMAL NOT NULL, 
    [Protein] DECIMAL NOT NULL, 
    [Fat] DECIMAL NOT NULL, 
    [Sugar] DECIMAL NOT NULL, 
    [Sodium] DECIMAL NOT NULL, 
    [SaturatedFat] DECIMAL NOT NULL, 
    [Fibre] DECIMAL NOT NULL
)
