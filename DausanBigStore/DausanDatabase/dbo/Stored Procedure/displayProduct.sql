CREATE PROCEDURE [dbo].[displayProduct]
	
AS
BEGIN
	Select [ProductCode] as ProductCode, [ProductName] as ProductName, [ProductPrice] as ProductPrice from [dbo].[Product]
END;
