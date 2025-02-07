CREATE TABLE [dbo].[dg_field_cpt_code] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [cpt_code_id]       INT            NOT NULL,
    [field_id]          INT            NOT NULL,
    [field_type_id]     INT            NOT NULL,
    [trigger_type]      NVARCHAR (MAX) NOT NULL,
    [trigger_match]     INT            NULL,
    [trigger_range_min] INT            NULL,
    [trigger_range_max] INT            NULL,
    [qualifier_value]   INT            NULL,
    [text_value]        NVARCHAR (MAX) NOT NULL,
    [active]            BIT            NOT NULL,
    [created_datetime]  DATETIME2 (7)  NOT NULL,
    [created_by]        INT            NOT NULL,
    [modified_datetime] DATETIME2 (7)  NULL,
    [modified_by]       INT            NULL,
    CONSTRAINT [PK_dg_field_cpt_code] PRIMARY KEY CLUSTERED ([id] ASC)
);

