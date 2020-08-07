namespace TeisterMask.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
    using Newtonsoft.Json;

    using Data;
    using TeisterMask.XMLHelper;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var projectsTasksFromXML = XMLConverter.Deserializer<ImportProjectsDTO>(xmlString, "Projects");

            var sb = new StringBuilder();
            var projectsForImport = new List<Project>();
            var tasksForimport = new List<Task>();

            foreach (var pt in projectsTasksFromXML)
            {

                if (!IsValid(pt))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var projectOpenDate = DateTime.ParseExact(pt.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var projectDueDate = !string.IsNullOrEmpty(pt.DueDate) ? DateTime.ParseExact(pt.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null;

                var newProject = new Project
                {
                    Name = pt.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                projectsForImport.Add(newProject);

                var curentNewTask = new List<Task>();

                foreach (var t in pt.Tasks)
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }

                    var taskOpenDate = DateTime.ParseExact(t.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(t.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }

                    var newTask = new Task
                    {
                        Name = t.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)t.ExecutionType,
                        LabelType = (LabelType)t.LabelType,
                        Project = newProject
                        
                    };

                    curentNewTask.Add(newTask);
                }

                tasksForimport.AddRange(curentNewTask);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, pt.Name, curentNewTask.Count));

            }

            context.Projects.AddRange(projectsForImport);
            context.Tasks.AddRange(tasksForimport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesFromJSON = JsonConvert.DeserializeObject<List<ImportEmployeesDTO>>(jsonString);

            var sb = new StringBuilder();
            var employeesForImport = new List<Employee>();
            var employeesTasksForImport = new List<EmployeeTask>();

            var tasksId = context.Tasks.Select(i => i.Id).ToList();

            foreach (var e in employeesFromJSON)
            {
                if (!IsValid(e))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;
                }

                var newEmployee = new Employee
                {
                    Username = e.Username,
                    Email = e.Email,
                    Phone = e.Phone
                };

                employeesForImport.Add(newEmployee);
                var curentTasks = new List<EmployeeTask>();

                foreach (var t in e.Tasks.Distinct())
                {
                    if (!tasksId.Contains(t))
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }

                    var newEmployeeTask = new EmployeeTask
                    {
                        Employee = newEmployee,
                        TaskId = t
                    };

                    curentTasks.Add(newEmployeeTask);

                }

                employeesTasksForImport.AddRange(curentTasks);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, e.Username, curentTasks.Count));

            }

            context.Employees.AddRange(employeesForImport);
            context.EmployeesTasks.AddRange(employeesTasksForImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}