IF EXISTS (select * from dbo.sysobjects where id = object_id(N'PersonCategoryView') and OBJECTPROPERTY(id, N'IsView') = 1)
BEGIN
    DROP VIEW PersonCategoryView
END
GO

CREATE VIEW [dbo].[PersonCategoryView]
AS
SELECT p.[Name], p.[Email], p.[Slug], p.[Location]
FROM dbo.Person p
	INNER JOIN CategoryField c ON c.[PersonId] = p.[PersonId]
WHERE p.[Approved] IS NOT NULL AND p.[Deleted] IS NULL
GO
