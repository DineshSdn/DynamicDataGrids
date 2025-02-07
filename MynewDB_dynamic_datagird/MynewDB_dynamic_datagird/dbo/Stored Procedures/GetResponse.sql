CREATE PROCEDURE [dbo].[GetResponse] 
    @fieldid INT
AS
BEGIN
    IF @fieldid = 0 -- Check if the field ID is 0
    BEGIN
        SELECT * FROM dg_field_responses; -- Return all records if field ID is 0
    END
    ELSE
    BEGIN
        IF EXISTS (SELECT 1 FROM dg_field_responses WHERE field_id = @fieldid)
        BEGIN
            SELECT * FROM dg_field_responses WHERE field_id = @fieldid; -- Return records for specified field ID
        END
        ELSE
        BEGIN
            SELECT 'Record not found' AS Message; -- Return a message if no records found for specified field ID
        END
    END
END;