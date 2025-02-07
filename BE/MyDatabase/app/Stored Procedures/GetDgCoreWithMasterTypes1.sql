 CREATE PROCEDURE [app].[GetDgCoreWithMasterTypes1]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dc.id,
        dc.name AS description,
        dc.type AS type_id,
        ISNULL(mdt.name, 'Unknown') AS type_name,
        dc.active AS STATUS,
        dc.show_health_profile
    FROM 
        dg_core dc
    LEFT JOIN 
        master_dg_types mdt ON dc.type = mdt.id;
END