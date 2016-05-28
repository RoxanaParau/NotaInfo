CREATE TABLE [dbo].[ProfessorPerLab] (
    [Id]          INT            NOT NULL,
    [ProfessorId] INT            NULL,
    [LabId]       INT            NULL,
    [Formula]     NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProfessorPerLab_Professor] FOREIGN KEY ([ProfessorId]) REFERENCES [dbo].[Users] ([UserID]),
    CONSTRAINT [FK_ProfessorPerLab_Labs] FOREIGN KEY ([LabId]) REFERENCES [dbo].[Labs] ([Id])
);

