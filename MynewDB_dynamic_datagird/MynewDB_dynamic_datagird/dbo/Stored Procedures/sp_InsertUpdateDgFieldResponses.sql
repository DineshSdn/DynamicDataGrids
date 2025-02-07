CREATE   PROCEDURE sp_InsertUpdateDgFieldResponses
    @name NVARCHAR(255),
    @field_id INT,
    @active BIT,
    @ideal_choice bit,
    @response_sort_order INT,
    @created_datetime DATETIME,
    @created_by int,
    @modified_datetime DATETIME,
    @modified_by int
AS
BEGIN
    SET NOCOUNT ON;

    -- Try to update the record if it exists
    UPDATE dg_field_responses
    SET 
        name = @name,
        active = @active,
        ideal_choice = @ideal_choice,
        response_sort_order = @response_sort_order,
        modified_datetime = @modified_datetime,
        modified_by = @modified_by
    WHERE field_id = @field_id;

    -- If no records were updated, insert a new record
    IF @@ROWCOUNT = 0
    BEGIN
        INSERT INTO dg_field_responses
        (
            name,
            field_id,
            active,
            ideal_choice,
            response_sort_order,
            created_datetime,
            created_by,
            modified_datetime,
            modified_by
        )
        VALUES
        (
            @name,
            @field_id,
            @active,
            @ideal_choice,
            @response_sort_order,
            @created_datetime,
            @created_by,
            @modified_datetime,
            @modified_by
        );
    END
END;