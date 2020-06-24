using Microsoft.Data.SqlClient;

namespace P01.Initial_Setup
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Conect to masterDB
            using SqlConnection connect = new SqlConnection(@"Server = BIBI-PC\SQLEXPRESS; Database = master; Integrated Security = true");
            connect.Open();

            // Create database MinionsDB
            var query = @"CREATE DATABASE MinionsDB";
            using var cmd = new SqlCommand(query, connect);
            cmd.ExecuteNonQuery();

            //Conect to MinionsDB
            using SqlConnection newConnect = new SqlConnection(@"Server = BIBI-PC\SQLEXPRESS; Database = MinionsDB; Integrated Security = true;");
            newConnect.Open();

            //Create Countries table
            var queryCountriesCreate = @"CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))";
            using var createTableCountries = new SqlCommand(queryCountriesCreate, newConnect);
            createTableCountries.ExecuteNonQuery();

            //Create Towns table
            var queryTownsCreate = @"CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
            using var createTableTowns = new SqlCommand(queryTownsCreate, newConnect);
            createTableTowns.ExecuteNonQuery();

            //Create Minions table
            var queryMinionsCreate = @"CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))";
            using var createTableMinions = new SqlCommand(queryMinionsCreate, newConnect);
            createTableMinions.ExecuteNonQuery();

            //Create EvilnessFactors table
            var queryEvilnessFactorsCreate = @"CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
            using var createTableEvilnessFactors = new SqlCommand(queryEvilnessFactorsCreate, newConnect);
            createTableEvilnessFactors.ExecuteNonQuery();

            //Create Villains table
            var queryVillainsCreate = @"CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
            using var createTableVillains = new SqlCommand(queryVillainsCreate, newConnect);
            createTableVillains.ExecuteNonQuery();

            //Create MinionsVillains table
            var queryMinionsVillainsCreate = @"CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";
            using var createTableMinionsVillains = new SqlCommand(queryMinionsVillainsCreate, newConnect);
            createTableMinionsVillains.ExecuteNonQuery();

            // Insert into Countries
            var dataToCountries = @"INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";
            using var insertIntoCountries = new SqlCommand(dataToCountries, newConnect);
            insertIntoCountries.ExecuteNonQuery();

            // Inser into Towns
            var dataToTowns = @"INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";
            using var insertIntoTowns = new SqlCommand(dataToTowns, newConnect);
            insertIntoTowns.ExecuteNonQuery();

            // Inset into Minions
            var dataToMinions = @"INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)";
            using var insetIntoMinions = new SqlCommand(dataToMinions, newConnect);
            insetIntoMinions.ExecuteNonQuery();

            // Inser into EvilnessFactors
            var dataToEvilnessFactors = @"INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";
            using var insertIntoEvilnessFactors = new SqlCommand(dataToEvilnessFactors, newConnect);
            insertIntoEvilnessFactors.ExecuteNonQuery();

            //Insert into Villains
            var dataToVillains = @"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)";
            using var insertIntoVillains = new SqlCommand(dataToVillains, newConnect);
            insertIntoVillains.ExecuteNonQuery();

            //Insert into MinionsVillains
            var dataToMinionsVillains = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";
            using var insertIntoMinionsVillains = new SqlCommand(dataToMinionsVillains, newConnect);
            insertIntoMinionsVillains.ExecuteNonQuery();

        }
    }
}
