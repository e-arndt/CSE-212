/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();
        var playerFound = new HashSet<string>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (playerFound.Contains(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                playerFound.Add(playerId);
                players[playerId] = points;
            }
            
        }

        var topPlayers = players.OrderByDescending(p => p.Value).Take(10).ToArray();

        // var topPlayers = new string[10];

        Console.WriteLine("Players with Highest Career Points:");
        foreach (var player in topPlayers)
        {
            Console.WriteLine($"Player: {player.Key} - {player.Value:N0}");
        }


        // Using topPlayers
        // for (int i = 0; i < topPlayersList.Length; i++)
        // {
        //     topPlayers[i] = $"Player {topPlayersList[i].Key}: {topPlayersList[i].Value} points";
        // }

        // Console.WriteLine("Top 10 Players: ");
        // foreach (var player in topPlayers)
        // {
        //     Console.WriteLine(player);
        // }

        // var specificPlayerId = "abramjo01";


        // Test one specific player
        // if (players.ContainsKey(specificPlayerId))
        // {
        //     // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");
        //     Console.WriteLine($"Player {specificPlayerId}: {players[specificPlayerId]} points");
        // }
        // else
        // {
        //     Console.WriteLine($"Player: {specificPlayerId} not found");
        // }
        

        
    }
}