﻿CREATE TABLE [dbo].[dg_fields] (
    [id]                     INT            IDENTITY (1, 1) NOT NULL,
    [name]                   NVARCHAR (MAX) NOT NULL,
    [field_type_id]          INT            NOT NULL,
    [field_type_name]        NVARCHAR (MAX) NOT NULL,
    [has_response_values]    BIT            NOT NULL,
    [is_required]            BIT            NOT NULL,
    [is_integer_only]        BIT            NULL,
    [integer_validation_min] INT            NULL,
    [integer_validation_max] INT            NULL,
    [lookup_dataset]         INT            NULL,
    [lookup_dataset_name]    NVARCHAR (MAX) NOT NULL,
    [datagrid_id]            INT            NOT NULL,
    [status]                 BIT            NOT NULL,
    [show_in_tabular]        BIT            NOT NULL,
    [tabular_sort_order]     INT            NOT NULL,
    [show_in_detail]         BIT            NOT NULL,
    [detail_sort_order]      INT            NOT NULL,
    [response_count]         INT            NOT NULL,
    [field_tooltip]          NVARCHAR (MAX) NOT NULL,
    [field_selected_value]   NVARCHAR (MAX) NULL,
    [edited_field_result_id] INT            NOT NULL,
    CONSTRAINT [PK_dg_fields] PRIMARY KEY CLUSTERED ([id] ASC)
);

