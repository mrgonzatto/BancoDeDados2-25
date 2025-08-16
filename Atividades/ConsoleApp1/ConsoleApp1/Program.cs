using System;
using System.Collections.Generic;

class Program
{
    static List<List<(string, string)>> RoundRobinRotation(List<string> teams)
    {
        if (teams.Count % 2 != 0)
            teams.Add("Bye");

        int n = teams.Count;
        var rounds = new List<List<(string, string)>>();

        for (int i = 0; i < n - 1; i++)
        {
            var roundMatches = new List<(string, string)>();

            for (int j = 0; j < n / 2; j++)
            {
                string home = teams[j];
                string away = teams[n - 1 - j];

                roundMatches.Add((home, away));
            }

            rounds.Add(roundMatches);

            var newOrder = new List<string> { teams[0] };
            newOrder.Add(teams[n - 1]);
            for (int k = 1; k < n - 1; k++)
                newOrder.Add(teams[k]);

            teams = newOrder;
        }

        return rounds;
    }

    static void PrintSchedule(List<List<(string, string)>> schedule)
    {
        for (int i = 0; i < schedule.Count; i++)
        {
            Console.WriteLine($"Rodada {i + 1}:");
            foreach (var match in schedule[i])
            {
                if (match.Item1 != "Bye" && match.Item2 != "Bye")
                    Console.WriteLine($"{match.Item1} vs {match.Item2}");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        var teams = new List<string> { "Equipe A", "Equipe B", "Equipe C", "Equipe D", "Equipe E" };

        var schedule = RoundRobinRotation(teams);

        PrintSchedule(schedule);
    }
}
