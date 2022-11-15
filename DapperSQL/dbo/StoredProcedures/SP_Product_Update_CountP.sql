CREATE PROCEDURE [dbo].[SP_Product_Update_CountP]
	@Id int , 
    @CountP INT   
    
AS
Begin
	update  [dbo].[Product]
	set 
	 CountP =@CountP 
     where Id=@Id

	 SELECT	  @@rowcount
end