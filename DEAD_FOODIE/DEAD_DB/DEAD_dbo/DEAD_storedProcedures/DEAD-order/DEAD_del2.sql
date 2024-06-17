CREATE PROCEDURE [dbo].[DEAD_del2]
	@DEAD_duplicate nvarchar(50)

AS
begin

delete
from [DEAD_order]
where DEAD_duplicate=@DEAD_duplicate



end
