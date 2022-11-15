/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (select 1 from [dbo].[Product])
begin
insert into  [dbo].[Product]
(Name,CountP,Price,DateTimeUpdate) 
 values ('book1',12,1200,getdate()),
        ('book2',14,1400,getdate()),
         ('book3',16,1600,getdate());

end