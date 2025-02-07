CREATE PROCEDURE [dbo].[InsertResponse]
    @userid INT,
    @gridid INT,
    @Queid INT,
    @question NVARCHAR(MAX),
    @response NVARCHAR(MAX),
    @time DATETIME
AS
BEGIN
    INSERT INTO responsetable (userid, gridid, questionid, question, response, time)
    VALUES (@userid, @gridid, @Queid, @question, @response, @time)


	SELECT SCOPE_IDENTITY() AS Id;
END