CREATE TRIGGER trgInsertMaterial ON [dbo].[Material] 
FOR INSERT
AS
	

DECLARE @maxId int =0
select @maxId= ISNULL(max(codeId),0) from dbo.Material 

update dbo.Material set code=FORMAT(@maxid+1,  'KC/MAT/00000'),codeid=@maxId+1
from dbo.Material e, inserted
 where e.id= inserted.Id


	PRINT 'INSERT trigger fired.'
GO