CREATE TABLE [dbo].[master_cpt] (
    [id]                INT             IDENTITY (1, 1) NOT NULL,
    [active]            BIT             NOT NULL,
    [codeset]           NVARCHAR (255)  NOT NULL,
    [codeset_version]   NVARCHAR (255)  NOT NULL,
    [active_start]      DATETIME2 (7)   NOT NULL,
    [active_end]        DATETIME2 (7)   NOT NULL,
    [is_sensitive]      BIT             NOT NULL,
    [code]              NVARCHAR (255)  NOT NULL,
    [description]       NVARCHAR (MAX)  NOT NULL,
    [amount]            DECIMAL (18, 2) NULL,
    [created_datetime]  DATETIME2 (7)   NOT NULL,
    [created_by]        INT             NOT NULL,
    [modified_datetime] DATETIME2 (7)   NULL,
    [modified_by]       INT             NULL,
    CONSTRAINT [PK_master_cpt] PRIMARY KEY CLUSTERED ([id] ASC)
);

