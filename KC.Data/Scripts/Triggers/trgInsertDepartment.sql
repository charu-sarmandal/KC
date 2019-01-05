CREATE TRIGGER trgInsertDepartment ON [dbo].[Department] 
FOR INSERT
AS
	

DECLARE @maxId int =0
select @maxId= ISNULL(max(codeId),0) from dbo.[Department] 

update dbo.[Department] set code=FORMAT(@maxid+1,  'KC/DEPT/00000'),codeid=@maxId+1
from dbo.[Department] e, inserted
 where e.id= inserted.Id


	PRINT 'INSERT trigger fired.'
GO