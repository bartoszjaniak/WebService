CREATE TABLE [dbo].[UserAcces]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Login] VARCHAR(50) NULL, 
    [Password] VARCHAR(50) NULL, 
    CONSTRAINT [UserAccesToUser] FOREIGN KEY ([Id]) REFERENCES [User]([Id])
)

GO
