CREATE PROCEDURE [app].[adm_getdynamicdatagridss] (@id INT = 0)  
AS  
BEGIN  
    IF @id = 0  
    BEGIN  
        SELECT dgc.id, dgc.name as head_name, dgc.description, dgc.type, mdt.name, dgc.active, dgc.show_health_profile
        FROM dg_core AS dgc
        LEFT JOIN master_Dg_Types AS mdt ON dgc.type = mdt.id;
    END  
    ELSE  
    BEGIN  
        SELECT dgc.id, dgc.name as head_name, dgc.description, dgc.type, mdt.name, dgc.active, dgc.show_health_profile
        FROM dg_core AS dgc
        LEFT JOIN master_Dg_Types AS mdt ON dgc.type = mdt.id
        WHERE dgc.id = @id;
    END  
END