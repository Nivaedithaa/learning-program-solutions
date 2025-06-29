--Exercise 1: Ranking and Window Functions
CREATE DATABASE ProductInfoDB;

USE ProductInfoDB;

CREATE TABLE Products(
ProductID int,
ProductName varchar(50),
Category varchar(50),
Price int
);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (100,'iPhone','Electronics',1000);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (101,'Samsung Galaxy','Electronics',950);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (102,'Laptop','Electronics',20000);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (103,'Shoes','Footware',300);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (104,'Sandals','Footware',500);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (105,'Sneakers','Footware',750);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (106,'T-shirt','Fashion',300);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (107,'Jacket','Fashion',800);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (108,'Saree','Fashion',650);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (109,'Heel','Footware',1500);

INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (110,'Tab','Electronics',9500);
INSERT INTO Products(ProductID, ProductName, Category, Price)
VALUES (110,'Speaker','Electronics',9500);


SELECT * FROM Products;



SELECT *,
       ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM Products;

SELECT *,
       RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
FROM Products;

SELECT *,
       DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products;



SELECT *
FROM (
    SELECT *, ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
) AS ranked
WHERE RowNum <= 3;

SELECT *
FROM (
    SELECT *, RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
    FROM Products
) AS ranked
WHERE RankNum <= 3;

SELECT *
FROM (
    SELECT *, DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
) AS ranked
WHERE DenseRankNum <= 3;


