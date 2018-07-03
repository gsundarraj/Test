CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserName] VARCHAR(MAX) NULL, 
    [Gender] TINYINT NULL, 
    [Dob] DATETIME2 NULL, 
    [Qualification] VARCHAR(50) NULL, 
    [Experience] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    [Mobile] VARCHAR(20) NULL, 
    [Address] VARCHAR(MAX) NULL, 
    [Reference] VARCHAR(50) NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GetDate(), 
    [RecordStatus] TINYINT NOT NULL DEFAULT 0, 
    [DeviceId] VARCHAR(MAX) NULL, 
    [IPAddress] VARCHAR(50) NULL, 
    [IsVerified] BIT NOT NULL DEFAULT 0, 
    [ActivatedDate] DATETIME2 NULL, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL
)

GO

CREATE UNIQUE INDEX [IX_Users_Mobile] ON [dbo].[Users] ([Mobile])