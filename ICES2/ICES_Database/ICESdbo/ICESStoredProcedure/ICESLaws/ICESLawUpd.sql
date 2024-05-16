CREATE PROCEDURE [dbo].[ICESLawUpd]
	@ICESLegislationNo nvarchar(50),
	@ICESBillPolicy nvarchar(50),
	@ICESName nvarchar(50),
	@ICESProposedby nvarchar(50),
	@ICESStatus nvarchar(50),
	@ICES int
AS
BEGIN
UPDATE ICESLaws
SET
ICESLegislationNo=COALESCE(@ICESLegislationNo,ICESLegislationNo),
ICESBillPolicy=COALESCE(@ICESBillPolicy,ICESBillPolicy),
ICESName=COALESCE(@ICESName,ICESName),
ICESProposedby=COALESCE(@ICESProposedby,ICESProposedby),
ICESStatus=COALESCE(@ICESStatus,ICESStatus)
WHERE ICES = @ICES


END
