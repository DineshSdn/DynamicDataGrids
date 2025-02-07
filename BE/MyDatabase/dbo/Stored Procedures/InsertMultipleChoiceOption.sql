CREATE PROCEDURE InsertMultipleChoiceOption
    @input_id INT,
    @input_option VARCHAR(255)
AS
BEGIN
    INSERT INTO multiple_choice_table (DgFieldId, [option])
    VALUES (@input_id, @input_option);
END