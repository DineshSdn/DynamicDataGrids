CREATE TABLE [dbo].[master_Dg_Types] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (MAX) NOT NULL,
    [code]              NVARCHAR (MAX) NOT NULL,
    [active]            BIT            NOT NULL,
    [created_datetime]  DATETIME2 (7)  NOT NULL,
    [created_by]        INT            NOT NULL,
    [modified_datetime] DATETIME2 (7)  NULL,
    [modified_by]       INT            NULL,
    CONSTRAINT [PK_master_Dg_Types] PRIMARY KEY CLUSTERED ([id] ASC)
);

