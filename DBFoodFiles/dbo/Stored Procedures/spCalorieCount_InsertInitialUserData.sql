CREATE PROCEDURE [dbo].[spCalorieCount_InsertInitialUserData]
	@UserId nvarchar(450),
	@CalorieGoal decimal(18,0),
	@Date date
AS
begin

	set nocount on;

	insert into dbo.[CalorieCount](UserId, CalorieGoal, [Date])
	values (@UserId, @CalorieGoal, @Date);

end