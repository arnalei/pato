CREATE PROCEDURE [dbo].[UpdatePlayerDetails]
	@PlayerId INT,
    @PlayerName NVARCHAR(MAX),
    @PlayerRank NVARCHAR(MAX),
    @PlayerClass NVARCHAR(MAX)
   
AS
BEGIN
    UPDATE [dbo].[Players]
    SET
        [PlayerName] = @PlayerName,
        [PlayerRank] = @PlayerRank,
        [PlayerClass] = @PlayerClass
      

    WHERE [PlayerId] = @PlayerId;
END;
