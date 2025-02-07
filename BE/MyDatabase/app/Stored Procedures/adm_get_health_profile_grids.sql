create PROCEDURE [app].[adm_get_health_profile_grids]  
AS  
BEGIN  
 SELECT dc.id  
  , dc.name  
  , dc.type AS type_id  
  , dc.description  
  , mdt.name AS type_name  
  , dc.active AS STATUS  
  , dc.show_health_profile  
 FROM dg_core dc  
 JOIN master_dg_field_types mdt  
  ON dc.type = mdt.id  
 WHERE dc.active = 1  
  AND show_health_profile = 1  
 ORDER BY dc.name ASC
END