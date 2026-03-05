using System;

namespace Territory;

/// Represents one finished game result.
/// This is what will be stored in the leaderboard.

public class LeaderboardEntry
{
    public string PlayerName { get; set; } = "";

    public int Score { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;
}