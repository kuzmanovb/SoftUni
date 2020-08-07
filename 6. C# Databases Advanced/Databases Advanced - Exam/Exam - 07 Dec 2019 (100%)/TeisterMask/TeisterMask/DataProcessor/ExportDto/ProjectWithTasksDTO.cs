using System.Collections.Generic;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectWithTasksDTO
    {
       [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("")]
        public string ProjectName { get; set; }

        [XmlElement("")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public List<TaskDTO> Tasks { get; set; }
    }

    [XmlType("Task")]
    public class TaskDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Label")]
        public string Label { get; set; }

    }
}
