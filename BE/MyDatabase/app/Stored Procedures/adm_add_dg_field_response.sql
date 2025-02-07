create   PROCEDURE [app].[adm_add_dg_field_response] (
	@responsexml XML
	,@loggedin_user_id INT
	)
AS
BEGIN
	BEGIN TRY
		IF @responsexml IS NOT NULL
		BEGIN
			IF Object_id('tempdb..#tempDgFieldResponse') IS NOT NULL
				DROP TABLE #tempDgFieldResponse

			IF @responsexml IS NOT NULL
			BEGIN
				SELECT t.n.value('id[1]', 'int') AS id
					,t.n.value('name[1]', 'nvarchar(100)') AS name
					,t.n.value('field_id[1]', 'int') AS field_id
					,t.n.value('ideal_choice[1]', 'bit') AS ideal_choice
					,t.n.value('response_sort_order[1]', 'int') AS response_sort_order
					,t.n.value('status[1]', 'bit') AS active
				INTO #tempDgFieldResponse
				FROM @responsexml.nodes('/DgFieldResponse/Response') AS t(n)

				UPDATE t1
				SET t1.name = t2.name
					,t1.field_id = t2.field_id
					,t1.ideal_choice = t2.ideal_choice
					,t1.response_sort_order = t2.response_sort_order
					,t1.modified_datetime = GETDATE()
					,t1.modified_by = @loggedin_user_id
					,t1.active = t2.active
				FROM [dg_field_responses] t1
				INNER JOIN #tempDgFieldResponse t2 ON t1.id = t2.id
				WHERE t1.field_id = t2.field_id
					AND t2.id <> 0

				INSERT INTO [dg_field_responses] (
					name
					,field_id
					,ideal_choice
					,response_sort_order
					,created_datetime
					,created_by
					,active
					)
				SELECT name
					,field_id
					,ideal_choice
					,response_sort_order
					,GETDATE()
					,@loggedin_user_id
					,1
				FROM #tempDgFieldResponse
				WHERE id = 0

				SELECT SCOPE_IDENTITY() AS Id
					,200 AS STATUS
					,'Response saved successfully' AS Message
					,'' AS ErrorDetail
			END
			ELSE
			BEGIN
				SELECT 0 AS Id
					,500 AS STATUS
					,'No response to save' AS Message
					,'Response should be empty' AS ErrorDetail
			END
		END
	END TRY

	BEGIN CATCH
		SELECT 0 AS Id
			,500 AS STATUS
			,error_message() AS Message
			,error_message() AS ErrorDetail
	END CATCH
END