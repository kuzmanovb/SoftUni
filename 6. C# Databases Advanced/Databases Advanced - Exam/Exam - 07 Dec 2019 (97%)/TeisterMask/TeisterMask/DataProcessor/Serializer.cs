namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.XMLHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projectsTask = context.Projects
                               .ToList()// Need for judge
                               .Where(t => t.Tasks.Count > 0)
                               .Select(p => new ProjectWithTaskDTO
                               {
                                   TasksCount = p.Tasks.Count,
                                   ProjectName = p.Name,
                                   HasEndDate = string.IsNullOrEmpty(p.DueDate.ToString()) ? "No" : "Yes",
                                   Tasks = p.Tasks.Select(t => new TaskToProjectDTO
                                   {
                                       Name = t.Name,
                                       Label = Enum.GetName(typeof(LabelType), t.LabelType)
                                   })
                                   .OrderBy(n => n.Name)
                                   .ToList()
                               })
                               .OrderByDescending(t => t.TasksCount)
                               .ThenBy(p => p.ProjectName)
                               .ToList();

            var projectsTaskXML = XMLConverter.Serialize(projectsTask, "Projects");

            return projectsTaskXML;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var busiestEmployees = context.Employees
                                   .ToList() // Need for judge
                                   .Where(t => t.EmployeesTasks.Any(x => x.Task.OpenDate >= date))
                                   .Select(t =>  new
                                   {
                                       Username = t.Username,
                                       Tasks = t.EmployeesTasks
                                               .Where(s => s.Task.OpenDate >= date)
                                               .Select(x => new
                                               {
                                                   TaskName = x.Task.Name,
                                                   OpenDate = x.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                                   DueDate = x.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                                   LabelType = Enum.GetName(typeof(LabelType),x.Task.LabelType),
                                                   ExecutionType = 
                                                  Enum.GetName(typeof(ExecutionType),x.Task.ExecutionType)
                                               
                                               })
                                               .OrderByDescending(d => DateTime.ParseExact(d.DueDate, "d", CultureInfo.InvariantCulture))
                                               .ThenBy(n => n.TaskName)
                                               .ToList()
                                   })
                                   .OrderByDescending(t => t.Tasks.Count)
                                   .ThenBy(u => u.Username)
                                   .Take(10)
                                   .ToList();

            var busiestEmployeesJSON = JsonConvert.SerializeObject(busiestEmployees, Formatting.Indented);

            return busiestEmployeesJSON;
        }
    }
}