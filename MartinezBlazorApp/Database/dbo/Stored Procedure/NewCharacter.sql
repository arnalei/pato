CREATE PROCEDURE [dbo].[NewCharacter]
	@CharacterName NVARCHAR(50),
	@Gender NVARCHAR(50),
	@Age INT,
	@Description NVARCHAR(MAX)
AS
BEGIN

INSERT INTO [dbo].[Character](CharacterName, Gender, Age, Description)
VALUES (@CharacterName, @Gender, @Age, @Description);

END;
