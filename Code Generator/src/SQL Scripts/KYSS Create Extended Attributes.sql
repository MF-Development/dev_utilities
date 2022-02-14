USE [Millennium]
GO

/****** Object:  StoredProcedure [dbo].[KYSS_AddExtendedAttribute]    Script Date: 10/02/2009 17:10:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KYSS_AddExtendedAttribute]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[KYSS_AddExtendedAttribute]
GO

/****** Object:  StoredProcedure [dbo].[KYSS_CreateDefaultExtendedAttributes]    Script Date: 10/02/2009 17:10:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KYSS_CreateDefaultExtendedAttributes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[KYSS_CreateDefaultExtendedAttributes]
GO

/****** Object:  StoredProcedure [dbo].[KYSS_CreateExtendedAttributes]    Script Date: 10/02/2009 17:10:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KYSS_CreateExtendedAttributes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[KYSS_CreateExtendedAttributes]
GO

/****** Object:  StoredProcedure [dbo].[KYSS_DropAllExtendedAttributes]    Script Date: 10/02/2009 17:10:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KYSS_DropAllExtendedAttributes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[KYSS_DropAllExtendedAttributes]
GO

USE [Millennium]
GO

/****** Object:  StoredProcedure [dbo].[KYSS_AddExtendedAttribute]    Script Date: 10/02/2009 17:10:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[KYSS_AddExtendedAttribute]
(
	@TableName varchar(100)
	,@ColumnName varchar(100)
	,@AttributeName varchar(100)
	,@AttributeValue varchar(200)
	,@OverwriteExisting bit = 0
)
AS

IF (@OverwriteExisting = 1)
BEGIN
	IF EXISTS(SELECT ex.name FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'TABLE', @TableName, 'COLUMN', @ColumnName) as ex WHERE ex.name = @AttributeName )
	BEGIN
		exec sp_dropextendedproperty @AttributeName, 'user', 'dbo', 'TABLE', @TableName, 'COLUMN', @ColumnName
	END	
END
		
IF NOT EXISTS(SELECT ex.name FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'TABLE', @TableName, 'COLUMN', @ColumnName) as ex WHERE ex.name = @AttributeName )
BEGIN
	EXEC sp_addextendedproperty @AttributeName, @AttributeValue, 'SCHEMA', N'dbo', 'TABLE', @TableName, 'COLUMN', @ColumnName
END



GO

/****** Object:  StoredProcedure [dbo].[KYSS_CreateDefaultExtendedAttributes]    Script Date: 10/02/2009 17:10:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[KYSS_CreateDefaultExtendedAttributes]
(
	@tableName nvarchar(50),
	@excludedFields nvarchar(max),	
	@overwriteExisting bit = 0
)

AS		

DECLARE 
	@column_name nvarchar(100),
	@data_type nvarchar(100),
	@column_default nvarchar(100)		

DECLARE curs CURSOR FOR
	SELECT 
		column_name
		,data_type
		,column_default
	FROM
		information_schema.columns
	WHERE  
		table_name = @tableName AND
		data_type in (
			'bigint',
			'int',
			'smallint',
			'tinyint',
			'bit',
			'decimal',
			'numeric',
			'money',
			'smallmoney',
			'float',
			'real')		
OPEN curs
FETCH NEXT FROM curs 
INTO @column_name, @data_type, @column_default
WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE @hasExtendedProperty integer
	DECLARE @defaultValue nvarchar(25)

	--IF THIS IS AN EXCLUDED FIELD
	IF (@column_name in (SELECT [value] FROM dbo.CSVListToTable(@excludedFields, ','))) 
	BEGIN
		exec KYSS_AddExtendedAttribute @tablename, @column_name, 'KYSS_Excluded', 'true', @overwriteExisting
	END
	ELSE 
	BEGIN
		/* Begin Required/Defaults */
		IF (@data_type = 'bit') BEGIN
			SET @defaultValue = 'bool.FalseString'
			IF (@column_default = '((1))') BEGIN
				SET @defaultValue = 'bool.TrueString'
			END
		END		
		ELSE
			SET @defaultValue = '"0"'

		exec KYSS_AddExtendedAttribute @tablename, @column_name, 'KYSS_Default_Value', @defaultValue, @overwriteExisting
		exec KYSS_AddExtendedAttribute @tablename, @column_name, 'KYSS_Is_Required', 'true', @overwriteExisting

	END
			
  FETCH NEXT FROM curs INTO @column_name, @data_type, @column_default
END
CLOSE curs
DEALLOCATE curs

GO

