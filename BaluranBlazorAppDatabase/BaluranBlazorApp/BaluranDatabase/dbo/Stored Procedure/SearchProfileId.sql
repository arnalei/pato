CREATE PROCEDURE [dbo].[SearchProfileId]
	@id int
AS
BEGIN
	SELECT * from [dbo].[Profile]
	where Id = @id
END
