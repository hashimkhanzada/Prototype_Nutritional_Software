﻿CREATE PROCEDURE [dbo].[spUser_All]
AS
begin

	set nocount on;

	select [Id], [UserName], [Email], [Height], [Weight], [Age], [FirstName], [LastName], Gender, ActivityLevel, MedicalConditions
	from dbo.[User];

end