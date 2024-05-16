CREATE PROCEDURE [dbo].[AJJK_add]
	@AJJK_Id nvarchar(50),
	@AJJK_Name nvarchar(50),
	@AJJK_Subject nvarchar(50),
	@AJJK_Date nvarchar(50),
	@AJJK_Description nvarchar(50),
	@AJJK_Status nvarchar(50)

AS
begin
insert into AJJK_table
(AJJK_Id,AJJK_Name,AJJK_Subject,AJJK_Date,AJJK_Description,AJJK_Status)
values
(@AJJK_Id,@AJJK_Name,@AJJK_Subject,@AJJK_Date,@AJJK_Description,@AJJK_Status)

end
