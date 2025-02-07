CREATE TABLE [dbo].[testDataSeedings] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_testDataSeedings] PRIMARY KEY CLUSTERED ([Id] ASC)
);

