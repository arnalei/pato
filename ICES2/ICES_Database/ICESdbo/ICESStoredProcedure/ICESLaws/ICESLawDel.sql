﻿CREATE PROCEDURE [dbo].[ICESLawDel]
	@ICES int
AS
BEGIN
DELETE FROM ICESLaws
WHERE ICES = @ICES
END