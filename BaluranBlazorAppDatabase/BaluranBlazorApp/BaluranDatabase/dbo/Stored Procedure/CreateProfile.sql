CREATE PROCEDURE [dbo].[CreateProfile]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Email NVARCHAR(50)

AS
BEGIN
insert into [dbo].[Profile](FirstName, LastName, Email)
values (@FirstName, @LastName, @Email);

END;