CREATE TABLE [dbo].[dg_to_roles] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    [datagrid_id]       INT           NOT NULL,
    [role_id]           INT           NOT NULL,
    [active]            BIT           NOT NULL,
    [created_datetime]  DATETIME2 (7) NOT NULL,
    [created_by]        INT           NOT NULL,
    [modified_datetime] DATETIME2 (7) NULL,
    [modified_by]       INT           NULL,
    CONSTRAINT [PK_dg_to_roles] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_dg_to_roles_dg_core_datagrid_id] FOREIGN KEY ([datagrid_id]) REFERENCES [dbo].[dg_core] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dg_to_roles_role_role_id] FOREIGN KEY ([role_id]) REFERENCES [dbo].[role] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_dg_to_roles_role_id]
    ON [dbo].[dg_to_roles]([role_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_dg_to_roles_datagrid_id]
    ON [dbo].[dg_to_roles]([datagrid_id] ASC);

