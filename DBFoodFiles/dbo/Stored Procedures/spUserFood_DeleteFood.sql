CREATE PROCEDURE [dbo].[spUserFood_DeleteFood]
	@UserFoodId int
AS
begin

	set nocount on;

	delete
	from dbo.[UserFood]
	where UserFoodId = @UserFoodId;

end