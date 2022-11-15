CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RecipientFullName] NVARCHAR(100) NOT NULL, 
    [RecipientPhoneNumber] NCHAR(15) NULL, 
    [TotolSum] NUMERIC NOT NULL, 
    [DateTimeRequest] DATETIME2(0) NOT NULL
)
