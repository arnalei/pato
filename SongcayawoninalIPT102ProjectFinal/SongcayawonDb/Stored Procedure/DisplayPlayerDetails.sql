CREATE PROCEDURE [dbo].[DisplayPlayerDetails]
	@PlayerId int

AS
BEGIN
    SELECT 
        [DPD].[PlayerId] AS PlayerId,[DPD].[PlayerName] AS PlayerName, [DPD].[PlayerRank] AS PlayerRank, [DPD].[PlayerClass] AS PlayerClass
    FROM 
        [dbo].[Players] AS DPD
    WHERE [DPD].[PlayerId] = @PlayerId;
END;
