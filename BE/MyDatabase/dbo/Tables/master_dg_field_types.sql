CREATE TABLE [dbo].[master_dg_field_types] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [name]                NVARCHAR (255) NOT NULL,
    [code]                NVARCHAR (50)  NOT NULL,
    [has_response_values] BIT            NOT NULL,
    [active]              BIT            NOT NULL,
    [created_datetime]    DATETIME       NOT NULL,
    [created_by]          INT            NOT NULL,
    [modified_datetime]   DATETIME       NULL,
    [modified_by]         INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

