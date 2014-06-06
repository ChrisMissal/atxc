IF EXISTS (select * from dbo.sysobjects where id = object_id(N'PersonView') and OBJECTPROPERTY(id, N'IsView') = 1)
BEGIN
    DROP VIEW PersonView
END
GO

CREATE VIEW [dbo].[PersonView]
AS
SELECT p.[Name], p.[Email], p.[Slug], p.[Location]
FROM dbo.Person p
WHERE p.[Approved] IS NOT NULL AND p.[Deleted] IS NULL
GO
