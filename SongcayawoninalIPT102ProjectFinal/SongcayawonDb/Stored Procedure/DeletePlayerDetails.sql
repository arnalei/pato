CREATE PROCEDURE [dbo].[DeletePlayerDetails]
	 @PlayerId int
AS
BEGIN
    DELETE FROM [dbo].[Players]
        WHERE [PlayerId] = @PlayerId;

        
END;
