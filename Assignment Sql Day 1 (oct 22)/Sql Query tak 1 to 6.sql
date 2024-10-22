----1.Create a stored procedure that retrieves a list of all customers who have purchased a specific product.consider below tables Customers, Orders,Order_items and ProductsCreate a stored procedure,it should return a list of all customers who have purchased the specified product,  including customer details like CustomerID, CustomerName, and PurchaseDate. The procedure should take a ProductID as an input parameter.--

CREATE PROCEDURE uspGetCustomersByProductIden
    @ProductID INT
AS
BEGIN
    SELECT 
        customers.customer_id AS CustomerID,
        customers.first_name AS FirstName,
        customers.last_name AS LastName,
        orders.order_date AS PurchaseDate
    FROM 
        sales.customers AS customers, 
        sales.orders AS orders, 
        sales.order_items AS order_items
    WHERE 
        customers.customer_id = orders.customer_id
        AND orders.order_id = order_items.order_id
        AND order_items.product_id = @ProductID;
END;
execute uspGetCustomersByProductIden @ProductID =20;

--2.Create the Department Table and department table and inserting dummy datas 
CREATE TABLE Department (
    ID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);

INSERT INTO Department (ID, Name) VALUES
(1, 'Human Resources'),
(2, 'Information Technology'),
(3, 'Marketing'),
(4, 'Sales'),
(5, 'Finance');

CREATE TABLE Employee (
    ID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Gender VARCHAR(10) NOT NULL,
    DOB DATE NOT NULL,
    DeptId INT,
    FOREIGN KEY (DeptId) REFERENCES Department(ID)
);

INSERT INTO Employee (ID, Name, Gender, DOB, DeptId) VALUES
(1, 'Vijayasri Chakiri', 'Female', '1990-04-01', 1),
(2, 'Purusothaman N', 'Male', '1985-05-02', 2),
(3, 'Aniket Barua', 'Male', '1992-06-03', 3),
(4, 'Karthi', 'Male', '1991-07-04', 4),
(5, 'Thiyanesh Karthickeyan', 'Male', '1990-08-05', 5),
(6, 'Narendra Kumar', 'Male', '1988-09-06', 1),
(7, 'Yash Kolhe', 'Male', '1993-10-07', 2),
(8, 'Varun', 'Male', '1989-11-08', 3),
(9, 'Manan', 'Male', '1992-12-09', 4),
(10, 'Srishti Seth', 'Female', '1995-01-10', 5),
(11, 'Aryan Rastogi', 'Male', '1994-02-11', 1),
(12, 'Rahul Puri', 'Male', '1993-03-12', 2),
(13, 'Srikeerthu', 'Female', '1991-04-13', 3),
(14, 'Anisha Kabeer', 'Female', '1995-05-14', 4),
(15, 'Srinithi', 'Female', '1990-06-15', 5),
(16, 'Prateek Sohani', 'Male', '1987-07-16', 1),
(17, 'Suyash', 'Male', '1992-08-17', 2),
(18, 'Tejas Pantoji', 'Male', '1990-09-18', 3),
(19, 'Vivek Handa', 'Male', '1989-10-19', 4),
(20, 'Varsha Jithendiran', 'Female', '1993-11-20', 5),
(21, 'Tarun S', 'Male', '1995-12-21', 1),
(22, 'Hritik Nagar', 'Male', '1991-01-22', 2),
(23, 'Raj', 'Male', '1994-02-23', 3),
(24, 'Daksh Yadav', 'Male', '1993-03-24', 4),
(25, 'Sanskar Kakde', 'Male', '1990-04-25', 5),
(26, 'Anand Salokiya', 'Male', '1988-05-26', 1),
(27, 'Tanay Geet', 'Male', '1992-06-27', 2),
(28, 'Adarsh Sharma', 'Male', '1990-07-28', 3),
(29, 'Sneha Dave', 'Female', '1995-08-29', 4),
(30, 'Sonam Patel', 'Female', '1993-09-30', 5),
(31, 'Srinithya N', 'Female', '1994-10-31', 1);

--a)Create a procedure to update the Employee details in the Employee table based on the Employee id.
CREATE PROCEDURE uspUpdateEmployeeDetails
    @EmployeeID INT,
    @EmployeeName VARCHAR(100),
    @EmployeeGender VARCHAR(10),
    @EmployeeDOB DATE,
    @DeptID INT
AS
BEGIN
    UPDATE Employee
    SET 
        Name = @EmployeeName,
        Gender = @EmployeeGender,
        DOB = @EmployeeDOB,
        DeptId = @DeptID
    WHERE 
        ID = @EmployeeID;
