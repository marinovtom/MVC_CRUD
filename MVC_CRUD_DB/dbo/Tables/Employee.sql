CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [StartingDate] DATETIME NOT NULL, 
    [Salary] INT NOT NULL, 
    [VacationDays] TINYINT NOT NULL, 
    [ExperienceLevel] TINYINT NOT NULL
)
