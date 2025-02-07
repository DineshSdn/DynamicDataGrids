CREATE TABLE [dbo].[master_icd] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [active]            BIT            NOT NULL,
    [codeset]           NVARCHAR (255) NOT NULL,
    [codeset_version]   NVARCHAR (255) NOT NULL,
    [active_start]      DATETIME2 (7)  NOT NULL,
    [active_end]        DATETIME2 (7)  NOT NULL,
    [is_sensitive]      BIT            NOT NULL,
    [categoryCode]      NVARCHAR (255) NOT NULL,
    [code]              NVARCHAR (255) NOT NULL,
    [description]       NVARCHAR (MAX) NOT NULL,
    [isBillable]        BIT            NOT NULL,
    [is_billable]       BIT            NOT NULL,
    [hcc_code]          INT            NULL,
    [created_datetime]  DATETIME2 (7)  NOT NULL,
    [created_by]        INT            NOT NULL,
    [modified_datetime] DATETIME2 (7)  NULL,
    [modified_by]       INT            NULL,
    CONSTRAINT [PK_master_icd] PRIMARY KEY CLUSTERED ([id] ASC)
);

