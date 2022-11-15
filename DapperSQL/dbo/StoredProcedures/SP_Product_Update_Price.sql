CREATE PROCEDURE [dbo].[SP_Product_Update_Price]
	@Id int ,
	@Price  DECIMAL ,
	@DateTimeUpdate Datetime2(0) 
AS
Begin
	update  [dbo].[Product]
	set 
	 Price  =@Price 
	,DateTimeUpdate=@DateTimeUpdate
	where Id=@Id
	 SELECT	  @@rowcount
end