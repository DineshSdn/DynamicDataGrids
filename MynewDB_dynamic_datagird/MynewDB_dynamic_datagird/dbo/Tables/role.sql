CREATE TABLE [dbo].[role] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [role_nmae]             NVARCHAR (MAX) NOT NULL,
    [name]                  NVARCHAR (255) NULL,
    [active]                BIT            NULL,
    [code_key]              NVARCHAR (50)  NULL,
    [created_datetime]      DATETIME       NULL,
    [created_by]            INT            NULL,
    [modified_datetime]     DATETIME       NULL,
    [modified_by]           INT            NULL,
    [destination]           NVARCHAR (255) NULL,
    [timesheet_location_id] INT            NULL,
    CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED ([Id] ASC)
);

