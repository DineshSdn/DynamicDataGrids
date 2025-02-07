create    PROCEDURE [app].[adm_getdynamic_data_grids] (@id INT = 0)  
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
   , dc.name
   ,(  
   SELECT STRING_AGG(rol.name, ',')  
   FROM app.dg_to_roles inpro WITH (NOLOCK)  
   LEFT JOIN app.[role] rol WITH (NOLOCK) ON rol.id = inpro.role_id  
   WHERE rol.active = 1 AND inpro.datagrid_id = dc.id AND inpro.active = 1  
   ) AS rolename  
  , (  
   SELECT STRING_AGG(rol.id, ',')  
   FROM app.dg_to_roles inpro WITH (NOLOCK)  
   LEFT JOIN app.[role] rol WITH (NOLOCK) ON rol.id = inpro.role_id  
   WHERE rol.active = 1 AND inpro.datagrid_id = dc.id AND inpro.active = 1  
   ) AS role_id  
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
   , dc.name
   ,(  
   SELECT STRING_AGG(rol.name, ',')  
   FROM app.dg_to_roles inpro WITH (NOLOCK)  
   LEFT JOIN app.[role] rol WITH (NOLOCK) ON rol.id = inpro.role_id  
   WHERE rol.active = 1 AND inpro.datagrid_id = dc.id AND inpro.active = 1  
   ) AS rolename  
  , (  
   SELECT STRING_AGG(rol.id, ',')  
   FROM app.dg_to_roles inpro WITH (NOLOCK)  
   LEFT JOIN app.[role] rol WITH (NOLOCK) ON rol.id = inpro.role_id  
   WHERE rol.active = 1 AND inpro.datagrid_id = dc.id AND inpro.active = 1  
   ) AS role_id  
  FROM dg_core dc  
  JOIN master_dg_types mdt ON dc.type = mdt.id  
 END  
END