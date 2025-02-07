CREATE TABLE [dbo].[multiple_choise_table] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [DgFieldId] INT            NOT NULL,
    [Option]    NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_multiple_choise_table] PRIMARY KEY CLUSTERED ([Id] ASC)
);

