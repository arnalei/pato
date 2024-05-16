CREATE PROCEDURE [dbo].[createProduct]
	@ProductCode VARCHAR(50),
	@ProductName VARCHAR(50),
	@ProductPrice VARCHAR(50)
AS
	BEGIN
	INSERT INTO [dbo].[Product](ProductCode, ProductName, ProductPrice) VALUES(@ProductCode ,@ProductName ,@ProductPrice);
	END;