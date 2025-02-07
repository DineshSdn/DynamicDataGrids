CREATE TABLE [dbo].[dg_field_calculations] (
    [id]                         INT            IDENTITY (1, 1) NOT NULL,
    [calc_field1]                INT            NOT NULL,
    [calc_field1_transformation] NVARCHAR (MAX) NOT NULL,
    [calc_field2]                INT            NOT NULL,
    [mid_operator]               NVARCHAR (MAX) NOT NULL,
    [calc_field2_transformation] NVARCHAR (MAX) NOT NULL,
    [enable_post_operator]       BIT            NOT NULL,
    [post_operator]              NVARCHAR (MAX) NOT NULL,
    [post_operator_val]          INT            NULL,
    [field_id]                   INT            NOT NULL,
    [created_datetime]           DATETIME2 (7)  NOT NULL,
    [created_by]                 INT            NOT NULL,
    [modified_datetime]          DATETIME2 (7)  NULL,
    [modified_by]                INT            NULL,
    CONSTRAINT [PK_dg_field_calculations] PRIMARY KEY CLUSTERED ([id] ASC)
);

