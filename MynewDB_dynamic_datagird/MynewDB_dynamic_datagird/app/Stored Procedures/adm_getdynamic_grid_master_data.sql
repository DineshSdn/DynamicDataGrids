-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: Getting data of dynamic grid master
-- exec [app].[adm_getdynamic_grid_master_data]
-- =============================================
create   PROCEDURE [app].[adm_getdynamic_grid_master_data]
AS
BEGIN
	--Dynamic grid types
	SELECT id
		, name
		, code
		, active
	FROM master_dg_types
	--Dynamic grid field types
	SELECT id
		, name
		, code
		, has_response_values
	FROM master_dg_field_types where active = 1
	--Dynamic grid lookup datasets
	SELECT id
		, name
		, code
		, active
	FROM master_dg_lookup_datasets
END