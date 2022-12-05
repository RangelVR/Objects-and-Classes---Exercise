using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Teamwork_Projects
{
    class Team
    {
        public string TeamCreator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; } = new List<string>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            int counter = 0;

            List<Team> teams = new List<Team>();

            while (counter != teamsCount)
            {
                string[] input = Console.ReadLine().Split("-").ToArray();
                string user = input[0];
                string teamName = input[1];
                bool teamDoesNotExist = true;
                bool isCreatorExist = false;

                Team newTeam = new Team()
                {
                    TeamCreator = input[0],
                    TeamName = input[1]
                };

                for (int i = 0; i < teams.Count; i++)
                {
                    if (teams[i].TeamName == teamName)
                    {
                        teamDoesNotExist = false;
                        Console.WriteLine($"Team {teamName} was already created!");
                    }
                }

                if (teamDoesNotExist)
                {
                    foreach (Team team in teams)
                    {
                        if (team.TeamCreator == user)
                        {
                            Console.WriteLine($"{user} cannot create another team!");
                            isCreatorExist = true;
                            break;
                        }
                    }
                    if (!isCreatorExist)
                    {
                        teams.Add(newTeam);
                        Console.WriteLine($"Team {teamName} has been created by {user}!");
                    }
                }

                counter++;
            }

            string command;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] commandArgs = command.Split("->").ToArray();
                string user = commandArgs[0];
                string teamToJoin = commandArgs[1];
                bool isMemberExist = false;
                bool isTeamExist = false;

                for (int j = 0; j < teams.Count; j++)
                {
                    if (teams[j].Members.Contains(user) || teams[j].TeamCreator == user)
                    {
                        isMemberExist = true;
                        Console.WriteLine($"Member {user} cannot join team {teamToJoin}!");
                    }
                    if (teams[j].TeamName == teamToJoin)
                    {
                        isTeamExist = true;
                    }
                }

                if (!isTeamExist)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }

                for (int i = 0; i < teams.Count; i++)
                {
                    if (teams[i].TeamName == teamToJoin)
                    {
                        if (!isMemberExist)
                        {
                            teams[i].Members.Add(user);
                        }
                    }
                }
            }

            List<string> disbandTeams = new List<string>();
            teams = teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).ToList();

            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Count == 0)
                {
                    disbandTeams.Add(teams[i].TeamName);
                }
                else
                {
                    Console.WriteLine(teams[i].TeamName);
                    Console.WriteLine($"- {teams[i].TeamCreator}");
                    foreach (var name in teams[i].Members.OrderBy(x => x))
                    {
                        Console.WriteLine($"-- {name}");
                    }
                }
            }
            disbandTeams = disbandTeams.OrderBy(x => x).ToList();
            Console.WriteLine("Teams to disband:");
            Console.WriteLine(string.Join(Environment.NewLine, disbandTeams));
        }

    }

}
