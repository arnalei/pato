CREATE PROCEDURE [dbo].[DeleteProfile]
	@Id int
	
AS
BEGIN
	delete from [dbo].[Profile]
	where [Id] = @Id;

	END;
