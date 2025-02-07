create PROCEDURE [app].[adm_getdynamic_data_grids(1)] (@id INT = 0)  
AS  
BEGIN  
    IF @id <> 0  
    BEGIN  
        SELECT dc.id  
            , dc.name  
            , dc.description  
            , dc.type AS type_id  
            , mdt.name AS type_name  
            , dc.active AS STATUS  
            , dc.show_health_profile
        FROM dg_core dc  
        JOIN master_dg_types mdt ON dc.type = mdt.id  
        WHERE dc.id = @id  
    END  
    ELSE  
    BEGIN  
        SELECT dc.id  
            , dc.name  
            , dc.description  
            , dc.type AS type_id  
            , mdt.name AS type_name  
            , dc.active AS STATUS  
            , dc.show_health_profile 
        FROM dg_core dc  
        JOIN master_dg_types mdt ON dc.type = mdt.id  
    END  
END