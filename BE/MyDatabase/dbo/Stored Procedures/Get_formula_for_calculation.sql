CREATE PROCEDURE [dbo].[Get_formula_for_calculation]
    @field_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT id,field_id,calc_field1, calc_field1_transformation, mid_operator,calc_field2,
	calc_field2_transformation, enable_post_operator, post_operator, post_operator_val
    FROM dg_field_calculations
    WHERE field_id = @field_id;
END;