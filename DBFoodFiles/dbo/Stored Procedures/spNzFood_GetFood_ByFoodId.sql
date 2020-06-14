CREATE PROCEDURE [dbo].[spNzFood_GetFood_ByFoodId]
	@FoodId nvarchar(50)
AS
begin
	set nocount on;

	select FoodId, ShortName, ServingSize, Energy, Carbohydrates, Protein, Fat, Sugar, Sodium, SaturatedFat, Fibre
	from [dbo].[NzFoodFiles]
	where FoodId = @FoodId
end