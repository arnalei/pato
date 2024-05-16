CREATE TABLE [dbo].[Profile]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL,  
    [Email] NVARCHAR(50) NULL
)
