CREATE PROCEDURE [dbo].[DEAD_sea]
	@DEAD_Name nvarchar(50)
	
AS
begin

select 
DEAD_Id as DEAD_Id,
DEAD_Name as DEAD_Name,
DEAD_Price as DEAD_Price
from [DEAD_TABLE]
where
DEAD_Id like @DEAD_Name or
DEAD_Name like @DEAD_Name or
DEAD_Price like @DEAD_Name


end
