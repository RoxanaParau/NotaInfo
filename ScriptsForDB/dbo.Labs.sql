CREATE TABLE [dbo].[Labs] (
    [Id]          INT            NOT NULL,
    [Name]        NVARCHAR (500) NULL,
    [StudyYearId] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Labs_StudyYears] FOREIGN KEY ([StudyYearId]) REFERENCES [dbo].[StudyYears] ([Id])
);

