CREATE PROCEDURE [dbo].[spUserFood_GetByUserId_ByDate]
	@Id nvarchar(450),
	@Date date
AS
begin
	set nocount on;

	select UserFoodId, UserId, FoodId, [Date], CustomFoodId, Quantity
	from [dbo].[UserFood]
	where UserId = @Id AND [Date]=@Date;
end