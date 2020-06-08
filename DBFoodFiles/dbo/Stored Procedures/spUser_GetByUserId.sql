CREATE PROCEDURE [dbo].[spUser_GetByUserId]
	@Id nvarchar(450)
AS
begin
	set nocount on;

	select Id, UserName, FirstName, LastName, Email, Height, [Weight], Age
	from [dbo].[User]
	where Id = @Id;
end
