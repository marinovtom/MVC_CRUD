CREATE TABLE [dbo].[Office]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Country] NVARCHAR(50) NULL, 
    [City] NVARCHAR(50) NULL, 
    [Street] NVARCHAR(50) NULL, 
    [StreetNumber] TINYINT NULL, 
    [isHQ] BIT NULL, 
    [Company] INT NULL FOREIGN KEY REFERENCES Company(Id)
)
