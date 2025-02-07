CREATE TABLE [dbo].[DgFieldCPTCodesDto] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [cpt_code_id]       INT            NOT NULL,
    [cpt_code]          NVARCHAR (MAX) NULL,
    [cpt_description]   NVARCHAR (MAX) NULL,
    [field_id]          INT            NOT NULL,
    [field_type_id]     INT            NOT NULL,
    [trigger_type]      NVARCHAR (MAX) NULL,
    [trigger_match]     INT            NULL,
    [trigger_range_min] INT            NULL,
    [trigger_range_max] INT            NULL,
    [qualifier_value]   INT            NULL,
    [text_value]        NVARCHAR (MAX) NULL,
    [DgFieldid]         INT            NULL,
    CONSTRAINT [PK_DgFieldCPTCodesDto] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_DgFieldCPTCodesDto_dg_fields_DgFieldid] FOREIGN KEY ([DgFieldid]) REFERENCES [dbo].[dg_fields] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_DgFieldCPTCodesDto_DgFieldid]
    ON [dbo].[DgFieldCPTCodesDto]([DgFieldid] ASC);

