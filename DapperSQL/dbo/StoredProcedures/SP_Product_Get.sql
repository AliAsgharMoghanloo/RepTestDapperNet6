CREATE PROCEDURE [dbo].[SP_Product_Get]
  @Id int
AS
Begin
	SELECT * from [dbo].[Product]
	where Id=@Id
end
