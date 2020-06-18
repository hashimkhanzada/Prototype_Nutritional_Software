CREATE PROCEDURE [dbo].[spCalorieCount_GetRecent_CalorieGoal]
	@UserId nvarchar(450)
AS
	SELECT TOP 1 CalorieGoal FROM CalorieCount 
	WHERE UserId = @UserId
	ORDER BY [Date] DESC
	