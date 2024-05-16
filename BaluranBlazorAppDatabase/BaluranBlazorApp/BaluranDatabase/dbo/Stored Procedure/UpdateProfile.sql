CREATE PROCEDURE [dbo].[UpdateProfile]
	@Id int,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Email NVARCHAR(50)

AS
BEGIN
	UPDATE [dbo].[Profile]
set
	[FirstName] = @FirstName,
	[LastName] = @LastName,
	[Email] = @Email
	where [Id] = @Id;

END;