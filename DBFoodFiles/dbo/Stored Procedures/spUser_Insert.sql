CREATE PROCEDURE [dbo].[spUser_Insert]
	@Id nvarchar(450),
	@UserName nvarchar(256),
	@Email nvarchar(256),
	@Height int,
	@Weight int,
	@Age int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Gender nvarchar(10),
	@ActivityLevel nvarchar(50),
	@MedicalConditions nvarchar(max)
AS
begin

	set nocount on;

	insert into dbo.[User](Id, UserName, Email, Height, [Weight], Age, FirstName, LastName, Gender, ActivityLevel, MedicalConditions)
	values (@Id, @UserName, @Email, @Height, @Weight, @Age, @FirstName, @LastName, @Gender, @ActivityLevel, @MedicalConditions);

end