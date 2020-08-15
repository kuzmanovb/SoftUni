namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using SoftJail.XMLHelper;
    using System;
    using System.Globalization;
    using System.Linq;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .ToList()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                              .Where(q => q.PrisonerId == p.Id)
                              .Select(o => new
                              {
                                  OfficerName = o.Officer.FullName,
                                  Department = o.Officer.Department.Name
                              })
                              .OrderBy(r => r.OfficerName)
                              .ToList(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(y => y.Officer.Salary)
                })
                .OrderBy(n => n.Name)
                .ThenBy(i => i.Id)
                .ToList();

            var prosToJson = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return prosToJson;

        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var nameToArray = prisonersNames.Split(",").ToList();

            var prisoners = context.Prisoners
                .ToList()
                .Where(p => nameToArray.Contains(p.FullName))
                .Select(p => new InboxPrisonerDTO
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                                       .Select(m => new MasageDTO 
                                       { 
                                           Description = string.Join("", m.Description.Reverse())
                                       })
                                       .ToList()

                })
                .OrderBy(p => p.Name)
                .ThenBy(i => i.Id)
                .ToList();


            var prisonersToXML = XMLConverter.Serialize(prisoners, "Prisoners");

            return prisonersToXML;

        }
    }
}