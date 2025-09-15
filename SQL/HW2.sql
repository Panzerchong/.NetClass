USE AdventureWorks2019

--1.How many products can you find in the Production.Product table?
SELECT COUNT(*) from Production.Product
--Total is 504 products


--2.Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
--The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(*) from Production.Product
WHERE ProductSubcategoryID is NOT NULL


--3.Count how many products belong to each product subcategory.
-- Write a query that displays the result with two columns:
-- ProductSubcategoryID (the subcategory ID)， CountedProducts (the number of products in that subcategory).
SELECT ProductSubcategoryID,COUNT(*) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID is NOT NULL
GROUP BY ProductSubcategoryID


--4.How many products that do not have a product subcategory.
SELECT COUNT(*) from Production.Product
WHERE ProductSubcategoryID is NULL
--There are 209 products don't have a product subcategory


--5.Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(Quantity)
FROM Production.ProductInventory


--6.Write a query to list the sum of products in the Production.ProductInventory table 
--and LocationID set to 40 and limit the result to include just summarized quantities less than 100.


SELECT ProductID,SUM(Quantity) as Quantity
FROM Production.ProductInventory
WHERE LocationID=40
GROUP BY ProductID
HAVING SUM(Quantity) <100


--7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory 
--table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

SELECT ProductID,SUM(Quantity) AS Quantity,Shelf
FROM Production.ProductInventory
where LocationID=40
GROUP BY ProductID,Shelf
HAVING SUM(Quantity)<100


--8.Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT AVG(Quantity) AS AverageQuantity
FROM Production.ProductInventory
WHERE LocationID = 10


--9.Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
SELECT shelf,AVG(quantity)
FROM Production.ProductInventory
GROUP BY Shelf
ORDER BY Shelf ASC


--10.Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
SELECT shelf,AVG(quantity)
FROM Production.ProductInventory
WHERE shelf != 'N/A'
GROUP BY Shelf
ORDER BY Shelf ASC


--11.List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. 
--Exclude the rows where Color or Class are null.
SELECT Color,Class,AVG(ListPrice) AS AverageListPrice
FROM Production.Product
where Color is NOT NULL AND Class is NOT NULL
GROUP BY Color,Class


--12.Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. 
--Join them and produce a result set similar to the following
SELECT c.name AS Country,s.Name AS Province
FROM person.CountryRegion c
INNER JOIN Person.StateProvince s
on c.CountryRegionCode=s.CountryRegionCode


--13.Write a query that lists the country and province names from person. CountryRegion and person. 
--StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT c.name AS Country,s.Name AS Province
FROM person.CountryRegion c
INNER JOIN Person.StateProvince s
on c.CountryRegionCode=s.CountryRegionCode
WHERE c.Name = 'Germany' OR c.Name = 'Canada'
ORDER BY c.Name,s.Name


USE Northwind
-- Using Northwnd Database: (Use aliases for all the Joins)
--14.List all Products that has been sold at least once in last 25 years.
SELECT p.ProductName,od.OrderID,o.OrderDate
FROM Products AS p
INNER JOIN [Order Details] AS od
on p.ProductID=od.ProductID
INNER JOIN Orders AS o
ON o.OrderID=od.OrderID
WHERE o.OrderDate >= DATEADD(YEAR,-25,GETDATE())

--15.List top 5 locations (Zip Code) where the products sold most.
SELECT TOP(5) c.PostalCode AS ZipCode,SUM(od.Quantity) AS quantities
FROM Customers as c
INNER JOIN Orders as o
ON c.CustomerID=o.CustomerID
INNER JOIN [Order Details] AS od
ON od.OrderID=o.OrderID
WHERE c.PostalCode is NOT NULL
GROUP BY c.PostalCode
ORDER BY quantities DESC


--16.List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT TOP(5) c.PostalCode AS ZipCode,SUM(od.Quantity) AS quantities
FROM Customers as c
INNER JOIN Orders as o
ON c.CustomerID=o.CustomerID
INNER JOIN [Order Details] AS od
ON od.OrderID=o.OrderID
WHERE c.PostalCode is NOT NULL AND o.OrderDate >= DATEADD(YEAR,-25,GETDATE())
GROUP BY c.PostalCode
ORDER BY quantities DESC


