CREATE TRIGGER trgInsertEmployee ON [dbo].[Employee] 
FOR INSERT
AS
	

DECLARE @maxId int =0
select @maxId= ISNULL(max(codeId),0) from dbo.Employee 

update dbo.Employee set code=FORMAT(@maxid+1,  'KC/EMP/00000'),codeid=@maxId+1
from dbo.Employee e, inserted
 where e.id= inserted.Id


	PRINT 'INSERT trigger fired.'
GO