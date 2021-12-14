using System;
using System.Collections.Generic;
using System.Text;

namespace Aoe4RankChecker
{
    public class LeaderboardItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int profile_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string steam_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string clan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int previous_rating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int highest_rating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int streak { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int lowest_streak { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int highest_streak { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int games { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int wins { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int losses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int drops { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int last_match_time { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int leaderboard_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int start { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<LeaderboardItem> leaderboard { get; set; }
    }

    public class GameHistory
    {
        public int rating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int num_wins { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int num_losses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int streak { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int drops { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int timestamp { get; set; }
    }

    public class GameHistories
    {
        public List<GameHistory> gameHistories { get; set; }
    }




    ///////////////////////////////////////////////////////////////////////////
    public class PlayersItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int profile_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string clan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int slot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int slot_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int rating { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rating_change { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int team { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int civ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string won { get; set; }
    }

    public class Match
{
    /// <summary>
    /// 
    /// </summary>
    public string match_id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string lobby_id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string version { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int num_players { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int num_slots { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int map_size { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int map_type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ranked { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int rating_type_id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string server { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int started { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<PlayersItem> players { get; set; }
}

public class Matches
{
    /// <summary>
    /// 
    /// </summary>
    public Match matche { get; set; }
}
}
