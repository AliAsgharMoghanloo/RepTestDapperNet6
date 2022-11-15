CREATE PROCEDURE [dbo].[SP_Product_DeleteItems]
	  @Id int
AS
---try	
---tran 
	delete from [dbo].[Product]
	where Id=@Id
   SELECT	  @@rowcount
RETURN 0
