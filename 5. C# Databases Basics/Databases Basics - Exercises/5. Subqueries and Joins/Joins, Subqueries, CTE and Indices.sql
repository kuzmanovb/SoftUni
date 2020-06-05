
-- Problem 1. Employee Address --------------------------------------------------------------------------

SELECT TOP (5) e.EmployeeID AS EmployeeId, e.JobTitle, a.AddressID AS AddressId, a.AddressText 
FROM Employees AS e
JOIN Addresses AS a ON  e.AddressID = a.AddressID
ORDER BY e.AddressID

-- Problem 2. Addresses with Towns ----------------------------------------------------------------------

SELECT TOP(50) e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID 
ORDER BY e.FirstName, e.LastName

-- Problem 3. Sales Employee ----------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS DepartmentName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

-- Problem 4. Employee Departments ----------------------------------------------------------------------

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS DepartmentName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- Problem 5. Employees Without Project -----------------------------------------------------------------

SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID 

-- Problem 6. Employees Hired After ---------------------------------------------------------------------

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

-- Problem 7. Employees with Project --------------------------------------------------------------------

SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName FROM Employees AS e 
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002.08.13'AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- Problem 8. Employee 24 -------------------------------------------------------------------------------

SELECT TOP(5) e.EmployeeID, e.FirstName,
CASE
   WHEN YEAR(p.StartDate) >= '2005' THEN NULL
   ELSE p.[Name]
END AS ProjectName
FROM Employees AS e 
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

-- Problem 9. Employee Manager --------------------------------------------------------------------------

SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName FROM Employees AS e
JOIN (SELECT EmployeeID, FirstName FROM Employees) AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

-- Problem 10. Employee Summary -------------------------------------------------------------------------

SELECT TOP(50) e.EmployeeID, 
               e.FirstName + ' ' + e.LastName AS EmployeeName,
               m.FirstName + ' ' + m.LastName AS ManagerName,
               d.[Name] AS DepartmentName
FROM Employees AS e
JOIN (SELECT EmployeeID, FirstName, LastName FROM Employees) AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- Problem 11. Min Average Salary -----------------------------------------------------------------------

SELECT TOP(1) AVG(Salary) AS MinAverageSalary FROM Employees
GROUP BY DepartmentID
ORDER BY AVG(Salary)

-- Problem 12. Highest Peaks in Bulgaria ----------------------------------------------------------------

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON p.MountainId = m.Id 
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- Problem 13. Count Mountain Ranges --------------------------------------------------------------------

SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryName IN ('United States', 'Russia ', 'Bulgaria')
GROUP BY c.CountryCode

-- Problem 14. Countries with Rivers --------------------------------------------------------------------

SELECT TOP(5) c.CountryName, r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- Problem 15. Continents and Currencies ----------------------------------------------------------------

SELECT ContinentCode, CurrencyCode, CurrencyUsage 
FROM (
      SELECT c.ContinentCode,c.CurrencyCode, COUNT(*) AS CurrencyUsage, 
             DENSE_RANK() OVER ( PARTITION BY c.ContinentCode ORDER BY COUNT(*) DESC) AS [Rank]
      FROM Countries AS c
      GROUP BY c.ContinentCode,c.CurrencyCode
     ) AS tt
WHERE CurrencyUsage > 1 AND [Rank] = 1
ORDER BY ContinentCode, CurrencyCode

-- Problem 16. Countries without any Mountains ----------------------------------------------------------

SELECT COUNT(*) AS [Count] FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE mc.MountainId IS NULL

-- Problem 17. Highest Peak and Longest River by Country ------------------------------------------------

SELECT TOP(5) cm.CountryName, cm.HighestPeakElevation, cr.LongestRiverLength 
FROM (SELECT c.CountryName, Max(p.Elevation) AS HighestPeakElevation 
      FROM Countries AS c
      LEFT JOIN MountainsCountries AS mc On mc.CountryCode = c.CountryCode
      LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
      LEFT JOIN Peaks AS p ON p.MountainId = m.Id
      GROUP BY c.CountryName) AS cm
JOIN (SELECT c.CountryName, Max(r.[Length]) AS LongestRiverLength
      FROM Countries AS c
      LEFT JOIN CountriesRivers AS cr On cr.CountryCode = c.CountryCode
      LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
      GROUP BY c.CountryName) AS cr ON cm.CountryName = cr.CountryName
ORDER BY cm.HighestPeakElevation DESC, cr.LongestRiverLength DESC

-- Problem 18. Highest Peak Name and Elevation by Country -----------------------------------------------

SELECT  mount.CountryName, mount.MountainRange, p.PeakName, MAX(p.Elevation) AS Elevation
INTO #TemtTable
FROM (SELECT c.CountryName, m.MountainRange, m.Id
               FROM Countries AS c
               LEFT JOIN MountainsCountries AS mc On mc.CountryCode = c.CountryCode
               LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
               GROUP BY c.CountryName, m.MountainRange, m.Id) AS mount
LEFT JOIN Peaks AS p ON p.MountainId = mount.Id
GROUP BY mount.CountryName, mount.MountainRange, p.PeakName

SELECT TOP(5) 
        CountryName AS Country, 
        ISNULL(PeakName, '(no highest peak)' ) AS [Highest Peak Name],
		ISNULL(Elevation, 0) AS  [Highest Peak Elevation],  
		ISNULL(MountainRange, '(no mountain)') AS Mountain 
FROM (SELECT CountryName, MountainRange, PeakName, Elevation,
      DENSE_RANK() OVER(PARTITION BY CountryName ORDER BY Elevation DESC) AS [Rank]
      FROM #TemtTable) AS t
WHERE [Rank] = 1







