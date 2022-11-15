CREATE PROCEDURE [dbo].[SP_Product_Add]
    @Name NVARCHAR(50)  , 
    @CountP INT  , 
    @Price  DECIMAL 
  
AS
begin
	insert into [dbo].[Product]
	       (Name,CountP,Price,DateTimeUpdate)
     values(@Name,@CountP,@Price,getdate())
     select @@IDENTITY  
 end
