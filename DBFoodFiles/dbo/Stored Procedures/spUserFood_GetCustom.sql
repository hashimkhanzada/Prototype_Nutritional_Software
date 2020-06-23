CREATE PROCEDURE [dbo].[spUserFood_GetCustom]
	@Id nvarchar(450),
	@Date date
AS
begin
	set nocount on;

	select UserFoodId, UserId, CustomFoodId, [Date], Quantity
	from [dbo].[UserFood]
	where UserId = @Id AND [Date]=@Date AND FoodId is null
end