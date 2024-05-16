CREATE PROCEDURE [dbo].[DEAD_del]
	@DEAD_Id nvarchar(50)

AS
begin

delete
from [DEAD_TABLE]
where DEAD_Id=@DEAD_Id



end
