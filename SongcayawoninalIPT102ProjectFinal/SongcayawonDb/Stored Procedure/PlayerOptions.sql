CREATE PROCEDURE [dbo].[PlayerOptions]
	
	AS
BEGIN
    SELECT 
        [PO].[PlayerId] AS PlayerId, 
        [PO].[PlayerName] AS PlayerName
    FROM 
        [dbo].[Players] AS PO
END;
