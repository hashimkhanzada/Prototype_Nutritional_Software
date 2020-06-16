CREATE TABLE [dbo].[CustomFood]
(
	[CustomFoodId] INT NOT NULL PRIMARY KEY IDENTITY, 
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
