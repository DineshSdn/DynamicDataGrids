CREATE PROCEDURE [app].[add_update_fieldse]
(
    @id INT,
    @name NVARCHAR(100),
    @field_type_id INT,
    @field_type_name NVARCHAR(100),
    @has_response_values BIT,
    @is_required BIT,
    @is_integer_only BIT = NULL,
    @integer_validation_min INT = NULL,
    @integer_validation_max INT = NULL,
    @lookup_dataset INT,
    @lookup_dataset_name NVARCHAR(100),
    @datagrid_id INT,
    @status BIT,
    @show_in_tabular BIT,
    @tabular_sort_order INT,
    @show_in_detail BIT,
    @detail_sort_order INT,
    @response_count INT,
    @field_tooltip NVARCHAR(255),
    @field_selected_value NVARCHAR(255),
    @edited_field_result_id INT
)
AS
BEGIN
    -- Check if the provided ID exists in the table
    IF EXISTS (SELECT 1 FROM [dg_fields] WHERE id = @id)
    BEGIN
        -- Update existing record
        UPDATE [dg_fields]
        SET [name] = @name,
            [field_type_id] = @field_type_id,
            [field_type_name] = @field_type_name,
            [has_response_values] = @has_response_values,
            [is_required] = @is_required,
            [is_integer_only] = @is_integer_only,
            [integer_validation_min] = @integer_validation_min,
            [integer_validation_max] = @integer_validation_max,
            [lookup_dataset] = @lookup_dataset,
            [lookup_dataset_name] = @lookup_dataset_name,
            [datagrid_id] = @datagrid_id,
            [status] = @status,
            [show_in_tabular] = @show_in_tabular,
            [tabular_sort_order] = @tabular_sort_order,
            [show_in_detail] = @show_in_detail,
            [detail_sort_order] = @detail_sort_order,
            [response_count] = @response_count,
            [field_tooltip] = @field_tooltip,
            [field_selected_value] = @field_selected_value,
            [edited_field_result_id] = @edited_field_result_id
        WHERE id = @id;

        SELECT @id AS Id, 1 AS OperationStatus; -- 1 indicates update operation
    END
    ELSE
    BEGIN
        -- Insert new record
        INSERT INTO [dg_fields] (
            [name],
            [field_type_id],
            [field_type_name],
            [has_response_values],
            [is_required],
            [is_integer_only],
            [integer_validation_min],
            [integer_validation_max],
            [lookup_dataset],
            [lookup_dataset_name],
            [datagrid_id],
            [status],
            [show_in_tabular],
            [tabular_sort_order],
            [show_in_detail],
            [detail_sort_order],
            [response_count],
            [field_tooltip],
            [field_selected_value],
            [edited_field_result_id]
        ) VALUES (
            @name,
            @field_type_id,
            @field_type_name,
            @has_response_values,
            @is_required,
            @is_integer_only,
            @integer_validation_min,
            @integer_validation_max,
            @lookup_dataset,
            @lookup_dataset_name,
            @datagrid_id,
            @status,
            @show_in_tabular,
            @tabular_sort_order,
            @show_in_detail,
            @detail_sort_order,
            @response_count,
            @field_tooltip,
            @field_selected_value,
            @edited_field_result_id
        );

         SELECT @id = SCOPE_IDENTITY();

    -- return the response
    SELECT @id AS Id, 0 AS Status, 'Field created successfully' AS Message;
    END

END

--select *from dg_fields

--EXEC [app].[add_update_fieldse]
--    @id = 0,  -- Use 0 to indicate a new record
--    @name = N'Sample Field Name',
--    @field_type_id = 1,
--    @field_type_name = N'String',
--    @has_response_values = 1,
--    @is_required = 1,
--    @is_integer_only = NULL,
--    @integer_validation_min = NULL,
--    @integer_validation_max = NULL,
--    @lookup_dataset = 123,
--    @lookup_dataset_name = N'Sample Dataset',
--    @datagrid_id = 456,
--    @status = 1,
--    @show_in_tabular = 1,
--    @tabular_sort_order = 1,
--    @show_in_detail = 1,
--    @detail_sort_order = 1,
--    @response_count = 0,
--    @field_tooltip = N'Sample Tooltip',
--    @field_selected_value = N'Sample Value',
--    @edited_field_result_id = 789;