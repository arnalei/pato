CREATE PROCEDURE [dbo].[DEAD_upd]
	@DEAD_Id nvarchar(50),
	@DEAD_Name nvarchar(50),
	@DEAD_Price nvarchar(50)
AS
begin
update DEAD_TABLE
set
DEAD_Id = isnull(@DEAD_Id,DEAD_Id),
DEAD_Name = isnull(@DEAD_Name,DEAD_Name),
DEAD_Price = isnull(@DEAD_Price,DEAD_Price)
end
