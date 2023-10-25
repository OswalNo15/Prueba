
	WITH AvgDays AS (
    SELECT Customers.companyname as 'CustomerName', AVG(DATEDIFF(DAY, ISNULL(Orders.PreviousOrderDate,Orders.OrderDatE), Orders.OrderDate)) AS AverageDays
    FROM (
        SELECT custid, OrderDate,
               LAG(OrderDate) OVER (PARTITION BY custid ORDER BY OrderDate asc) AS PreviousOrderDate
        FROM Sales.Orders
    ) AS Orders
    JOIN Sales.Customers ON Orders.custid = Customers.custid
    GROUP BY Customers.companyname
),
LastOrder AS (
    SELECT Customers.companyname as 'CustomerName', MAX(Orders.OrderDate) AS LastOrderDate
    FROM Sales.Orders
    JOIN Sales.Customers ON Orders.custid = Customers.custid
    GROUP BY Customers.companyname
)
SELECT LastOrder.CustomerName, LastOrder.LastOrderDate, DATEADD(DAY, AvgDays.AverageDays, LastOrder.LastOrderDate) AS NextPredictedOrder
FROM AvgDays
JOIN LastOrder ON AvgDays.CustomerName = LastOrder.CustomerName;
