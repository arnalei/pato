CREATE PROCEDURE [dbo].[AJJK_dis]
	
AS
begin
select
AJJK_Id as AJJK_Id,
AJJK_Name as AJJK_Name,
AJJK_Subject as AJJK_Subject,
AJJK_Date as AJJK_Date,
AJJK_Description as AJJK_Description,
AJJK_Status as AJJK_Status,
AJJK_EDIT_ID as AJJK_EDIT_ID

from AJJK_table


end
