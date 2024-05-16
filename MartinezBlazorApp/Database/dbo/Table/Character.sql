CREATE TABLE [dbo].[Character]
(
	[CharacterId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [CharacterName] NVARCHAR(50) NULL, 
    [Gender] NVARCHAR(50) NULL, 
    [Age] INT NULL, 
    [Description] NVARCHAR(MAX) NULL
)
