CREATE PROCEDURE [dbo].[DEAD_add]
	@DEAD_Id nvarchar(50),
	@DEAD_Name nvarchar(50),
	@DEAD_Price nvarchar(50)
AS
begin
insert into [DEAD_TABLE]
(DEAD_Id,DEAD_Name,DEAD_Price)
values
(@DEAD_Id,@DEAD_Name,@DEAD_Price)



end