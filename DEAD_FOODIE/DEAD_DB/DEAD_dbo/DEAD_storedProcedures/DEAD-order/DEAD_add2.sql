CREATE PROCEDURE [dbo].[DEAD_add2]
	@DEAD_Id nvarchar(50),
	@DEAD_Name nvarchar(50),
	@DEAD_Price nvarchar(50)
AS
begin
insert into [DEAD_order]
(DEAD_Id,DEAD_Name,DEAD_Price)
values
(@DEAD_Id,@DEAD_Name,@DEAD_Price)



end