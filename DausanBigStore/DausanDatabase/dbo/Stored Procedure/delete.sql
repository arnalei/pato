CREATE PROCEDURE [dbo].[delete]
	@ProductCode VARCHAR(50)
AS
	BEGIN
	DELETE FROM [dbo].[Product] WHERE [ProductCode] = @ProductCode
	END;