/****** Object:  StoredProcedure [dbo].[KYSS_CreateExtendedAttributes]    Script Date: 10/02/2009 17:10:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[KYSS_CreateExtendedAttributes] (
	@tablename varchar(100)
	,@includeDefaults bit = 0
	,@excludedFields nvarchar(max) = null
	,@overwriteExisting bit =0
)
AS 

--DELETE all previously added attributes
IF (@overwriteExisting = 1)
BEGIN
	exec KYSS_DropAllExtendedAttributes @tablename
END

DECLARE @columnname sysname, @kyss_display_caption sysname

DECLARE Column_Cursor CURSOR FOR
	SELECT TABLE_NAME,
	COLUMN_NAME,
	dbo.ProperColumnName(COLUMN_NAME) AS KYSS_Display_Caption
	FROM INFORMATION_SCHEMA.COLUMNS
	WHERE TABLE_NAME = @tableName

OPEN Column_Cursor

FETCH NEXT FROM Column_Cursor INTO @tablename, @columnname, @kyss_display_caption
WHILE @@FETCH_STATUS = 0
	BEGIN
		--signature: AddKYSSExtendedProperty (@TableName varchar(100),@ColumnName varchar(100),@AttributeName varchar(100),@AttributeValue varchar(200))
		exec KYSS_AddExtendedAttribute @tablename, @columnname, 'KYSS_Display_Caption', @kyss_display_caption, @overwriteExisting
		FETCH NEXT FROM Column_Cursor INTO @tablename, @columnname, @kyss_display_caption
	END
CLOSE Column_Cursor
DEALLOCATE Column_Cursor

-- ADD DEFAULTS --
IF (@includeDefaults = 1)
BEGIN
	exec KYSS_CreateDefaultExtendedAttributes @tablename, @excludedFields, @overwriteExisting
END

SELECT ex.objname as column_name,  
ex.name as attribute_name, 
ex.value as attribute_value 
FROM
fn_listextendedproperty(NULL, 'user', 'dbo', 'table', @tablename, 'column', null) AS ex 
order by column_name, attribute_name


GO

/****** Object:  StoredProcedure [dbo].[KYSS_DropAllExtendedAttributes]    Script Date: 10/02/2009 17:10:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[KYSS_DropAllExtendedAttributes] (
	@tablename varchar(100)
)
AS 

DECLARE @columnname sysname

DECLARE Column_Cursor CURSOR FOR
	SELECT TABLE_NAME,
	COLUMN_NAME
	FROM INFORMATION_SCHEMA.COLUMNS
	WHERE TABLE_NAME = @tableName

OPEN Column_Cursor

FETCH NEXT FROM Column_Cursor INTO @tablename, @columnname
WHILE @@FETCH_STATUS = 0
	BEGIN
		IF EXISTS(SELECT ex.name FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'TABLE', @TableName, 'COLUMN', @ColumnName) as ex WHERE ex.name = 'KYSS_Display_Caption' )
		BEGIN
			exec sp_dropextendedproperty 'KYSS_Display_Caption', 'user', 'dbo', 'TABLE', @tablename, 'COLUMN', @columnname
		END	

		IF EXISTS(SELECT ex.name FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'TABLE', @TableName, 'COLUMN', @ColumnName) as ex WHERE ex.name = 'KYSS_Default_Value' )
		BEGIN
			exec sp_dropextendedproperty 'KYSS_Default_Value', 'user', 'dbo', 'TABLE', @tablename, 'COLUMN', @columnname
		END	

		IF EXISTS(SELECT ex.name FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'TABLE', @TableName, 'COLUMN', @ColumnName) as ex WHERE ex.name = 'KYSS_Is_Required' )
		BEGIN
			exec sp_dropextendedproperty 'KYSS_Is_Required', 'user', 'dbo', 'TABLE', @tablename, 'COLUMN', @columnname
		END	

		IF EXISTS(SELECT ex.name FROM fn_listextendedproperty(NULL, 'user', 'dbo', 'TABLE', @TableName, 'COLUMN', @ColumnName) as ex WHERE ex.name = 'KYSS_IsExcluded' )
		BEGIN
			exec sp_dropextendedproperty 'KYSS_Excluded', 'user', 'dbo', 'TABLE', @tablename, 'COLUMN', @columnname
		END	

		FETCH NEXT FROM Column_Cursor INTO @tablename, @columnname
	END
CLOSE Column_Cursor
DEALLOCATE Column_Cursor


SELECT ex.objname as column_name,  
ex.name as attribute_name, 
ex.value as attribute_value 
FROM
fn_listextendedproperty(NULL, 'user', 'dbo', 'table', @tablename, 'column', null) AS ex 
order by column_name, attribute_name


GO


