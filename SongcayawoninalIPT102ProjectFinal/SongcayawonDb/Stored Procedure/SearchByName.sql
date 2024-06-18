CREATE PROCEDURE [dbo].[SearchByName]
	 @PlayerName NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM [dbo].[Players]
    WHERE PlayerName LIKE '%' + @PlayerName + '%';
END;