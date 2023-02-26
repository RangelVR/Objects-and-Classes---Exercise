using System.Text;

int countOfTeams = int.Parse(Console.ReadLine());

List<Team> teamList = new List<Team>();

for (int i = 0; i < countOfTeams; i++)
{
    string[] input = Console.ReadLine().Split("-");

    string creator = input[0];
    string teamName = input[1];

    if (teamList.Any(x => x.Creator == creator))
    {
        Console.WriteLine($"{creator} cannot create another team!");
        continue;
    }

    if (teamList.Any(x => x.TeamName == teamName))
    {
        Console.WriteLine($"Team {teamName} was already created!");
        continue;
    }

    Team team = new Team(creator, teamName);
    teamList.Add(team);
    Console.WriteLine($"Team {teamName} has been created by {creator}!");
}

string command = Console.ReadLine();

while (command != "end of assignment")
{
    string[] userToJoin = command.Split("->");

    string user = userToJoin[0];
    string teamToJoin = userToJoin[1];

    if (!teamList.Any(x => x.TeamName.Contains(teamToJoin)))
    {
        Console.WriteLine($"Team {teamToJoin} does not exist!");
    }
    else if (teamList.Any(x => x.Members.Contains(user))
              || teamList.Any(x => x.Creator == user))
    {
        Console.WriteLine($"Member {user} cannot join team {teamToJoin}!");
    }
    else
    {
        for (int i = 0; i < teamList.Count; i++)
        {
            if (teamList[i].TeamName == teamToJoin)
            {
                teamList[i].Members.Add(user);
                break;
            }
        }
    }

    command = Console.ReadLine();
}

foreach (Team team in teamList
    .Where(x => x.Members.Count > 0)
    .OrderByDescending(x => x.Members.Count)
    .ThenBy(x => x.TeamName)
    .ToList())
{
    Console.WriteLine(team);
}

Console.WriteLine("Teams to disband:");

List<Team> disbandTeams = teamList.Where(x => x.Members.Count == 0).ToList();

foreach (var disbandTeam in disbandTeams.OrderBy(x => x.TeamName))
{
    Console.WriteLine(disbandTeam.TeamName);
}


class Team
{
    public Team(string creator, string teamName)
    {
        Creator = creator;
        TeamName = teamName;
    }

    public string Creator { get; set; }

    public string TeamName { get; set; }

    public List<string> Members = new List<string>();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(TeamName);
        sb.AppendLine($"- {Creator}");

        foreach (var member in Members.OrderBy(x => x))
        {
            sb.AppendLine($"-- {member}");
        }

        return sb.ToString().TrimEnd();
    }
}
