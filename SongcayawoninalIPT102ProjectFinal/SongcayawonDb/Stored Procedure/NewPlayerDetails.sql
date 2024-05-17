CREATE PROCEDURE [dbo].[NewPlayerDetails]
	@PlayerName NVARCHAR(50),
    @PlayerRank NVARCHAR(50),
    @PlayerClass NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;


    INSERT INTO Players (PlayerName, PlayerRank, PlayerClass)
    VALUES (@PlayerName, @PlayerRank, @PlayerClass);

END
