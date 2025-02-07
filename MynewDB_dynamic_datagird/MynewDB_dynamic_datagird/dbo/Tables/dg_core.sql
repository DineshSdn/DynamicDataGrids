CREATE TABLE [dbo].[dg_core] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [name]                NVARCHAR (MAX) NOT NULL,
    [description]         NVARCHAR (MAX) NOT NULL,
    [show_health_profile] BIT            NOT NULL,
    [type]                INT            NOT NULL,
    [active]              BIT            NOT NULL,
    [code_key]            NVARCHAR (MAX) NOT NULL,
    [created_datetime]    DATETIME2 (7)  NOT NULL,
    [created_by]          INT            NOT NULL,
    [modified_datetime]   DATETIME2 (7)  NULL,
    [modified_by]         INT            NULL,
    [MasterDgTypes]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dg_core] PRIMARY KEY CLUSTERED ([id] ASC)
);

