CREATE PROCEDURE [dbo].[DEAD_upd]
	@DEAD_Id nvarchar(50),
	@DEAD_Name nvarchar(50),
	@DEAD_Price nvarchar(50)
AS
begin
update DEAD_TABLE
set
DEAD_Name = @DEAD_Name,
DEAD_Price = @DEAD_Price
WHERE 
DEAD_Id = @DEAD_Id;
end
