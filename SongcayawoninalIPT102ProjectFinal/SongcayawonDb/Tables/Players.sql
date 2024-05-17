CREATE TABLE [dbo].[Players]
(
	[PlayerId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [PlayerName] VARCHAR(50) NULL, 
    [PlayerRank] VARCHAR(50) NULL, 
    [PlayerClass] VARCHAR(50) NULL
)
