CREATE PROCEDURE [dbo].[spCustomFood_GetAll]
	AS
begin

	set nocount on;

	select CustomFoodId, ShortName, ServingSize, Energy, Carbohydrates, Protein, Fat, Sugar, Sodium, SaturatedFat, Fibre
	from dbo.[CustomFood];

end
