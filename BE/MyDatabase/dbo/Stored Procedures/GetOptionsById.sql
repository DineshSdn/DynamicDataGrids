
CREATE PROCEDURE GetOptionsById
    @QuestionId INT 
AS
BEGIN

select *from multiple_choise_table where DgFieldId=@QuestionId
END;