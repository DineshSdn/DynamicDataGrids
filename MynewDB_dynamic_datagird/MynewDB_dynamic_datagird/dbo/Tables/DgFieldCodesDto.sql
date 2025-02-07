CREATE TABLE [dbo].[DgFieldCodesDto] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [suspect_icd10]       INT            NOT NULL,
    [suspect_code]        NVARCHAR (MAX) NULL,
    [suspect_description] NVARCHAR (MAX) NULL,
    [field_id]            INT            NOT NULL,
    [field_type_id]       INT            NOT NULL,
    [trigger_type]        NVARCHAR (MAX) NULL,
    [trigger_match]       INT            NULL,
    [trigger_range_min]   INT            NULL,
    [trigger_range_max]   INT            NULL,
    [qualifier_value]     INT            NULL,
    [text_value]          NVARCHAR (MAX) NULL,
    [datagrid_id]         INT            NULL,
    [DgFieldid]           INT            NULL,
    CONSTRAINT [PK_DgFieldCodesDto] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_DgFieldCodesDto_dg_fields_DgFieldid] FOREIGN KEY ([DgFieldid]) REFERENCES [dbo].[dg_fields] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_DgFieldCodesDto_DgFieldid]
    ON [dbo].[DgFieldCodesDto]([DgFieldid] ASC);

