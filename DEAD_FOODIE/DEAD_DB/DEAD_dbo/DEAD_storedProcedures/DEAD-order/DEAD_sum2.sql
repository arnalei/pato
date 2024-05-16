CREATE PROCEDURE [dbo].[DEAD_sum2]

AS
begin

select 

sum(DEAD_Price) as DEAD_Price
from [DEAD_order]



end
