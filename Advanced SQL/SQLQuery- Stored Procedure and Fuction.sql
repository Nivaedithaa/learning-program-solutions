CREATE DATABASE Company;

USE Company;

CREATE TABLE Departments ( DepartmentID INT PRIMARY KEY, DepartmentName VARCHAR(100) );

CREATE TABLE Employees 
( EmployeeID INT PRIMARY KEY, FirstName VARCHAR(50), 
LastName VARCHAR(50), DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
Salary DECIMAL(10,2), JoinDate DATE );

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES (1, 'HR'), (2, 'Finance'), (3, 'IT'), (4, 'Marketing');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES (1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'), 
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');

--Exercise 1: Create a Stored Procedure
CREATE PROCEDURE sp_employeedetail @DepartmentID int
as
begin
	select EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
	from Employees
	where DepartmentID = @DepartmentID;
end;

EXEC sp_employeedetail @DepartmentID = 4;

CREATE PROCEDURE sp_InsertEmployees @EmployeeID INT, @FirstName VARCHAR(50), 
@LastName VARCHAR(50), 
@DepartmentID INT, @Salary DECIMAL(10,2),
@JoinDate DATE 
AS 
BEGIN 
INSERT INTO Employees (EmployeeID,FirstName, LastName, DepartmentID,
Salary, JoinDate) 
VALUES (@EmployeeID,@FirstName, @LastName, @DepartmentID, @Salary,
@JoinDate); 
END;

EXEC sp_InsertEmployees
@EmployeeID = 5,
@FirstName = 'Jack',
@LastName = 'Jill',
@DepartmentID = 3,
@Salary = 6500.00,
@JoinDate = '2022-12-08';

select * from Employees;

--5. SQL Exercise - Functions
--Exercise 7: Return Data from a Scalar Function

create function fn_CalculateAnnual_Salary (@EmployeeID int)
returns decimal(10,2)
as
begin
	declare @AnnualSalary decimal(10,2);

	select @AnnualSalary = Salary*12
	from Employees
	where @EmployeeID = @EmployeeID;

	return @AnnualSalary;
end;

select dbo.fn_CalculateAnnual_Salary(1) as Annual_Salary;

--to check
select salary ,salary*12 as annual from Employees
where employeeID = 1;


--Exercise 5: Return Data from a Stored Procedure

create procedure sp_EmployeeCountinEachDept @DepartmentID int
as
begin
	select count(*) as Total_Count
	from Employees
	where DepartmentID = @DepartmentID;
end;

exec sp_EmployeeCountinEachDept @DepartmentID = 2;


--Exercise 4: Execute a Stored Procedure
create procedure sp_EmployeeDetailsFromDept @DepartmentID int
as
begin
	select EmployeeID,FirstName,LastName, DepartmentID,Salary,JoinDate
	from Employees
	where DepartmentID = @DepartmentID;
end;

exec sp_EmployeeDetailsFromDept @DepartmentID = 3;


select * from Employees;


