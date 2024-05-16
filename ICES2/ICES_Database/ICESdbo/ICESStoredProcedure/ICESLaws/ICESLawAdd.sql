CREATE PROCEDURE [dbo].[ICESLawAdd]
	@ICESLegislationNo nvarchar(50),
	@ICESBillPolicy nvarchar(50),
	@ICESName nvarchar(50),
	@ICESProposedby nvarchar(50),
	@ICESStatus nvarchar(50)
AS
BEGIN
INSERT INTO ICESLaws
(ICESLegislationNo,ICESBillPolicy,ICESName,ICESProposedby,ICESStatus)
VALUES
(@ICESLegislationNo,@ICESBillPolicy,@ICESName,@ICESProposedby,@ICESStatus)
END
