CREATE PROCEDURE [dbo].[spUserFood_InsertFoodId]
	@FoodId nvarchar(50),
	@UserId nvarchar(450),
	@Date date,
	@Quantity decimal(18,3)

AS
begin

	set nocount on;

	insert into dbo.[UserFood]([FoodId], [UserId], [Date], [Quantity])
	values (@FoodId, @UserId, @Date, @Quantity/100);

end