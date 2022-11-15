CREATE PROCEDURE [dbo].[SP_Product_DeleteItem]
	  @Id int
AS
	delete from [dbo].[Product]
	where Id=@Id
   SELECT	  @@rowcount
RETURN 0
