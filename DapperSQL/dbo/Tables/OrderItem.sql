CREATE TABLE [dbo].[OrderItem]
(
	[Id] INT NOT NULL  Identity, 
    [OrderId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quentity] INT NOT NULL, 
    [Price] DECIMAL NOT NULL, 
    CONSTRAINT [PK_OrderItem] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([Id]), 
    CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([Id]) ,
    
)
go
CREATE UNIQUE NONCLUSTERED INDEX [IX_OrderItems_OrderId_ProductId] ON [dbo].[OrderItem]
( 
 [OrderId] asc ,
 [ProductId] asc 
	 
)
 

GO
