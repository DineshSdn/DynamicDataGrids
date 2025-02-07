
CREATE PROCEDURE Get_Calculated_Fields
    @Grid_Id INT
AS
BEGIN
    -- Check if any records match the criteria
    IF EXISTS (
        SELECT 1 
        FROM dg_fields 
        WHERE datagrid_id = @Grid_Id
        AND is_integer_only = 1
    )
    BEGIN
        -- If records are found, select them
        SELECT * 
        FROM dg_fields 
        WHERE datagrid_id = @Grid_Id
        AND is_integer_only = 1;
    END
    ELSE
    BEGIN
        -- If no records are found, return "No data found"
        RAISERROR ('No data found', 16, 1);
    END
END;