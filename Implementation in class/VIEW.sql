---VIEWS To return employees working in IT
CREATE VIEW vwEmployeeView AS
SELECT EmployeeID, name, email, department
FROM Employee2
WHERE department = 'IT';

select * from vwEmployeeView

--Inserting values with viewcreated
INSERT INTO vwEmployeeView (EmployeeID, name, email, department)
VALUES (11, 'Sakthivel', 'sakthivel@gmail.com', 'Director');

--update value with viewcreated (but updation will be done to the data where dept=IT bcoz it is the condition given in view)

UPDATE vwEmployeeView
SET name = 'Anisha'
WHERE EmployeeID = 3;

select * from Employee2

update vwEmployeeView 
SET email='anisha@gmail.com'
where EmployeeID=3;

--query to see what code we have used to create view
sp_helptext vwEmployeeView