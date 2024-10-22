-- creating userdefined stored procedure
create procedure uspDisplayMessage
As
Begin
print'Welcome to Bikestores DB'
end

--executing userdefined stored procedure
exec uspDisplayMessage

--executing system stored procedure 
exec sp_databases

--Alter Stored Procedure 
--sytanx
Alter Procedure Procedurename 
as 
begin
select Productname, modelyear,listPrice from tablename --initially only 2 columns selected but here 3 columns are selected  
end 

--stored procedures with parameter 
create procedure upsFindProducts(@modelyear int)
as 
begin
select * from production.products where model_year=@modelyear
end
upsFindProducts 2019

--with multiple paramters 
CREATE PROC uspFindProdcutsbyRange(@minPrice decimal,@maxPrice decimal)
AS
BEGIN
SELECT * from production.products where 
list_price>=@minPrice AND 
list_price<=@maxPrice
END;

uspFindProdcutsbyRange 100,3000

--using named Parameter

uspFindProdcutsbyRange 
@maxPrice=12000,
@minPrice=5000

--Optional parameter 
CREATE PROC uspFindProductsByName
(@minPrice as decimal =2000,@maxPrice decimal,@name as varchar(max))
AS
BEGIN
select * from production.products where list_price>=@minPrice and 
list_price<=@maxPrice
and 
product_name like '%'+@name+'%'
END

uspFindProductsByName 100,1000,'Sun'
uspFindProductsByName @maxPrice=3000,@name='Trek'

--output parameter
CREATE PROCEDURE uspFindProductCountByModelYear
(@modelyear int,
@productCount int OUTPUT
)
AS
BEGIN
select Product_name,list_Price 
from production.products 
WHERE 
model_year=@modelyear

select @productCount=@@ROWCOUNT
END


DECLARE @count int;

EXEC  uspFindProductCountByModelYear @modelyear=2016,@productCount=@count OUT;;

select @count as 'Number of Products Found';


--stored procedure inside another stored procedure 
--procedure 1
create procedure usp_GetAllCustomers
as
begin
select * from sales.customers
end
usp_GetAllCustomers
--procedure 2
create  procedure usp_GetCustomerOrders (@customerID int)
as
begin
select * from sales.orders where customer_id=@customerID
end
usp_GetCustomerOrders 1
--storing procedure 1 and 2 another stored procedure 
create procedure Usp_GetCustomerData(@customerID int)
as
begin
exec usp_GetAllCustomers;
exec usp_GetCustomerOrders @customerID;
end
Usp_GetCustomerData 1