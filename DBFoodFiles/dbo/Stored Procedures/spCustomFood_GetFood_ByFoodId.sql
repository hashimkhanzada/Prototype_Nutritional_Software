CREATE PROCEDURE [dbo].[spCustomFood_GetFood_ByFoodId]
	@CustomFoodId int
AS
begin
	set nocount on;

	select CustomFoodId, ShortName, ServingSize, Energy, Carbohydrates, Protein, Fat, Sugar, Sodium, SaturatedFat, Fibre
	from [dbo].CustomFood
	where CustomFoodId = @CustomFoodId
end