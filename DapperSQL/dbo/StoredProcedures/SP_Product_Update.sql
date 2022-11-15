CREATE PROCEDURE [dbo].[SP_Product_Update]
	@Id int ,
	@Name NVARCHAR(50)  , 
    @CountP INT  , 
    @Price  DECIMAL ,
	@DateTimeUpdate DATETIME2(0)
AS
Begin
	update  [dbo].[Product]
	set 
	 Name=@Name
    ,CountP =@CountP 
	,Price  =@Price 
	,DateTimeUpdate=@DateTimeUpdate
	where Id=@Id
	 SELECT	  @@rowcount
end