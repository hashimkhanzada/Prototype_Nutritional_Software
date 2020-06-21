CREATE PROCEDURE [dbo].[spCustomFood_Insert]
	@ShortName nvarchar(256),
	@ServingSize decimal(18,0),
	@Energy decimal(18,0),
	@Carbohydrates decimal(18,0),
	@Protein decimal(18,0),
	@Fat decimal(18,0),
	@Sugar decimal(18,0),
	@Sodium decimal(18,0),
	@SaturatedFat decimal(18,0),
	@Fibre decimal(18,0)
AS
begin

	set nocount on;

	insert into dbo.[CustomFood] (ShortName, ServingSize, Energy, Carbohydrates, Protein, Fat, Sugar, Sodium, SaturatedFat, Fibre)
	values (@ShortName, @ServingSize, @Energy, @Carbohydrates, @Protein, @Fat, @Sugar, @Sodium, @SaturatedFat, @Fibre);

end