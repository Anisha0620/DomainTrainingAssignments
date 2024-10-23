create database Assignment

--------7) Create a simple trigger to update the Stock table whenever a new order is placed.

CREATE TABLE Stock (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Quantity INT
);

CREATE TABLE Orders1 (
    OrderID INT PRIMARY KEY,
    ProductID INT,
    QuantityOrdered INT,
    FOREIGN KEY (ProductID) REFERENCES Stock(ProductID)
);


INSERT INTO Stock (ProductID, ProductName, Quantity)
VALUES 
(1, 'Product A', 100),
(2, 'Product B', 150);


INSERT INTO Orders1(OrderID, ProductID, QuantityOrdered)
VALUES (1, 1, 10);

CREATE TRIGGER UpdateStock
ON Orders1
AFTER INSERT
AS
BEGIN
    UPDATE Stock
    SET Quantity = Quantity - inserted.QuantityOrdered
    FROM inserted
    WHERE Stock.ProductID = inserted.ProductID;
END;

select * from Orders1
select * from Stock
INSERT INTO Orders1(OrderID, ProductID, QuantityOrdered)
VALUES (2, 1, 5);

----------- 8) Simple Trigger to Prevent Deletion of a Customer with Orders

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100)
);

INSERT INTO Customers (CustomerID, CustomerName)
VALUES (1, 'Anisha');

CREATE TRIGGER PreventCustomerDelete
ON Customers
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (SELECT * FROM Orders WHERE CustomerID IN (SELECT CustomerID FROM DELETED))
    BEGIN
        PRINT 'Cannot delete customer with existing orders.';
    END
    ELSE
    BEGIN
        DELETE FROM Customers WHERE CustomerID IN (SELECT CustomerID FROM DELETED);
    END
END;

select * from Customers

-----------------9) Create Employee and Employee_Audit tables, and insert some test data.
CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(100),
    Salary DECIMAL(10,2)
);

CREATE TABLE Employee_Audit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    OldSalary DECIMAL(10, 2),
    NewSalary DECIMAL(10, 2),
    ChangeDate DATETIME DEFAULT GETDATE()  
);

INSERT INTO Employee (EmployeeID, EmployeeName, Salary)
VALUES (1, 'Sakthivel', 50000);

CREATE TRIGGER LogEmployeeChanges
ON Employee
AFTER UPDATE
AS
BEGIN
    INSERT INTO Employee_Audit (EmployeeID, OldSalary, NewSalary)
    SELECT 
        i.EmployeeID,            
        d.Salary AS OldSalary,   
        i.Salary AS NewSalary     
    FROM 
        deleted d
    JOIN 
        inserted i ON d.EmployeeID = i.EmployeeID;
END;

UPDATE Employee
SET Salary = 55000
WHERE EmployeeID = 1;

select * from Employee
select * from Employee_Audit

---------------------10)Create Room and Bookings Tables, and a transaction to book a room.
CREATE TABLE Room (
    RoomID INT PRIMARY KEY,
    RoomType VARCHAR(50),
    Availability BIT  
);

CREATE TABLE Booking (
    BookingID INT PRIMARY KEY,
    RoomID INT,
    CustomerName VARCHAR(100),
    CheckInDate DATETIME,
    CheckOutDate DATETIME
);
INSERT INTO Room (RoomID, RoomType, Availability)
VALUES (1, 'Single', 1),  
       (2, 'Double', 0);   

BEGIN TRANSACTION;
DECLARE @RoomID INT = 1;  
DECLARE @CustomerName VARCHAR(100) = 'Godlina';  
IF (SELECT Availability FROM Room WHERE RoomID = @RoomID) = 1
BEGIN
    INSERT INTO Booking (BookingID, RoomID, CustomerName, CheckInDate, CheckOutDate)
    VALUES (1, @RoomID, @CustomerName, '2024-10-25', '2024-10-30');
    UPDATE Room
    SET Availability = 0
    WHERE RoomID = @RoomID;
	COMMIT TRANSACTION; 
END
ELSE
BEGIN
    PRINT 'Room is not available.';
    ROLLBACK TRANSACTION;  
END;
select * from Room
select * from Booking