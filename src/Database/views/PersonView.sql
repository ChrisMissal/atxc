IF EXISTS (select * from dbo.sysobjects where id = object_id(N'PersonView') and OBJECTPROPERTY(id, N'IsView') = 1) DROP VIEW PersonView
GO

CREATE VIEW [dbo].[PersonView]
AS
SELECT Name, Email, Slug
FROM dbo.Person
WHERE Approved is not null and Deleted is null
GO
