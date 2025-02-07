CREATE TABLE [dbo].[responsetable] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [userid]     INT            NOT NULL,
    [gridid]     INT            NOT NULL,
    [questionid] INT            NOT NULL,
    [question]   NVARCHAR (MAX) NOT NULL,
    [response]   NVARCHAR (MAX) NOT NULL,
    [time]       DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_responsetable] PRIMARY KEY CLUSTERED ([id] ASC)
);

