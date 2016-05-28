CREATE TABLE [dbo].[StudyYears] (
    [Id]           INT           NOT NULL,
    [YearOfStudy]  NVARCHAR (50) NULL,
    [DepartmentId] INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StudyYears_Departments] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentID])
);

