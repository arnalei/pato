CREATE TABLE [dbo].[ICESLaws]
(
    [ICES] INT NOT NULL IDENTITY, 
    [ICESLegislationNo] NVARCHAR(50) NOT NULL, 
    [ICESBillPolicy] NVARCHAR(50) NULL, 
    [ICESName] NVARCHAR(50) NULL, 
    [ICESProposedby] NVARCHAR(50) NULL, 
    [ICESStatus] NVARCHAR(50) NULL, 
    PRIMARY KEY ([ICESLegislationNo])
)
