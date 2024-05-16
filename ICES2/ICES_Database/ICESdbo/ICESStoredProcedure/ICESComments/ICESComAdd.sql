CREATE PROCEDURE [dbo].[ICESComAdd]
	@ICESIDNO nvarchar(50),
	@ICESComment nvarchar(50),
	@ICESName nvarchar(50),
	@ICESInstitutionalEmail nvarchar(50)
AS
BEGIN
INSERT INTO ICESComments
(ICESIDNO,ICESName,ICESInstitutionalEmail,ICESComment)
VALUES
(@ICESIDNO,@ICESName,@ICESInstitutionalEmail,@ICESComment)
END