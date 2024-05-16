CREATE PROCEDURE [dbo].[AJJK_sea]
	@AJJK_Name nvarchar(50)
AS
begin
select
AJJK_Id as AJJK_Id,
AJJK_Name as AJJK_Name,
AJJK_Subject as AJJK_Subject,
AJJK_Date as AJJK_Date,
AJJK_Description as AJJK_Description,
AJJK_Status as AJJK_Status,
AJJK_EDIT_ID as AJJJK_EDIT_ID

from AJJK_table
where
AJJK_Id like @AJJK_Name or
AJJK_Name like @AJJK_Name or
AJJK_Subject like @AJJK_Name or
AJJK_Date like @AJJK_Name or
AJJK_Description like @AJJK_Name or
AJJK_Status like @AJJK_Name

end