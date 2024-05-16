CREATE PROCEDURE [dbo].[ICESLawDis]

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
END
