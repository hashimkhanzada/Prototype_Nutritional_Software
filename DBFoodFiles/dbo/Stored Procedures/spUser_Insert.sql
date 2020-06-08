CREATE PROCEDURE [dbo].[spUser_Insert]
	@Id nvarchar(450),
	@UserName nvarchar(256),
	@Email nvarchar(256),
	@Height int,
	@Weight int,
	@Age int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin

	set nocount on;

	insert into dbo.[User](Id, UserName, Email, Height, [Weight], Age, FirstName, LastName)
	values (@Id, @UserName, @Email, @Height, @Weight, @Age, @FirstName, @LastName);

end