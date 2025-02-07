CREATE   PROCEDURE AddFieldCalculation
    @calc_field1 INT,
    @calc_field1_transformation VARCHAR(50),
    @calc_field2 INT,
    @mid_operator VARCHAR(50),
    @calc_field2_transformation VARCHAR(50),
    @enable_post_operator BIT,
    @post_operator VARCHAR(50),
    @post_operator_val INT,
    @field_id INT,
    @created_datetime DATETIME,
    @created_by VARCHAR(50),
    @modified_datetime DATETIME,
    @modified_by VARCHAR(50)

AS
BEGIN
  DECLARE @StatusCode INT;
    DECLARE @ResponseMessage NVARCHAR(255);
    BEGIN TRY
        -- Insert statement to add a new record into dg_field_calculations
        INSERT INTO dg_field_calculations (
            calc_field1,
            calc_field1_transformation,
            calc_field2,
            mid_operator,
            calc_field2_transformation,
            enable_post_operator,
            post_operator,
            post_operator_val,
            field_id,
            created_datetime,
            created_by,
            modified_datetime,
            modified_by
        ) VALUES (
            @calc_field1,
            @calc_field1_transformation,
            @calc_field2,
            @mid_operator,
            @calc_field2_transformation,
            @enable_post_operator,
            @post_operator,
            @post_operator_val,
            @field_id,
            @created_datetime,
            @created_by,
            @modified_datetime,
            @modified_by
        );

        -- Set the output parameters for success
        SET @StatusCode = 200;
        SET @ResponseMessage = 'Record inserted successfully.';
    END TRY
    BEGIN CATCH
        -- Set the output parameters for failure
        SET @StatusCode = 404;
        SET @ResponseMessage = ERROR_MESSAGE();
    END CATCH;
	  SELECT @StatusCode AS Status, @ResponseMessage AS Message;
END;