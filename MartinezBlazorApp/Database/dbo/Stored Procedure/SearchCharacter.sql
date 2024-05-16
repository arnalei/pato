CREATE PROCEDURE [dbo].[SearchCharacter]
	@CharacterId INT
AS
	BEGIN

	SELECT * FROM [dbo].[Character]
	WHERE CharacterId = @CharacterId

	END;