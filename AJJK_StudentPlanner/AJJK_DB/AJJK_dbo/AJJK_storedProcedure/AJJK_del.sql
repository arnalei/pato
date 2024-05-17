CREATE PROCEDURE [dbo].[AJJK_del]
	@AJJK_Id nvarchar(50)
AS
begin
delete from AJJK_table
where AJJK_Id=@AJJK_Id 

end
