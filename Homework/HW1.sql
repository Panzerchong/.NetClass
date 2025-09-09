--1.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, with no filter
select ProductID,Name,Color,ListPrice
from Production.Product


--2.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, excludes the rows that ListPrice is 0
select ProductID,Name,Color,ListPrice
from Production.Product
where ListPrice != 0


--3.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are NULL for the Color column
select ProductID,Name,Color,ListPrice
from Production.Product
where Color is NULL

--4.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the Color column.
select ProductID,Name,Color,ListPrice
from Production.Product
where Color is not NULL


--5.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the column Color, 
--and the column ListPrice has a value greater than zero
select ProductID,Name,Color,ListPrice
from Production.Product
where Color is not NULL AND ListPrice > 0


--6.Write a query that concatenates the columns Name and Color like 'LL Crankarm: Black' from the Production.Product table by excluding the rows that are null for color.
select p.Name + ': ' +p.Color as ProductNameAndColor
from Production.Product p
where p.Color is not NULL

--7.Write a query that generates the following result set  from Production.Product:
select 'NAME: ' + p.Name + ' -- COLOR: '+ p.Color as ProductInformation
from Production.Product p
where p.Color is not NULL

--8.Write a query to retrieve the columns ProductID and Name from the Production.Product table filtered by ProductID from 400 to 500
select p.ProductID,p.Name
from Production.Product p
where p.ProductID >=400 AND p.ProductID <=500


--9.Write a query to retrieve the to the columns  ProductID, Name and color from the Production.Product table restricted to the colors black and blue
select p.ProductID,p.Name,p.Color
from Production.Product p
where p.Color ='black' OR p.Color ='blue'


--10.Write a query to get a result set on products that begins with the letter S. 
select* from Production.Product
where Name like'S%'


--11.Write a query that retrieves the columns Name and ListPrice from the Production.Product table. 
--Order the result set by the Name column.
select p.Name,p.ListPrice
from Production.Product p
order by p.Name

--12. Write a query that retrieves the columns Name and ListPrice from the Production.Product table. 
--Order the result set by the Name column. The products name should start with either 'A' or 'S'
select p.Name,p.ListPrice
from Production.Product p
where p.Name like '[AS]%'
order by p.Name

--13.Write a query so you retrieve rows that have a Name that begins with the letters SPO, but is then not followed by the letter K. 
--After this zero or more letters can exists. Order the result set by the Name column.
select *
from Production.Product
where Name like 'SPO[^k]%'
order by Name


--14.Write a query that retrieves unique colors from the table Production.Product. Order the results in descending  manner
select distinct Color 
from Production.Product
order by Color desc

--15.Write a query that retrieves the unique combination of columns ProductSubcategoryID and Color from the Production.Product table. 
--We do not want any rows that are NULL.in any of the two columns in the result.
select distinct p.ProductSubcategoryID,p.Color
from Production.Product p
where p.ProductSubcategoryID is not NULL AND p.Color is not NULL