CREATE PROCEDURE [app].[add_update_field]
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
    IF EXISTS (SELECT 1 FROM [app].[your_table_name] WHERE id = @id)
    BEGIN
        -- Update existing record
        UPDATE [app].[your_table_name]
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
        INSERT INTO [app].[your_table_name] (
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

        SELECT SCOPE_IDENTITY() AS Id, 0 AS OperationStatus; -- 0 indicates add operation
    END
END