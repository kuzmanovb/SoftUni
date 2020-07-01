using System;
using System.Globalization;
using System.Linq;
using System.Text;

using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            // Print Task 3
            Console.WriteLine(GetEmployeesFullInformation(context));

            // Print Task 4
            Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            // Print Task 5
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            // Print Task 6
            Console.WriteLine(AddNewAddressToEmployee(context));

            // Print Task 7
            Console.WriteLine(GetEmployeesInPeriod(context));

            // Print Task 8
            Console.WriteLine(GetAddressesByTown(context));

            // Print Task 9
            Console.WriteLine(GetEmployee147(context));

            // Print Task 10
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            // Print Task 11
            Console.WriteLine(GetLatestProjects(context));

            // Print Task 12
            Console.WriteLine(IncreaseSalaries(context));

            // Print Task 13
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            // Print Task 14
            Console.WriteLine(DeleteProjectById(context));

            // Print Task 15
            Console.WriteLine(RemoveTown(context));
        }

        //Task 3. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var allEmpoyees = context.Employees
                              .OrderBy(e => e.EmployeeId)
                              .Select(e => new
                              {
                                  e.FirstName,
                                  e.MiddleName,
                                  e.LastName,
                                  e.JobTitle,
                                  e.Salary
                              })
                              .ToList();

            foreach (var e in allEmpoyees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 4. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {

            var employees = context.Employees.Where(e => e.Salary > 50000)
                                              .Select(o => new
                                              {
                                                  o.FirstName,
                                                  o.Salary
                                              })
                                              .OrderBy(n => n.FirstName)
                                              .ToList();

            var sb = new StringBuilder();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 5. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {

            var employees = context.Employees
                            .Where(e => e.Department.Name == "Research and Development")
                            .Select(o => new
                            {
                                o.FirstName,
                                o.LastName,
                                DepartmentName = o.Department.Name,
                                o.Salary
                            })
                            .OrderBy(s => s.Salary)
                            .ThenByDescending(n => n.FirstName)
                            .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 6. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address() { AddressText = "Vitoshka 15", TownId = 4 };

            var employeeNakov = context.Employees.Where(e => e.LastName == "Nakov").First();

            employeeNakov.Address = newAddress;

            context.SaveChanges();

            var addresses = context.Employees.OrderByDescending(e => e.AddressId)
                                             .Take(10)
                                             .Select(e => new
                                             {
                                                 e.Address.AddressText

                                             }).ToList();

            var sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine(a.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        //Task 7. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {

            var employees = context.Employees.Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                                             .Select(e => new
                                             {
                                                 e.FirstName,
                                                 e.LastName,
                                                 ManagerFirstName = e.Manager.FirstName,
                                                 ManagerLastName = e.Manager.LastName,
                                                 projectInfo = e.EmployeesProjects
                                                              .Select(p => new
                                                              {
                                                                  p.Project.Name,
                                                                  p.Project.StartDate,
                                                                  p.Project.EndDate
                                                              }).ToList()
                                             }).ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.projectInfo)
                {

                    var startDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);


                    var endDate = p.EndDate != null ? p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";

                    sb.AppendLine($"--{p.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        // Task 8. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(c => c.Employees.Count())
                .ThenBy(t => t.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    address = a.AddressText,
                    name = a.Town.Name,
                    count = a.Employees.Count()
                }).ToList();

            var sb = new StringBuilder();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.address}, {a.name} - {a.count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 9. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employees = context.Employees
                            .Where(e => e.EmployeeId == 147)
                            .Select(i => new
                            {
                                i.FirstName,
                                i.LastName,
                                i.JobTitle,
                                projectNames = i.EmployeesProjects.Select(p => p.Project.Name)
                            })
                            .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var p in e.projectNames.OrderBy(p => p))
                {
                    sb.AppendLine($"{p}");
                }
            }

            return sb.ToString().TrimEnd(); ;
        }

        // Task 10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .Select(d => new
                {
                    deparmentName = d.Name,
                    managerFirstName = d.Manager.FirstName,
                    managerLastName = d.Manager.LastName,
                    employees = d.Employees.Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        e.JobTitle
                    }).ToList()
                }).ToList();

            var sb = new StringBuilder();

            foreach (var d in departments.OrderBy(e => e.employees.Count()).ThenBy(d => d.deparmentName))
            {
                sb.AppendLine($"{ d.deparmentName} - {d.managerFirstName} {d.managerLastName}");

                foreach (var e in d.employees)
                {
                    sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd(); ;
        }

        // Task 11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {

            var projects = context.Projects
                            .OrderByDescending(s => s.StartDate)
                            .Take(10)
                            .Select(p => new
                            {
                                p.Name,
                                p.Description,
                                p.StartDate
                            }).ToList();

            var sb = new StringBuilder();

            foreach (var p in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(p.Name)
                    .AppendLine(p.Description)
                    .AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        // Task 12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name.Contains("Engineering") || e.Department.Name.Contains("Tool Design") || e.Department.Name.Contains("Marketing") || e.Department.Name.Contains("Information Services"));

            foreach (var e in employees)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeesForPrint = employees.Select(e => new { e.FirstName, e.LastName, e.Salary }).ToList();

            var sb = new StringBuilder();

            foreach (var e in employeesForPrint.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 13.	Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {

            var employees = context.Employees
                            .Where(e => e.FirstName.StartsWith("Sa") || e.FirstName.StartsWith("SA"))
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.JobTitle,
                                e.Salary
                            }).ToList();

            var sb = new StringBuilder();

            foreach (var e in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // Task 14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Where(p => p.ProjectId == 2).First();
            var projectRef = context.EmployeesProjects.Where(r => r.Project == project).ToList();

            foreach (var pr in projectRef)
            {
                context.EmployeesProjects.Remove(pr);
            }
            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects.Take(10).Select(p => p.Name).ToList();

            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine(p);
            }

            return sb.ToString().TrimEnd();
        }

        // Task 15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {

            var town = context.Towns.Where(t => t.Name == "Seattle").First();
            var addresses = context.Addresses.Where(a => a.TownId == town.TownId).ToList();

            foreach (var a in addresses)
            {
                var employees = context.Employees.Where(e => e.AddressId == a.AddressId).ToList();

                foreach (var e in employees)
                {
                    e.AddressId = null;
                }

                context.Addresses.Remove(a);
            }

            context.Towns.Remove(town);

            context.SaveChanges();
           
            return $"{addresses.Count()} addresses in Seattle were deleted";
        }





    }

}
