CREATE PROCEDURE [dbo].[spUser_GetByUserId]
	@Id nvarchar(128)
AS
begin
	set nocount on;

	select UserId, UserName, FirstName, LastName, Email, Height, [Weight], Age
	from [dbo].[User]
	where UserId = @Id;
end
