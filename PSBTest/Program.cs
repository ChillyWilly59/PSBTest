using System;

class Program
{
    static void Main()
    {
        string[] results = { "3:1", "2:2", "0:1", "4:2", "3:a", "3- 12" };

        int team1Points = 0;
        int team2Points = 0;

        foreach (var result in results)
        {
            int team1Goals, team2Goals;

            try
            {
                if (TryParseResult(result, out team1Goals, out team2Goals))
                {
                    if (team1Goals > team2Goals)
                    {
                        team1Points += 3;
                    }
                    else if (team1Goals == team2Goals)
                    {
                        team1Points += 1;
                        team2Points += 1;
                    }
                    else
                    {
                        team2Points += 3;
                    }
                }
                else
                {
                    Console.WriteLine($"Ошибка в формате результата: {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке результата {result}: {ex.Message}");
            }
        }

        Console.WriteLine("Команда №1: " + team1Points + " очков");
        Console.WriteLine("Команда №2: " + team2Points + " очков");
    }

    static bool TryParseResult(string result, out int team1Goals, out int team2Goals)
    {
        team1Goals = 0;
        team2Goals = 0;

        string[] parts = result.Split(':');

        if (parts.Length == 2 && int.TryParse(parts[0], out team1Goals) && int.TryParse(parts[1], out team2Goals))
        {
            return true;
        }

        return false;
    }
}