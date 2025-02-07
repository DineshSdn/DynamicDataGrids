CREATE TABLE [dbo].[DgFieldResponseDto] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [name]                NVARCHAR (MAX) NOT NULL,
    [field_id]            INT            NOT NULL,
    [ideal_choice]        BIT            DEFAULT (CONVERT([bit],(0))) NOT NULL,
    [response_sort_order] INT            NOT NULL,
    [active]              BIT            NOT NULL,
    [DgFieldid]           INT            NULL,
    [created_by]          INT            DEFAULT ((0)) NOT NULL,
    [created_datetime]    DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    [modified_by]         INT            DEFAULT ((0)) NOT NULL,
    [modified_datetime]   DATETIME2 (7)  DEFAULT ('0001-01-01T00:00:00.0000000') NOT NULL,
    CONSTRAINT [PK_DgFieldResponseDto] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_DgFieldResponseDto_dg_fields_DgFieldid] FOREIGN KEY ([DgFieldid]) REFERENCES [dbo].[dg_fields] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_DgFieldResponseDto_DgFieldid]
    ON [dbo].[DgFieldResponseDto]([DgFieldid] ASC);

