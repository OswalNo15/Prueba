SELECT 
SHP.companyname as 'CompanyName',
SUM(O.freight) as 'TotalFreight',
SUM(ResultadoMultiplicado) AS 'TotalCostShipped',
SUM(OD.qty) AS 'TotalItemsShipped'
FROM Sales.SHIPPERS  SHP
JOIN Sales.Orders  O ON SHP.shipperid = O.shipperid
JOIN (SELECT orderid, SUM(unitprice * qty) AS ResultadoMultiplicado, SUM(qty) as qty FROM Sales.OrderDetails  GROUP BY orderid ) OD ON O.orderid = OD.orderid
GROUP BY SHP.companyname
ORDER BY SUM(OD.qty) DESC