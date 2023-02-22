namespace Hypnobox.App;

internal static class FootballScores
{
    public static void Run()
    {
        //CASE0
        PrintCase(new[] { 1, 4, 2, 4 }, new[] { 3, 5 });

        //CASE1
        PrintCase(new[] { 2, 10, 5, 4, 8 }, new[] { 3, 1, 7, 8 });
    }

    private static void PrintCase(int[] scoreTeamA, int[] scoreTeamB)
    {

        var teamA = new Team(scoreTeamA.Select(x => new Score(x)).ToList());
        var teamB = new Team(scoreTeamB.Select(x => new Score(x)).ToList());
        var result = teamB.CompareTeam(teamA);
        Console.WriteLine(string.Join(",", result));
    }
}
public record struct Score(int Goals);
public record Team(List<Score> Scores)
{
    public List<int> CompareTeam(Team Other)
        => Scores.Select(x => Other.Scores.Count(i => i.Goals <= x.Goals)).ToList();
}