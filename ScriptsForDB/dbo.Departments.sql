CREATE TABLE [dbo].[Departments] (
    [DepartmentID]  INT           NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Budget]        MONEY         NOT NULL,
    [StartDate]     DATETIME      NOT NULL,
    [Administrator] INT           NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([DepartmentID] ASC)
);

