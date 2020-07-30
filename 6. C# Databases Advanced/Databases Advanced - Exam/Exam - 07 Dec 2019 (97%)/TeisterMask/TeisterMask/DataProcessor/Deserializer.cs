namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using TeisterMask.XMLHelper;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var projectTaskXML = XMLConverter.Deserializer<ProjectDTO>(xmlString, "Projects");

            var projectsForAdd = new List<Project>();
            var tasksForAdd = new List<Task>();
            var sb = new StringBuilder();

            foreach (var pt in projectTaskXML)
            {
                // Project

                if (!IsValid(pt))
                {
                    sb.AppendLine(string.Format(ErrorMessage));
                    continue;

                }

                var projectOpenDate = DateTime.ParseExact(pt.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var projectDueDate = string.IsNullOrEmpty(pt.DueDate) ? (DateTime?)null : DateTime.ParseExact(pt.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var newProject = new Project
                {
                    Name = pt.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                projectsForAdd.Add(newProject);

                // Task
                var countTask = 0;

                foreach (var task in pt.Tasks)
                {
                    var checkExecutionType = Enum.IsDefined(typeof(ExecutionType), task.ExecutionType);
                    var checkLabelType = Enum.IsDefined(typeof(LabelType), task.LabelType);

                    var taskOpenDate = DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var checkName = task.Name.Length > 1 && task.Name.Length < 41;

                    if (!IsValid(task))
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }

                    if (!checkExecutionType || !checkLabelType || taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(string.Format(ErrorMessage));
                        continue;
                    }

                    var newTask = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType,
                        Project = newProject
                    };

                    tasksForAdd.Add(newTask);
                    countTask++;
                }

                sb.AppendLine($"Successfully imported project - {pt.Name} with {countTask} tasks.");
            }

            context.Projects.AddRange(projectsForAdd);
            context.Tasks.AddRange(tasksForAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
       }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesJSON = JsonConvert.DeserializeObject<List<EmployeesDTO>>(jsonString);

            var employeesForAdd = new List<Employee>();
            var employeesTaskForAdd = new List<EmployeeTask>();
            var sb = new StringBuilder();

            foreach (var e in employeesJSON)
            {

                if (!IsValid(e))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                var newEmployee = new Employee
                {
                    Username = e.Username,
                    Email = e.Email,
                    Phone = e.Phone
                };

                employeesForAdd.Add(newEmployee);

                var tasksInDatabase = context.Tasks.Select(t => t.Id).ToList();
                var UniqueTaskId = e.TasksId.Distinct().ToList();
                var countEmployeeTask = 0;
                
                for (int i = 0; i < UniqueTaskId.Count(); i++)
                {

                    if (!tasksInDatabase.Contains(UniqueTaskId[i]))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    var newEmployeeTask = new EmployeeTask
                    {
                        TaskId = UniqueTaskId[i],
                        Employee = newEmployee
                    };

                    employeesTaskForAdd.Add(newEmployeeTask);
                    countEmployeeTask++;

                }

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, e.Username, countEmployeeTask));
            }

            context.Employees.AddRange(employeesForAdd);
            context.EmployeesTasks.AddRange(employeesTaskForAdd);
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