--17.List all city names and number of customers in that city.    
SELECT City,COUNT(*) AS NumberOfCustomers
FROM Customers
GROUP BY City
ORDER BY NumberOfCustomers DESC


--18.List city names which have more than 2 customers, and number of customers in that city

SELECT City,COUNT(*) AS NumberOfCustomers
FROM Customers
GROUP BY City
HAVING COUNT(City)>2
ORDER BY NumberOfCustomers DESC


--19.List the names of customers who placed orders after 1/1/98 with order date.
SELECT c.CompanyName,MIN(o.OrderDate) AS OldestOrder
FROM Customers AS c
INNER JOIN Orders AS o
ON c.CustomerID=o.CustomerID
WHERE o.OrderDate >'1998-1-1'
GROUP BY c.CompanyName


--20.List the names of all customers with most recent order dates
SELECT temp.CompanyName,temp.OrderDate
FROM(
	SELECT  c.CompanyName,o.OrderDate,
	RANK() over (partition by c.CompanyName order by o.orderDate desc) as [rank]
	FROM Customers AS c
	LEFT JOIN Orders AS o
	ON c.CustomerID=o.CustomerID
) AS temp
WHERE temp.[rank]=1


--21.Display the names of all customers  along with the  count of products they bought
SELECT c.CustomerID,c.CompanyName,ISNULL(SUM(od.Quantity),0) AS ProductsCount
FROM Orders o
INNER JOIN [Order Details] od
on o.OrderID=od.OrderID
RIGHT JOIN Customers c
on c.CustomerID=o.CustomerID
GROUP BY c.CompanyName,c.CustomerID


--22.Display the customer ids who bought more than 100 Products with count of products.
--subquery
SELECT *
FROM(
SELECT o.CustomerID,SUM(od.quantity) AS ProductsCount
FROM Orders o
INNER JOIN [Order Details] od
on o.OrderID=od.OrderID
GROUP BY o.CustomerID
) AS temp
WHERE ProductsCount >100

--cte
WITH cte AS(
	SELECT o.CustomerID,SUM(od.quantity) AS [Products Count]
	FROM Orders o
	INNER JOIN [Order Details] od
	on o.OrderID=od.OrderID
	GROUP BY o.CustomerID
)
SELECT * 
FROM cte
WHERE [Products Count] >100

--23.Show all the possible combinations of suppliers and shippers, representing every way a supplier can ship its products.
	-- The result should display two columns:
	-- Supplier CompanyName， Shipper CompanyName
SELECT s.CompanyName AS [Supplier CompanyName],sh.CompanyName AS [Shipper CompanyName]  
FROM Suppliers s
CROSS JOIN Shippers sh

--24.Display the products order each day. Show Order date and Product Name.
SELECT o.orderDate,p.ProductName
FROM Orders o
INNER JOIN [Order Details] od
on od.OrderID=o.OrderID
INNER JOIN Products p
ON p.ProductID=od.ProductID
ORDER BY o.OrderDate,p.ProductName


--25.Displays pairs of employees who have the same job title.
SELECT e1.FirstName+' '+e1.LastName AS name1, e2.FirstName+' '+e2.LastName AS name2,e1.Title
FROM Employees e1
INNER JOIN Employees e2
on e1.Title=e2.Title AND e1.EmployeeID < e2.EmployeeID --remove duplicate


--26.Display all the Managers who have more than 2 employees reporting to them.

SELECT ManagerID,e.FirstName+' '+e.LastName AS Manager
FROM(
SELECT m.ReportsTo AS ManagerID, COUNT(m.ReportsTo) as reportcount
FROM Employees m
GROUP BY m.ReportsTo
HAVING COUNT(m.ReportsTo) >2
) AS temp
INNER JOIN Employees e
ON ManagerID=e.EmployeeID


--27.List all customers and suppliers together, grouped by city.
-- The result should display the following columns:
-- City，CompanyName，ContactName，Type (indicating whether the record is a Customer or a Supplier).

SELECT c.city,c.CompanyName,c.ContactName,'Customer' AS Type
FROM Customers c
UNION
SELECT s.city,s.CompanyName,s.ContactName,'Supplier' AS Type
FROM Suppliers s
ORDER BY c.City,c.CompanyName
