CREATE TABLE [dbo].[DEAD_order]
(
	[DEAD_Id] NVARCHAR(50) NOT NULL , 
    [DEAD_Name] NVARCHAR(50) NOT NULL, 
    [DEAD_Price] MONEY NOT NULL, 
    [DEAD_duplicate]  INT identity
    PRIMARY KEY ([DEAD_duplicate])
)
