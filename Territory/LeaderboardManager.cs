using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Territory;

/// Handles saving and loading leaderboard results.
/// The data will be stored in a JSON file.

public static class LeaderboardManager
{
    private const string FileName = "leaderboard.json";
    /// Load leaderboard entries from disk
    public static List<LeaderboardEntry> Load()
    {
        if (!File.Exists(FileName))
            return new List<LeaderboardEntry>();

        try
        {
            var json = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<List<LeaderboardEntry>>(json)
            ?? new List<LeaderboardEntry>();
        }
        catch
        {
            return new List<LeaderboardEntry>();
        }
    }
    /// Save leaderboard entries
    public static void Save(List<LeaderboardEntry> entries)
    {
    var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions
    {
    WriteIndented = true
    });

    File.WriteAllText(FileName, json);
    }
}
