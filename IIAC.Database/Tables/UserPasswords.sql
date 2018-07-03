CREATE TABLE [dbo].[UserPasswords]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [PasswordHash] VARCHAR(MAX) NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GetDate(), 
    [RecordStatus] TINYINT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_UserPasswords_Users] FOREIGN KEY ([userId]) REFERENCES [Users]([Id])
)
