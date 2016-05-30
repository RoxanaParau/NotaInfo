CREATE TABLE [dbo].[Users] (
    [UserID]         INT           IDENTITY (1, 1) NOT NULL,
    [LastName]       NVARCHAR (50) NOT NULL,
    [FirstName]      NVARCHAR (50) NOT NULL,
    [HireDate]       DATETIME      NULL,
    [EnrollmentDate] DATETIME      NULL,
    [Password]       NVARCHAR (50) NULL,
    [RoleId]         INT           NULL,
    [Username]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleID])
);

