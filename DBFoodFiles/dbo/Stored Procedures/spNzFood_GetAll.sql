CREATE PROCEDURE [dbo].[spNzFood_GetAll]
AS
begin

	set nocount on;

	select FoodId, ShortName, ServingSize, Energy, Carbohydrates, Protein, Fat, Sugar, Sodium, SaturatedFat, Fibre
	from dbo.[NzFoodFiles];

end