END;
EXECUTE uspUpdateEmployeeDetails @EmployeeID = 12,@EmployeeName = 'Sejal',@EmployeeGender = 'Female',@EmployeeDOB = '1990-04-01',@DeptID = 2;

--b) Create a Procedure to get the employee information bypassing the employee gender and department id from the Employee table
CREATE PROCEDURE uspGetEmployeesByGenderAndDepartment
    @EmployeeGender VARCHAR(10),
    @DeptID INT
AS
BEGIN
    SELECT 
        ID AS EmployeeID,
        Name AS EmployeeName,
        Gender AS EmployeeGender,
        DOB AS EmployeeDOB,
        DeptId AS DepartmentID
    FROM 
        Employee
    WHERE 
        Gender = @EmployeeGender
        AND DeptId = @DeptID;
END;
EXECUTE uspGetEmployeesByGenderAndDepartment @EmployeeGender = 'Female',@DeptID = 1;


--c)Create a Procedure to get the Count of Employee based on Gender(input)
create PROCEDURE uspGetEmployeesAndCountByGender
 @EmployeeGender VARCHAR(max)
AS
BEGIN
    SELECT 
        @EmployeeCount = COUNT(*)
    FROM 
        Employee
    WHERE 
        Gender = @EmployeeGender;
    SELECT 
        @EmployeeCount AS EmployeeCount;
        ID AS EmployeeID,
        Name AS EmployeeName,
        Gender AS EmployeeGender,
        DOB AS EmployeeDOB,
        DeptId AS DepartmentID
    FROM 
        Employee
    WHERE 
        Gender = @EmployeeGender;
END;
DECLARE @EmployeeCount INT;
EXECUTE uspGetEmployeesAndCountByGender @EmployeeGender = 'Male';


--3.Create a user Defined function to calculate the TotalPrice based on productid and Quantity Products Table
CREATE FUNCTION CalculateTotalPrice (
    @ProductID INT,
    @Quantity INT
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @TotalPrice DECIMAL(10, 2);

    SELECT @TotalPrice = list_price * @Quantity 
    FROM production.products 
    WHERE product_id = @ProductID;

    RETURN @TotalPrice;
END;

SELECT dbo.CalculateTotalPrice(1, 5) as TotalPrice;

--4) create a function that returns all orders for a specific customer, including details such as OrderID, OrderDate, and the total amount of each order.
CREATE FUNCTION GetCustomerOrders (
    @CustomerID INT
)
RETURNS TABLE
AS
RETURN 
(
    SELECT 
        sales.orders.order_id,
        sales.orders.order_date,
        SUM(sales.order_items.quantity * sales.order_items.list_price * (1 - sales.order_items.discount / 100)) AS TotalAmount
    FROM sales.orders 
    JOIN sales.order_items ON sales.orders.order_id = sales.order_items.order_id
    WHERE sales.orders.customer_id = @CustomerID
    GROUP BY sales.orders.order_id, sales.orders.order_date
);
SELECT * FROM GetCustomerOrders(25); 

--5.create a Multistatement table valued function that calculates the total sales for each product, considering quantity and price.
 
CREATE FUNCTION CalculateTotalSalesPerProduct ()
RETURNS @SalesTable TABLE (
    ProductID INT,
    TotalSales DECIMAL(10, 2)
)
AS
BEGIN
    INSERT INTO @SalesTable (ProductID, TotalSales)
    SELECT 
        production.products.product_id,
        SUM(sales.order_items.quantity * sales.order_items.list_price * (1 - sales.order_items.discount / 100))
    FROM production.products
    LEFT JOIN sales.order_items ON production.products.product_id = sales.order_items.product_id
    GROUP BY 
        production.products.product_id;

    RETURN;
END;

SELECT * FROM CalculateTotalSalesPerProduct();

--6.)create a  multi-statement table-valued function that lists all customers along with the total amount they have spent on orders
CREATE FUNCTION CalculateTotalSpentByCustomers ()
RETURNS @CustomerSpending TABLE (
    CustomerID INT,
    TotalSpent DECIMAL(10, 2)
)
AS
BEGIN
    INSERT INTO @CustomerSpending (CustomerID, TotalSpent)
    SELECT customer_id,
           (SELECT SUM(quantity * list_price) 
            FROM sales.orders, sales.order_items 
            WHERE sales.orders.order_id = sales.order_items.order_id 
            AND sales.orders.customer_id = sales.customers.customer_id) AS TotalSpent
    FROM sales.customers;

    RETURN;
END;

SELECT * FROM CalculateTotalSpentByCustomers();

