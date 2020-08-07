namespace TeisterMask.DataProcessor
{
    using System;
    using System.Linq;
    using System.Globalization;

    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;
    
    using Data;
    using TeisterMask.XMLHelper;
    using TeisterMask.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projectsWhitTasks = context.Projects
                                   .ToList() // For Judge
                                   .Where(p => p.Tasks.Count > 0)
                                   .Select(p => new ProjectWithTasksDTO
                                   {
                                       TasksCount = p.Tasks.Count,
                                       ProjectName = p.Name,
                                       HasEndDate = p.DueDate != null ? "Yes" : "No",
                                       Tasks = p.Tasks
                                               .Select(t => new TaskDTO
                                               {
                                                   Name = t.Name,
                                                   Label = t.LabelType.ToString()
                                               })
                                               .OrderBy(n => n.Name)
                                               .ToList()
                                   })
                                   .OrderByDescending(t => t.TasksCount)
                                   .ThenBy(n => n.ProjectName)
                                   .ToList();

            var projectsWhitTasksXML = XMLConverter.Serialize(projectsWhitTasks, "Projects");

            return projectsWhitTasksXML;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var busiestEmployees = context.Employees
                                   .ToList() // For Judge
                                   .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                                   .Select(e => new
                                   {
                                       Username = e.Username,
                                       Tasks = e.EmployeesTasks
                                               .Where(s => s.Task.OpenDate >= date)
                                               .OrderByDescending(d => d.Task.DueDate)
                                               .ThenBy(n => n.Task.Name)
                                               .Select(t => new
                                               {
                                                   TaskName = t.Task.Name,
                                                   OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                                   DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                                   LabelType = t.Task.LabelType.ToString(),
                                                   ExecutionType = t.Task.ExecutionType.ToString()
                                               })
                                   })
                                   .OrderByDescending(t => t.Tasks.Count())
                                   .ThenBy(n => n.Username)
                                   .Take(10)
                                   .ToList();

            var busiestEmployeesJSON = JsonConvert.SerializeObject(busiestEmployees, Formatting.Indented);

            return busiestEmployeesJSON;


        }
    }
}