CREATE PROCEDURE [dbo].[ICESLawSea]
	@ICESSearch nvarchar(50)
AS
BEGIN
SELECT
ICES AS ICES,
ICESLegislationNo AS ICESLegislationNo,
ICESBillPolicy AS ICESBillPolicy,
ICESName AS ICESName,
ICESProposedby AS ICESProposedby,
ICESStatus AS ICESStatus
FROM ICESLaws


WHERE
ICESLegislationNo LIKE @ICESSearch OR
ICESBillPolicy LIKE @ICESSearch OR
ICESName LIKE @ICESSearch OR
ICESProposedby LIKE @ICESSearch OR
ICESStatus LIKE @ICESSearch 

END
