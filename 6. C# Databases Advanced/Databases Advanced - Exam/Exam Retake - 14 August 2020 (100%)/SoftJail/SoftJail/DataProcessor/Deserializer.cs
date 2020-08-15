namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.XMLHelper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsCellFromJSON = JsonConvert.DeserializeObject<List<ImportDepartmentsCells>>(jsonString);

            var sb = new StringBuilder();
            var departmentsToImpotr = new List<Department>();
            var cellsToImport = new List<Cell>();


            foreach (var dc in departmentsCellFromJSON)
            {
                if (!IsValid(dc))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (dc.Cells.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                var newDepartment = new Department { Name = dc.Name };

                var curentCell = new List<Cell>();
                var checkValidCell = true;

                foreach (var c in dc.Cells)
                {
                    if (!IsValid(c))
                    {
                        sb.AppendLine("Invalid Data");
                        checkValidCell = false;
                        break;
                    }

                    var newCall = new Cell
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow,
                        Department = newDepartment
                    };

                    curentCell.Add(newCall);

                }

                if (checkValidCell)
                {
                    departmentsToImpotr.Add(newDepartment);
                    cellsToImport.AddRange(curentCell);
                    sb.AppendLine($"Imported {dc.Name} with {curentCell.Count} cells");
                }
            }

            context.Departments.AddRange(departmentsToImpotr);
            context.Cells.AddRange(cellsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersMailsFromJSON = JsonConvert.DeserializeObject<List<ImportPrisonersMailsDTO>>(jsonString);
            var sb = new StringBuilder();

            var prisonersToImport = new List<Prisoner>();
            var mailsToImport = new List<Mail>();

            foreach (var pm in prisonersMailsFromJSON)
            {
                if (!IsValid(pm))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                DateTime? releaseDate;


                if (pm.ReleaseDate == null)
                {
                    releaseDate = null;
                }
                else
                {
                    releaseDate = DateTime.ParseExact(pm.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                var newPrisoner = new Prisoner
                {
                    FullName = pm.FullName,
                    Nickname = pm.Nickname,
                    Age = pm.Age,
                    IncarcerationDate = DateTime.ParseExact(pm.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = releaseDate,
                    Bail = pm.Bail,
                    CellId = pm.CellId
                };

                var curentMails = new List<Mail>();
                var checkValidMail = true;

                foreach (var m in pm.Mails)
                {
                    if (!IsValid(m))
                    {
                        sb.AppendLine("Invalid Data");
                        checkValidMail = false;
                        break;
                    }

                    var newMail = new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address,
                        Prisoner = newPrisoner
                    };

                    curentMails.Add(newMail);
                }

                if (checkValidMail)
                {
                    prisonersToImport.Add(newPrisoner);
                    mailsToImport.AddRange(curentMails);
                    sb.AppendLine($"Imported {pm.FullName} {pm.Age} years old");
                }
            }


            context.Prisoners.AddRange(prisonersToImport);
            context.Mails.AddRange(mailsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {

            var officersPrisonersFromXML = XMLConverter.Deserializer<ImportOfficersPrisonersDTO>(xmlString, "Officers");

            var sb = new StringBuilder();
            var officersToImport = new List<Officer>();
            var officerPrisonerToImport = new List<OfficerPrisoner>();


            foreach (var op in officersPrisonersFromXML)
            {
                if (!IsValid(op))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Object positionType;
                bool isPositionValid = Enum.TryParse(typeof(Position), op.Position, out positionType);


                Object weaponType;
                bool isWeaponValid = Enum.TryParse(typeof(Weapon), op.Weapon, out weaponType);

                if (!isPositionValid || !isWeaponValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var newOfficer = new Officer
                {
                    FullName = op.FullName,
                    Salary = op.Salary,
                    Position = (Position)positionType,
                    Weapon = (Weapon)weaponType,
                    DepartmentId = op.DepartmentId
                };

                officersToImport.Add(newOfficer);
                var count = 0;

                foreach (var pri in op.Prisoners)
                {

                    var newOfficerPrisoner = new OfficerPrisoner
                    {
                        PrisonerId = pri.Id,
                        Officer = newOfficer
                    };

                    officerPrisonerToImport.Add(newOfficerPrisoner);
                    count++;
                }


                sb.AppendLine($"Imported {op.FullName} ({count} prisoners)");

            }

            context.Officers.AddRange(officersToImport);
            context.OfficersPrisoners.AddRange(officerPrisonerToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}