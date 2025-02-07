CREATE PROCEDURE GetHealthProfileGrids
    @GridId INT
AS
BEGIN
    SELECT * FROM dg_fields WHERE datagrid_id = @GridId
END