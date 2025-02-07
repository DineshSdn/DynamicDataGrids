CREATE PROCEDURE [InsertIntoDgFieldResponse]
(
   
    @name NVARCHAR(100),
    @field_id INT,
    @active BIT,
    @ideal_choice BIT,
    @response_sort_order INT,
    @created_datetime DATETIME,
    @created_by INT,
    @modified_datetime DATETIME,
    @modified_by INT
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dg_field_responses] (
    
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
    VALUES (
        
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
END;