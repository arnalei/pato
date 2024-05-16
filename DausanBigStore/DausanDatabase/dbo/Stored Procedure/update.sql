CREATE PROCEDURE [dbo].[update]
	@ProductCode VARCHAR(50),
	@ProductName VARCHAR(50),
	@ProductPrice VARCHAR(50)
AS
	BEGIN
	Update [dbo].[Product] set [ProductName] = @ProductName, [ProductPrice] = @ProductPrice Where [ProductCode] = @ProductCode
	END;