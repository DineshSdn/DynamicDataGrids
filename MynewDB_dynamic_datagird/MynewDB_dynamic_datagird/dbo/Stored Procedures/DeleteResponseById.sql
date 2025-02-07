CREATE PROCEDURE [dbo].[DeleteResponseById]
	@id int
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the provided ID exists in the table
    IF EXISTS (SELECT 1 FROM responsetable WHERE id = @id)
    BEGIN
        -- If the ID exists, delete the corresponding row
        DELETE FROM responsetable WHERE id = @id;
        SELECT 'Field with id '+ CAST(@ID AS VARCHAR(10)) + ' deleted successfully.' AS Message;
    END
    ELSE
    BEGIN
        -- If the ID does not exist, return a message indicating that the row was not found
        SELECT 'Row with ID ' + CAST(@ID AS VARCHAR(10)) + ' not found.' AS Message;
    END
END