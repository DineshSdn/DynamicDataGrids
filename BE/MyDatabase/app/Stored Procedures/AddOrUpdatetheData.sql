
CREATE PROCEDURE [app].[AddOrUpdatetheData]
(
    @id INT = NULL,
    @name NVARCHAR(100),
    @description NVARCHAR(MAX),
    @show_health_profile BIT,
    @type INT,
    @active BIT,
    @code_key NVARCHAR(100),
    @created_by INT,
    @modified_by INT = NULL,
    @MasterDgTypes NVARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;

    IF @id IS NULL -- If ID is not provided, insert new record
    BEGIN
        INSERT INTO dg_core(name, description, show_health_profile, type, active, code_key, created_datetime, created_by, modified_datetime, modified_by, MasterDgTypes)
        VALUES (@name, @description, @show_health_profile, @type, @active, @code_key, GETDATE(), @created_by, GETDATE(), @modified_by, @MasterDgTypes);

        SELECT SCOPE_IDENTITY() AS NewId; -- Return the ID of the newly inserted record
    END
    ELSE -- If ID is provided, update existing record
    BEGIN
        UPDATE dg_core
        SET name = @name,
            description = @description,
            show_health_profile = @show_health_profile,
            type = @type,
            active = @active,
            code_key = @code_key,
            modified_datetime = GETDATE(),
            modified_by = @modified_by,
            MasterDgTypes = @MasterDgTypes
        WHERE id = @id;

        SELECT @id AS UpdatedId; -- Return the ID of the updated record
    END
END