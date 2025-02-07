CREATE  PROCEDURE [dbo].[DeleteDg_field_ByID]
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the provided ID exists in the table
    IF EXISTS (SELECT 1 FROM dg_fields WHERE ID = @ID)
    BEGIN
        -- If the ID exists, delete the corresponding row
        DELETE FROM dg_fields WHERE ID = @ID;
        SELECT 'Field with id '+ CAST(@ID AS VARCHAR(10)) + ' deleted successfully.' AS Message;
    END
    ELSE
    BEGIN
        -- If the ID does not exist, return a message indicating that the row was not found
        SELECT 'Row with ID ' + CAST(@ID AS VARCHAR(10)) + ' not found.' AS Message;
    END
END