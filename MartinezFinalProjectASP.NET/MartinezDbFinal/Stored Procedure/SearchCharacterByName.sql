CREATE PROCEDURE [dbo].[SearchCharacterByName]
	@CharacterName NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM [dbo].[Character]
    WHERE CharacterName LIKE '%' + @CharacterName + '%';
END;
