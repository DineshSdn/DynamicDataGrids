create  PROCEDURE [app].[adm_get_dg_fields(1)] (
	@id INT = 0
	, @datagridId INT
	)
AS
BEGIN
	IF @id <> 0
	BEGIN
		--dg_fields
		SELECT dgf.[id]
			, dgf.[name]
			, dgf.[field_type_id] AS field_type_id
			, mdf.[name] AS field_type_name
			, mdf.[has_response_values]
			, dgf.[is_required]
			, dgf.[is_integer_only]
			, dgf.[integer_validation_min]
			, dgf.[integer_validation_max]
			, dgf.[lookup_dataset] AS lookup_dataset
			, mdl.[name] AS lookup_dataset_name
			, dgf.[datagrid_id]
			, dgf.[status] AS STATUS
			, dgf.[show_in_tabular]
			, dgf.[tabular_sort_order]
			, dgf.[show_in_detail]
			, dgf.[detail_sort_order]
			, dgf.[field_tooltip]
			, count(dfr.id) AS response_count
		FROM dg_fields AS dgf
		JOIN master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		JOIN dg_core dc ON dgf.datagrid_id = dc.id
		LEFT JOIN master_dg_lookup_datasets mdl ON dgf.lookup_dataset = mdl.id
		LEFT JOIN dg_field_responses dfr ON dgf.id = dfr.field_id and dfr.active = 1
		WHERE dgf.id =@id AND dgf.datagrid_id =@datagridId
		GROUP BY dgf.[id]
			, dgf.[name]
			, dgf.[field_type_id]
			, mdf.[name]
			, mdf.[has_response_values]
			, dgf.[is_required]
			, dgf.[is_integer_only]
			, dgf.[integer_validation_min]
			, dgf.[integer_validation_max]
			, dgf.[lookup_dataset]
			, mdl.[name]
			, dgf.[datagrid_id]
			, dgf.[status]
			, dgf.[show_in_tabular]
			, dgf.[tabular_sort_order]
			, dgf.[show_in_detail]
			, dgf.[detail_sort_order]
			, dgf.[field_tooltip]
		--dg_field_calculation
		SELECT dgc.id
			, dgc.calc_field1
			, dgc.calc_field1_transformation
			, dgc.calc_field2
			, dgc.mid_operator
			, dgc.calc_field2_transformation
			, dgc.enable_post_operator
			, dgc.post_operator
			, dgc.post_operator_val
			, dgc.field_id
		FROM dg_field_calculations dgc
		JOIN dg_fields dgf ON dgc.field_id = dgf.id and dgf.status = 1
		JOIN master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		WHERE dgf.id = @id AND dgf.datagrid_id = @datagridId
		--dg_field_response
		SELECT dfr.id
			, dfr.name
			, dfr.field_id
			, dfr.ideal_choice
			, dfr.response_sort_order
			, dfr.active as status
		FROM dg_fields dgf
		JOIN dg_field_responses dfr ON dgf.id = dfr.field_id
		JOIN master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		WHERE dgf.id = @id AND dgf.datagrid_id = @datagridId and dgf.status = 1
		--dg_field_codes
		SELECT dfc.[id]
			, dfc.[suspect_icd10]
			, mi.code AS suspect_code
			, mi.description AS suspect_description
			, dfc.[field_id]
			, dfc.[field_type_id]
			, dfc.[trigger_type]
			, dfc.[trigger_match]
			, dfc.[trigger_range_min]
			, dfc.[trigger_range_max]
			, dfc.[qualifier_value]
			, dfc.[text_value]
		FROM dg_field_codes dfc
		JOIN master_icd mi ON dfc.[suspect_icd10] = mi.id
		JOIN dg_fields dgf ON dfc.field_id = dgf.id and dgf.status = 1
		JOIn master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		WHERE dfc.field_id = @id
		--dg_field_cpt_codes
		SELECT dfc.[id]
			, dfc.[cpt_code_id]
			, mi.code AS cpt_code
			, mi.description AS cpt_description
			, dfc.[field_id]
			, dfc.[field_type_id]
			, dfc.[trigger_type]
			, dfc.[trigger_match]
			, dfc.[trigger_range_min]
			, dfc.[trigger_range_max]
			, dfc.[qualifier_value]
			, dfc.[text_value]
		FROM dg_field_cpt_code dfc
		JOIN master_cpt mi ON dfc.[cpt_code_id] = mi.id
		JOIN dg_fields dgf ON dfc.field_id = dgf.id and dgf.status = 1
		JOIN master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		WHERE dfc.field_id = @id
	END
	ELSE
	BEGIN
		--dg_fields
		SELECT dgf.[id]
			, dgf.[name]
			, dgf.[field_type_id] AS field_type_id
			, mdf.[name] AS field_type_name
			, mdf.[has_response_values]
			, dgf.[is_required]
			, dgf.[is_integer_only]
			, dgf.[integer_validation_min]
			, dgf.[integer_validation_max]
			, dgf.[lookup_dataset] AS lookup_dataset
			, mdl.[name] AS lookup_dataset_name
			, dgf.[datagrid_id]
			, dgf.[status] AS STATUS
			, dgf.[show_in_tabular]
			, dgf.[tabular_sort_order]
			, dgf.[show_in_detail]
			, dgf.[detail_sort_order]
			, dgf.[field_tooltip]
			, count(dfr.id) AS response_count
		FROM dg_fields AS dgf
		JOIN master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		JOIN dg_core dc ON dgf.datagrid_id = dc.id
		LEFT JOIN master_dg_lookup_datasets mdl ON dgf.lookup_dataset = mdl.id
		LEFT JOIN dg_field_responses dfr ON dgf.id = dfr.field_id and dfr.active = 1
		WHERE dgf.datagrid_id = @datagridId
		GROUP BY dgf.[id]
			, dgf.[name]
			, dgf.[field_type_id]
			, mdf.[name]
			, mdf.[has_response_values]
			, dgf.[is_required]
			, dgf.[is_integer_only]
			, dgf.[integer_validation_min]
			, dgf.[integer_validation_max]
			, dgf.[lookup_dataset]
			, mdl.[name]
			, dgf.[datagrid_id]
			, dgf.[status]
			, dgf.[show_in_tabular]
			, dgf.[tabular_sort_order]
			, dgf.[show_in_detail]
			, dgf.[detail_sort_order]
			, dgf.[field_tooltip]
		--dg_field_calculation
		SELECT dgc.id
			, dgc.calc_field1
			, dgc.calc_field1_transformation
			, dgc.calc_field2
			, dgc.mid_operator
			, dgc.calc_field2_transformation
			, dgc.enable_post_operator
			, dgc.post_operator
			, dgc.post_operator_val
			, dgc.field_id
		FROM dg_field_calculations dgc
		JOIN dg_fields dgf ON dgc.field_id = dgf.id and dgf.status = 1
		JOIN master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		WHERE dgf.datagrid_id = @datagridId
		--dg_field_response
		SELECT dfr.id
			, dfr.name
			, dfr.field_id
			, dfr.ideal_choice
			, dfr.response_sort_order
			, dfr.active as status
		FROM dg_fields dgf
		JOIN dg_field_responses dfr ON dgf.id = dfr.field_id
		JOIN master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		WHERE dgf.datagrid_id = @datagridId and dgf.status = 1
		--dg_field_codid
		SELECT dfc.[id]
			, dfc.[suspect_icd10]
			, mi.code AS suspect_code
			, mi.description AS suspect_description
			, dfc.[field_id]
			, dfc.[field_type_id]
			, dfc.[trigger_type]
			, dfc.[trigger_match]
			, dfc.[trigger_range_min]
			, dfc.[trigger_range_max]
			, dfc.[qualifier_value]
			, dfc.[text_value]
		FROM dg_field_codes dfc
		JOIN master_icd mi ON dfc.[suspect_icd10] = mi.id
		JOIN dg_fields dgf ON dfc.field_id = dgf.id and dgf.status = 1
		JOIN master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		WHERE dgf.datagrid_id = @datagridId
		--dg_field_cpt_codes
		SELECT dfc.[id]
			, dfc.[cpt_code_id]
			, mi.code AS cpt_code
			, mi.description AS cpt_description
			, dfc.[field_id]
			, dfc.[field_type_id]
			, dfc.[trigger_type]
			, dfc.[trigger_match]
			, dfc.[trigger_range_min]
			, dfc.[trigger_range_max]
			, dfc.[qualifier_value]
			, dfc.[text_value]
		FROM dg_field_cpt_code as dfc
		JOIN master_cpt mi ON dfc.[cpt_code_id] = mi.id
		JOIN dg_fields dgf ON dfc.field_id = dgf.id and dgf.status = 1
		JOIN master_dg_field_types mdf ON dgf.field_type_id = mdf.id and mdf.active = 1
		WHERE dgf.datagrid_id = @datagridId
	END
END