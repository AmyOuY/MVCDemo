CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [StudentId] INT NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL
)
