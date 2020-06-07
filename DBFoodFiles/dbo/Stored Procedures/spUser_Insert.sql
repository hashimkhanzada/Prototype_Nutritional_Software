CREATE PROCEDURE [dbo].[spUser_Insert]
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

	insert into dbo.[User](UserName, Email, Height, [Weight], Age, FirstName, LastName)
	values (@UserName, @Email, @Height, @Weight, @Age, @FirstName, @LastName);

end