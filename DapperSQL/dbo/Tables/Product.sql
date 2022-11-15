CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [CountP] INT NULL, 
    [Price] DECIMAL NULL,
    [DateTimeUpdate] DATETIME2(0) NOT NULL
)
