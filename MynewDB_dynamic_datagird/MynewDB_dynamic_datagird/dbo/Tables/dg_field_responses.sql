CREATE TABLE [dbo].[dg_field_responses] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [name]                NVARCHAR (MAX) NOT NULL,
    [field_id]            INT            NOT NULL,
    [active]              BIT            NOT NULL,
    [ideal_choice]        BIT            NULL,
    [response_sort_order] INT            NOT NULL,
    [created_datetime]    DATETIME2 (7)  NOT NULL,
    [created_by]          INT            NOT NULL,
    [modified_datetime]   DATETIME2 (7)  NULL,
    [modified_by]         INT            NULL,
    CONSTRAINT [PK_dg_field_responses] PRIMARY KEY CLUSTERED ([id] ASC)
);

