 CREATE PROCEDURE [app].[GetDgCoreWithMasterTypes]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dc.id,
        dc.name AS description,
        dc.type AS type_id,
        mdt.name AS type_name,
        dc.active AS STATUS,
        dc.show_health_profile
    FROM 
        dg_core dc
    INNER JOIN 
        master_dg_types mdt ON dc.type = mdt.id;
END