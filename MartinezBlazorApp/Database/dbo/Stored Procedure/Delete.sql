CREATE PROCEDURE [dbo].[Delete]
	@CharacterId int
AS
BEGIN
	DELETE FROM [dbo].[Character]
	WHERE [CharacterId] = @CharacterId;

END;