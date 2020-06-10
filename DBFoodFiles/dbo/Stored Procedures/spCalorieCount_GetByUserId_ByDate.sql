CREATE PROCEDURE [dbo].[spCalorieCount_GetByUserId_ByDate]
	@Id nvarchar(450),
	@Date date
AS
begin
	set nocount on;

	select CountId, UserId, CalorieGoal, [Date], CaloriesConsumed, UserRecipeId, UserFoodId
	from [dbo].[CalorieCount]
	where UserId = @Id AND [Date]=@Date;
end