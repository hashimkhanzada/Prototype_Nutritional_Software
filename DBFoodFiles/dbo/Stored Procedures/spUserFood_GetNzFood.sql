CREATE PROCEDURE [dbo].[spUserFood_GetNzFood]
	@Id nvarchar(450),
	@Date date
AS
begin
	set nocount on;

	select UserFoodId, UserId, FoodId, [Date], Quantity
	from [dbo].[UserFood]
	where UserId = @Id AND [Date]=@Date AND CustomFoodId is null
end