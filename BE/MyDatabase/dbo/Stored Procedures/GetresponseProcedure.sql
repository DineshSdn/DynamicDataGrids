CREATE   PROCEDURE GetresponseProcedure
    @GridId INT
AS
BEGIN
    SELECT  questionid, response, time
FROM responsetable
where gridid=@GridId
GROUP BY questionid, response, time;

END;