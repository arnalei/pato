CREATE PROCEDURE [dbo].[findProductById]
	@ProductCode VARCHAR(50)
AS
BEGIN
	Select [ProductCode] as ProductCode, [ProductName] as ProductName, [ProductPrice] as ProductPrice from [dbo].[Product] where [ProductCode] = @ProductCode
	END;
