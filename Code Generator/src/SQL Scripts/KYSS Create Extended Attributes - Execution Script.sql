DECLARE @TableName varchar(100)
DECLARE @IncludeDefaults bit
DECLARE @ExcludedFields nvarchar(max)
DECLARE @OverwriteExisting bit

SET @TableName = 'EInfo'  -- table to update
SET @IncludeDefaults = 1      -- 0 = false, 1 = true
SET @ExcludedFields = 'annualSalary,baseRate,lastRaiseAmount,salary'  -- comma delimited fields to exclude
SET @OverwriteExisting = 0

exec KYSS_CreateExtendedAttributes @TableName, @IncludeDefaults, @ExcludedFields, @OverwriteExisting

EXEC sp_updateextendedproperty KYSS_Display_Caption, 'Company ID', 'SCHEMA', N'dbo', 'TABLE', @TableName, 'COLUMN', 'Co'
EXEC sp_updateextendedproperty KYSS_Display_Caption, 'Employee ID', 'SCHEMA', N'dbo', 'TABLE', @TableName, 'COLUMN', 'Id'
