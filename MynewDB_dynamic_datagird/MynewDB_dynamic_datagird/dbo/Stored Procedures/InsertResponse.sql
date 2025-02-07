CREATE PROCEDURE [dbo].[InsertResponse]
    @id INT,
    @userid INT,
    @gridid INT,
    @Queid INT,
    @question NVARCHAR(MAX),
    @response NVARCHAR(MAX),
    @time DATETIME
AS
BEGIN
     SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM responsetable WHERE id = @id)
    BEGIN
        -- If the id exists, update the existing record
        UPDATE responsetable
        SET 
            userid = @userid,
            gridid = @gridid,
            questionid = @Queid,
            question = @question,
            response = @response,
            time = @time
        WHERE id = @id;
    END
    ELSE
    BEGIN
        -- If the id does not exist, insert a new record
        INSERT INTO responsetable (userid, gridid, questionid, question, response, time)
        VALUES (@userid, @gridid, @Queid, @question, @response, @time);

        -- Get the newly inserted ID
        SET @id = SCOPE_IDENTITY();
    END

    -- Return the id of the inserted/updated record
    SELECT @id AS Id;
END