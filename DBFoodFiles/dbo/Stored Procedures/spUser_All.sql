CREATE PROCEDURE [dbo].[spUser_All]
AS
begin

	set nocount on;

	select [UserId], [UserName], [Email], [Height], [Weight], [Age], [FirstName], [LastName]
	from dbo.[User];

end