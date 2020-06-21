CREATE PROCEDURE [dbo].[spUserFood_InsertCustomFood]
	@CustomFoodId int,
	@UserId nvarchar(450),
	@Date date,
	@Quantity decimal(18,0)

AS
begin

	set nocount on;

	insert into dbo.[UserFood](CustomFoodId, [UserId], [Date], [Quantity])
	values (@CustomFoodId, @UserId, @Date, @Quantity);

end