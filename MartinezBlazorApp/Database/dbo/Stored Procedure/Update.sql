CREATE PROCEDURE [dbo].[Update]
	@CharacterId INT,
	@CharacterName NVARCHAR(50),
	@Gender NVARCHAR(50),
	@Age INT,
	@Description NVARCHAR(MAX)
AS
BEGIN
	UPDATE [dbo].[Character]
	SET
		[CharacterName] = @CharacterName,
		[Age] = @Age,
		[Gender] = @Gender,
		[Description] = @Description

	WHERE [CharacterId] = @CharacterId

END;
