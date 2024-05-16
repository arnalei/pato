CREATE PROCEDURE [dbo].[AJJK_upd]
	@AJJK_Id nvarchar(50),
	@AJJK_Name nvarchar(50),
	@AJJK_Subject nvarchar(50),
	@AJJK_Date nvarchar(50),
	@AJJK_Description nvarchar(50),
	@AJJK_Status nvarchar(50),
	@AJJK_EDIT_ID int
AS
begin
update AJJK_table
set
AJJK_Id= isnull(@AJJK_Id,AJJK_Id),
AJJK_Name= isnull(@AJJK_Name,AJJK_Name),
AJJK_Subject= isnull(@AJJK_Subject,AJJK_Subject),
AJJK_Date= isnull(@AJJK_Date,AJJK_Date),
AJJK_Description= isnull(@AJJK_Description,AJJK_Description),
AJJK_Status= isnull(@AJJK_Status,AJJK_Status)
where AJJK_EDIT_ID = @AJJK_EDIT_ID




end