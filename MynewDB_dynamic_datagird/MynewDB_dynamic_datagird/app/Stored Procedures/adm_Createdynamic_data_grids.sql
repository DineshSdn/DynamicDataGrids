create    PROCEDURE [app].[adm_Createdynamic_data_grids] (  
 @id INT  
 ,@name NVARCHAR(100)  
 ,@description NVARCHAR(max)  
 ,@show_health_profile BIT  
 ,@type INT  
 ,@status BIT  
 ,@loggedin_user_id INT  
 ,@roleids VARCHAR(MAX) 
 ,@sortorder INT=NULL
 )  
AS  
BEGIN    
 DECLARE @temproleids TABLE (  
  id INT identity(1, 1) PRIMARY KEY  
  ,roles_id INT  
  )  
 BEGIN TRY  
  
  IF @roleids <> ''  
  BEGIN  
   INSERT INTO @temproleids (roles_id)  
   SELECT Item  
   FROM app.splitstring(@roleids, ',')  
  END  
  
  IF @id <> 0  
  BEGIN  
   UPDATE [app].[dg_core]  
   SET [name] = @name  
    ,[description] = @description  
    ,[show_health_profile] = @show_health_profile  
    ,[type] = @type  
    ,[active] = @status  
    ,[modified_datetime] = GETDATE()  
    ,[modified_by] = @loggedin_user_id  
    ,[code_key] = REPLACE(LOWER(@name), ' ', '_'),
     sort=@sortorder
   WHERE id = @id  
  
   --UPDATE ROLES   
   IF EXISTS (  
     SELECT TOP 1 1  
     FROM app.dg_core  
     WHERE id = @Id  
     )  
   BEGIN     
    UPDATE [app].[dg_to_roles]  
    SET active = 0  
     ,modified_datetime = GETDATE()  
     ,modified_by = @loggedin_user_id  
    WHERE datagrid_id = @Id  
     AND role_id NOT IN (  
      SELECT roles_id  
      FROM @temproleids  
      )  
  
    UPDATE [app].[dg_to_roles]  
    SET active = 1  
     ,modified_datetime = GETDATE()  
     ,modified_by = @loggedin_user_id  
    WHERE datagrid_id = @Id  
     AND role_id IN (  
      SELECT roles_id  
      FROM @temproleids  
      )  
  
    INSERT INTO [app].[dg_to_roles] (  
     datagrid_id  
     ,role_id  
     ,created_datetime  
     ,created_by  
     ,active       
     )  
    SELECT @Id  
     ,roles_id  
     ,GETDATE()  
     ,@loggedin_user_id  
     ,1       
    FROM @temproleids t1  
    WHERE NOT EXISTS (  
      SELECT TOP 1 1  
      FROM [app].[dg_to_roles] t2  
      WHERE t1.roles_id = t2.role_id  
       AND datagrid_id = @Id  
      )  
   END  
  
   SELECT @id AS Id  
    ,200 AS STATUS  
    ,'Datagrid Updated successfully' AS Message  
    ,'' AS ErrorDetail  
  END  
  ELSE  
  BEGIN  
   INSERT INTO [app].[dg_core] (  
    [name]  
    ,[description]  
    ,[show_health_profile]  
    ,[type]  
    ,[active]  
    ,[created_datetime]  
    ,[created_by]  
    ,[code_key] 
	,[sort]
    )  
   VALUES (  
    @name  
    ,@description  
    ,@show_health_profile  
    ,@type  
    ,@status  
    ,GETDATE()  
    ,@loggedin_user_id  
    ,REPLACE(LOWER(@name), ' ', '_') 
	,@sortorder
    )  
   IF EXISTS (  
     SELECT TOP 1 1  
     FROM app.dg_core  
     WHERE id = @Id  
     )  
   BEGIN  
    INSERT INTO [app].[dg_to_roles] (  
     datagrid_id  
     ,role_id  
     ,created_datetime  
     ,created_by  
     ,active       
     )  
    SELECT @Id  
     ,roles_id  
     ,GETDATE()  
     ,@loggedin_user_id  
     ,1       
    FROM @temproleids t1  
    WHERE NOT EXISTS (  
      SELECT TOP 1 1  
      FROM [app].[dg_to_roles] t2  
      WHERE t1.roles_id = t2.role_id  
       AND datagrid_id = @Id  
      )  
   END  
   SELECT @@IDENTITY AS Id  
    ,200 AS STATUS  
    ,'Datagrid created successfully' AS Message  
    ,'' AS ErrorDetail  
  END  
 END TRY  
  
 BEGIN CATCH  
  SELECT 0 AS Id  
   ,500 AS STATUS  
   ,ERROR_MESSAGE() AS Message  
   ,ERROR_MESSAGE() AS ErrorDetail  
 END CATCH  
END