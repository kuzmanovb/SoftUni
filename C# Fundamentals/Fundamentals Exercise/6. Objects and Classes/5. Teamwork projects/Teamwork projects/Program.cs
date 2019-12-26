using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamwork_projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberTeam = int.Parse(Console.ReadLine());

            var allTeam = new List<Team>();

            for (int i = 0; i < numberTeam; i++)
            {
                string[] insertTeam = Console.ReadLine().Split("-");

                bool checkUser = CheckLider(insertTeam, allTeam);
                bool checkTeam = CheckTeam(insertTeam, allTeam);

                if (!checkTeam)
                {
                    Console.WriteLine($"Team {insertTeam[1]} was already created!");
                }
                else if (!checkUser)
                {
                    Console.WriteLine($"{insertTeam[0]} cannot create another team!");
                }
                if (checkUser && checkTeam)
                {
                    var team = new Team();

                    team.LiderTeam = insertTeam[0];
                    team.NameTeam = insertTeam[1];

                    allTeam.Add(team);
                    Console.WriteLine($"Team {insertTeam[1]} has been created by {insertTeam[0]}!");
                }
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] inputArr = input.Split("->");

                string nameMember = inputArr[0];
                string team = inputArr[1];

                bool teamNameChack = CheckTeam(inputArr, allTeam);
                bool checkMember = CheckMember(inputArr, allTeam);

                if (teamNameChack)
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (!checkMember)
                {
                    Console.WriteLine($"Member {nameMember} cannot join team {team}!");
                }
                else if(!teamNameChack && checkMember)
                {
                    for (int i = 0; i < allTeam.Count; i++)
                    {
                        if (allTeam[i].NameTeam == team)
                        {
                            allTeam[i].NameMember = nameMember;
                            allTeam[i].AddMember();
                        }
                    }
                }

                input = Console.ReadLine();
            }

            allTeam = allTeam.OrderByDescending(x => x.Members.Count).ThenBy(a => a.NameTeam).ToList();

            foreach (var item in allTeam)
            {
                if (item.Members.Count > 0)
                {
                    Console.WriteLine(item.NameTeam);
                    Console.WriteLine("- " + item.LiderTeam);

                    for (int i = 0; i < item.Members.Count; i++)
                    {
                        Console.WriteLine("-- " + item.Members[i]);
                    }
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var item in allTeam)
            {
                if (item.Members.Count <= 0)
                {
                    Console.WriteLine(item.NameTeam);
                }
            }
        }

        static bool CheckLider(string[] insertTeam, List<Team> allTeam)
        {
            bool check = true;
            string liderName = insertTeam[0];

            foreach (var item in allTeam)
            {
                if (item.LiderTeam == liderName)
                {
                    check = false;
                }
            }

            return check;
        }
        static bool CheckTeam(string[] insertTeam, List<Team> allTeam)
        {
            bool check = true;
            string teamName = insertTeam[1];

            foreach (var item in allTeam)
            {
                if (item.NameTeam == teamName)
                {
                    check = false;
                }
            }

            return check;
        }
        static bool CheckMember(string[] inputArr, List<Team> allTeam)
        {
            bool check = true;
            string teamName = inputArr[0];

            foreach (var item in allTeam)
            {
                if (item.LiderTeam == teamName)
                {
                    check = false;
                }
                if (item.Members.Contains(teamName))
                {
                    check = false;
                }
            }

            return check;
        }
    }


    class Team
    {
        public Team()
        {
            Members = new List<string>(0);
        }

        public string NameTeam { get; set; }
        public string LiderTeam { get; set; }
        public string NameMember { get; set; }

        public List<string> Members { get; set; }

        public void AddMember()
        {
            Members.Add(NameMember);
        }
        
    }
}
