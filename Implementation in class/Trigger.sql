create table orders
(orderID int primary key,
customerID int,
orderDate date)

create table auditOrder(
audit_ID int primary key,
order_ID int,
customer_ID int,
order_date date,
audit_date date,
audit_information datetime default getdate());

select* from orders
select * from auditOrder

--Example for trigger (insert)

CREATE TRIGGER trgInsertOrder
on orders
after insert
as
begin
declare @auditInfo nvarchar(1000)
set @auditInfo='Data Inserted'
insert into auditOrder(order_ID,order_date,customer_ID,audit_information)
select orderID,customerID,orderDate,@auditInfo
from inserted
end

insert into orders values(1001,32,'8-10-2024')
insert into orders values(1002,41,'8-8-2024')
