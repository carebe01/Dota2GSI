namespace Dota2GSI.Nodes
{
    /// <summary>
    /// Enum for various player activities
    /// </summary>
    public enum PlayerActivity
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// In a menu
        /// </summary>
        Menu,

        /// <summary>
        /// In a game
        /// </summary>
        Playing
    }

    /// <summary>
    /// Class representing player information
    /// </summary>
    public class Player : Node
    {
        /// <summary>
        /// Player's steam ID
        /// </summary>
        public readonly string SteamID;

        /// <summary>
        /// Player's name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Player's current activity state
        /// </summary>
        public readonly PlayerActivity Activity;

        /// <summary>
        /// Player's amount of kills
        /// </summary>
        public readonly int Kills;

        /// <summary>
        /// Player's amount of deaths
        /// </summary>
        public readonly int Deaths;

        /// <summary>
        /// Player's amount of assists
        /// </summary>
        public readonly int Assists;

        /// <summary>
        /// Player's amount of last hits
        /// </summary>
        public readonly int LastHits;

        /// <summary>
        /// Player's amount of denies
        /// </summary>
        public readonly int Denies;

        /// <summary>
        /// Player's killstreak
        /// </summary>
        public readonly int KillStreak;

		/// <summary>
		/// Player's kill count on each victim <not implemented>
		/// </summary>
		public readonly string KillList; 


        /// <summary>
        /// Player's actions per minute
        /// </summary>
        public readonly int CommandsIssued;

        /// <summary>
        /// Player's team
        /// </summary>
        public readonly PlayerTeam Team;

        /// <summary>
        /// Player's amount of gold
        /// </summary>
        public readonly int Gold;

        /// <summary>
        /// Player's amount of reliable gold
        /// </summary>
        public readonly int GoldReliable;

        /// <summary>
        /// Player's amount of unreliable gold
        /// </summary>
        public readonly int GoldUnreliable;

        /// <summary>
        /// Player's amount of gold from hero kills
        /// </summary>
        public readonly int GoldFromHeroKills;

        /// <summary>
        /// Player's amount of gold from creep kills
        /// </summary>
        public readonly int GoldFromCreepKills;

		/// <summary>
		/// Player's gold from passive income
		/// </summary>
		public readonly int GoldFromIncome;

		/// <summary>
		/// Player's gold from shared from team income
		/// </summary>
		public readonly int GoldFromShared;

		/// <summary>
		/// Player's gold per minute
		/// </summary>
		public readonly int GoldPerMinute;

		/// <summary>
		/// Player's experience per minute
		/// </summary>
		public readonly int ExperiencePerMinute;

        /// <summary>
        /// Player's net worth
        /// </summary>
        public readonly int NetWorth;

        /// <summary>
        /// Players hero damage done
        /// </summary>
        public readonly int HeroDamage;

        /// <summary>
        /// Amount of wards purchased by player
        /// </summary>
        public readonly int WardsPurchased;

        /// <summary>
        /// Amount of wards placed by player
        /// </summary>
        public readonly int WardsPlaced;

        /// <summary>
        /// Amount of wards destroyed by player
        /// </summary>
        public readonly int WardsDestroyed;

        /// <summary>
        /// Amount of runes used by player
        /// </summary>
        public readonly int RunesActivated;

        /// <summary>
        /// Amount of camps stacked by player
        /// </summary>
        public readonly int CampsStacked;

        /// <summary>
        /// Players spent gold on support items (wards, smokes, dust)
        /// </summary>
        public readonly int SupportGoldSpent;

        /// <summary>
        /// Players gold spent on consumables
        /// </summary>
        public readonly int ConsumableGoldSpent;

        /// <summary>
        /// Players spent gold on items
        /// </summary>
        public readonly int ItemGoldSpent;

        /// <summary>
        /// Players lost gold from deaths
        /// </summary>
        public readonly int GoldLostToDeath;

        /// <summary>
        /// Players spent gold on buy backs
        /// </summary>
        public readonly int GoldSpentOnBuybacks;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="json_data"></param>

        internal Player(string json_data) : base(json_data)
        {
            SteamID = GetString("steamid");
            Name = GetString("name");
            Activity = GetEnum<PlayerActivity>("activity");
            Kills = GetInt("kills");
            Deaths = GetInt("deaths");
            Assists = GetInt("assists");
            LastHits = GetInt("last_hits");
            Denies = GetInt("denies");
            KillStreak = GetInt("kill_streak");
            CommandsIssued = GetInt("commands_issued");
            Team = GetEnum<PlayerTeam>("team_name");
            Gold = GetInt("gold");
            GoldReliable = GetInt("gold_reliable");
            GoldUnreliable = GetInt("gold_unreliable");
            GoldFromHeroKills = GetInt("gold_from_hero_kills");
            GoldFromCreepKills = GetInt("gold_from_creep_kills");
            GoldFromIncome = GetInt("gold_from_income");
            GoldFromShared = GetInt("gold_from_shared");
            GoldPerMinute = GetInt("gpm");
            ExperiencePerMinute = GetInt("xpm");
            NetWorth = GetInt("net_worth");
            HeroDamage = GetInt("hero_damage");
            WardsPurchased = GetInt("wards_purchased");
            WardsPlaced = GetInt("wards_placed");
            WardsDestroyed = GetInt("wards_destroyed");
            RunesActivated = GetInt("runes_activated");
            CampsStacked = GetInt("camps_stacked");
            SupportGoldSpent = GetInt("support_gold_spent");
            ConsumableGoldSpent = GetInt("consumable_gold_spent");
            ItemGoldSpent = GetInt("item_gold_spent");
            GoldLostToDeath = GetInt("gold_lost_to_death");
            GoldSpentOnBuybacks = GetInt("gold_spent_on_buybacks");
            KillList = GetString("kill_list"); //not implemented
        }
    }
}
