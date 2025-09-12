USE Northwind

--1.List all cities that have both Employees and Customers.
SELECT distinct e.city
FROM Employees e
INNER JOIN customers c
on c.City=e.City


--2List all cities that have Customers but no Employee.
--a.      Use sub-query
SELECT distinct city
FROM Customers
WHERE City NOT IN (select distinct city FROM Employees)

--b.      Do not use sub-query
SELECT distinct c.City
FROM Customers c
LEFT JOIN Employees e
ON e.City = c.City
WHERE e.City IS NULL


--3.  List all products and their total order quantities throughout all orders.
SELECT p.ProductID,p.ProductName,SUM(od.Quantity) AS 'Total Order Quantities'
FROM orders o
INNER JOIN [Order Details] od
ON o.OrderID=od.OrderID
RIGHT JOIN Products p
ON p.ProductID=od.ProductID
GROUP BY p.ProductID,p.ProductName
ORDER BY SUM(od.Quantity)


--4.  List all Customer Cities and total products ordered by that city.
SELECT c.City,sum(od.Quantity) AS 'total products ordered'
FROM Orders o
INNER JOIN [Order Details] od
ON o.OrderID=od.OrderID
RIGHT JOIN Customers c
ON c.CustomerID=o.CustomerID
GROUP BY c.City
ORDER BY sum(od.Quantity)


--5. List all Customer Cities that have at least two customers.
--a.      Use union
SELECT c.City,COUNT(CustomerID)
FROM Customers c
GROUP BY c.City
HAVING COUNT(CustomerID)=2
UNION
SELECT c.City,COUNT(CustomerID)
FROM Customers c
GROUP BY c.City
HAVING COUNT(CustomerID)>2

--b.      Use sub-query and no union

SELECT temp.City,temp.customerNumber
FROM(
SELECT c.City,COUNT(c.CustomerID) AS customerNumber
FROM Customers c
GROUP BY c.City
) AS temp
WHERE temp.customerNumber >=2


--6.List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City,COUNT( distinct od.ProductID) AS 'Product Count'
FROM Orders o
INNER JOIN [Order Details] od
ON od.OrderID=o.OrderID
INNER JOIN Customers c
ON c.CustomerID=o.CustomerID
GROUP BY c.City
HAVING COUNT(distinct od.ProductID)>=2


--7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT c.CompanyName,c.City AS 'Customer City',o.ShipCity AS 'Ship city'
FROM Orders o
INNER JOIN Customers c
ON o.CustomerID=c.CustomerID
WHERE c.City != o.ShipCity


--8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH productcte AS(
    SELECT TOP(5) p.ProductID AS ID,p.ProductName AS [Product Name], AVG(p.UnitPrice) AS AveragePrice,SUM(od.Quantity) AS ProductSold
    FROM Orders o
    INNER JOIN [Order Details] od
    ON o.OrderID=od.OrderID
    INNER JOIN Products p
    ON p.ProductID=od.ProductID
    GROUP BY p.ProductID,p.ProductName
    ORDER BY SUM(od.Quantity) DESC
),

citycte AS(
    SELECT od.ProductID,c.City,SUM(od.Quantity) AS CityQuantity
    FROM Orders o
    INNER JOIN [Order Details] od
    ON o.OrderID=od.OrderID
    INNER JOIN Customers c
    ON c.CustomerID=o.CustomerID
    WHERE od.ProductID IN (select ID FROM productcte)
    GROUP BY od.ProductID,c.City
)
SELECT temp.ID,temp.[Product Name],temp.AveragePrice,temp.City,temp.CityQuantity
FROM( 
SELECT p.ID,p.[Product Name],p.AveragePrice,c.City,c.CityQuantity ,RANK() OVER (PARTITION BY p.ID ORDER BY CityQuantity DESC) AS [rank]
FROM productcte p
INNER JOIN citycte c
ON p.ID=c.productID
) as temp
WHERE temp.[rank]=1


--9.List all cities that have never ordered something but we have employees there.
--a.      Use sub-query

SELECT e.City
FROM Employees e
WHERE e.City NOT IN 
(   SELECT distinct c.city
    FROM Customers c
    WHERE c.CustomerID IN (select CustomerID FROM orders)
)


--b.      Do not use sub-query
SELECT e.City
FROM Employees e
LEFT JOIN customers c
ON e.City = c.City
WHERE c.CustomerID IS NULL

--10.List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

WITH citycte AS (
SELECT c.City AS EmployeeCity,e.EmployeeID,COUNT(o.OrderID) AS OrderCount
FROM Orders o
INNER JOIN Customers c
ON o.CustomerID=c.CustomerID
INNER JOIN Employees e
ON e.EmployeeID =o.EmployeeID
GROUP BY c.City,e.EmployeeID
),
productcte AS(
SELECT c.City AS ProductCity, SUM(od.Quantity) AS MostOrderProduct
FROM Orders o
INNER JOIN [Order Details] od
ON o.OrderID=od.OrderID
INNER JOIN Customers c
ON o.CustomerID=c.CustomerID
GROUP BY c.City
)
SELECT distinct c.EmployeeCity AS [City]
from citycte c
INNER JOIN productcte p
ON c.EmployeeCity=p.ProductCity
WHERE c.OrderCount =(SELECT MAX(OrderCount) From citycte ) AND p.MostOrderProduct=(select MAX(MostOrderProduct) FROM productcte)


--11.How do you remove the duplicates record of a table?

WITH Duplicatecte AS(
    SELECT pk,
    ROW_NUMBER() OVER (
        partition by column1,column2 -- all columns except pk to make sure no row was remove incorrectly
        ORDER BY id 
    ) AS rn
    FROM table
)
--when rn=1, the row was unique, when rn>1, have dulicate rows,delete any row with rn>1 to remove deplicate
DELETE FROM Duplicatecte WHERE rn>1 