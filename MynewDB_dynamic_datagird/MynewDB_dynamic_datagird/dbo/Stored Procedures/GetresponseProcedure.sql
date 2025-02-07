CREATE   PROCEDURE [dbo].[GetresponseProcedure]
    @GridId INT
AS
BEGIN
    SELECT questionid, response, time ,id,userid,gridid
FROM responsetable
where gridid=@GridId
GROUP BY questionid, response, time,id,userid,gridid;

END;