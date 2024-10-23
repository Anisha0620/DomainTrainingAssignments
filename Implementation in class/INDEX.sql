create database OrganizationDBT

----------------------------------------example for non cluster (it happens  when there is no primary key)-------------------------------------------------------------------------
CREATE TABLE Employee (
    EmployeeID INT ,
   name varchar(50),
   salary int,
   department varchar(50)
);
INSERT INTO Employee (EmployeeID, name, salary, department) VALUES
(4, 'Emma Davis', 65000, 'Finance'),
(2, 'Alice Johnson', 60000, 'Marketing'),
(7, 'James Anderson', 70000, 'Operations'),
(1, 'John Smith', 50000, 'Sales'),
(10, 'Olivia Harris', 67000, 'Legal'),
(6, 'Sophia Taylor', 58000, 'R&D'),
(3, 'David Brown', 55000, 'IT'),
(8, 'Ethan Lewis', 62000, 'Customer Service'),
(9, 'Mia Clark', 53000, 'Procurement'),
(5, 'Michael Wilson', 52000, 'HR');
 select * from Employee
 ----------To manually set as non cluster 
 CREATE NONCLUSTERED INDEX IX_Employee_ID on Employee (ID ASC)


----------------------------------------------- example for cluster (it happens with only primary key)-----------------------------------------------------
CREATE TABLE Employee1 (
    EmployeeID INT primary key,
   name varchar(50),
   salary int,
   department varchar(50)
);

INSERT INTO Employee1(EmployeeID, name, salary, department) VALUES
(5, 'Liam King', 59000, 'Marketing'),
(1, 'Emily Moore', 72000, 'Finance'),
(4, 'Benjamin Scott', 64000, 'Sales'),
(2, 'Charlotte Evans', 53000, 'HR'),
(9, 'Ava Perez', 68000, 'Legal'),
(8, 'Noah Walker', 61000, 'Operations'),
(3, 'Henry Edwards', 50000, 'IT'),
(7, 'Amelia White', 57000, 'R&D'),
(0, 'Elijah Martin', 69000, 'Procurement'),
(6, 'Lucas Thompson', 60000, 'Customer Service');

select* from Employee1
 ----------To manually set as cluster 
CREATE CLUSTERED INDEX IX_Employee_ID on Employee (ID ASC)


-------------------------------------------------------------TO create unique index------------------------------------------------------------------------------------
CREATE TABLE Employee2 (
    EmployeeID INT ,
    name VARCHAR(50),
    email VARCHAR(100),
    department VARCHAR(50)
);

INSERT INTO Employee2 (EmployeeID, name, email, department) VALUES
(1, 'John Smith', 'john.smith@example.com', 'Sales'),
(2, 'Alice Johnson', 'alice.johnson@example.com', 'Marketing'),
(3, 'David Brown', 'david.brown@example.com', 'IT'),
(4, 'Emma Davis', 'emma.davis@example.com', 'Finance'),
(5, 'Michael Wilson', 'michael.wilson@example.com', 'Human Resources'),
(6, 'Sophia Taylor', 'sophia.taylor@example.com', 'R&D'),
(7, 'James Anderson', 'james.anderson@example.com', 'Operations'),
(8, 'Ethan Lewis', 'ethan.lewis@example.com', 'Customer Service'),
(9, 'Mia Clark', 'mia.clark@example.com', 'Procurement'),
(10, 'Olivia Harris', 'olivia.harris@example.com', 'Legal');

CREATE UNIQUE INDEX idx_employee_email ON Employee2(email);

--------------------------------------------------TO CREATE UNIQUE CLUSTER INDEX
CREATE UNIQUE CLUSTERED INDEX idx_employeeID_clustered
ON Employee2 (EmployeeID);

SELECT* FROM Employee2

--------------------------------------------------TO MANUALLY CREATE UNIQUE NON-CLUSTER INDEX
CREATE UNIQUE NONCLUSTERED INDEX idx_employee_email_nonclustered
ON Employee2 (email);
