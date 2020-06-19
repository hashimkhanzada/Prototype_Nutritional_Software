CREATE PROCEDURE [dbo].[spCalorie_Count_Update_CalorieGoal]
		@UserId nvarchar(450),
		@Date Date,
		@CalorieGoal decimal(18,0)
AS
begin

	set nocount on;

	update dbo.CalorieCount
	set CalorieGoal = @CalorieGoal
	where UserId = @UserId AND [Date] = @Date;

end