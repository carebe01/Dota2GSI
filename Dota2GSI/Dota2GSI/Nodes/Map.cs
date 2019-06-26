﻿namespace Dota2GSI.Nodes
{
    /// <summary>
    /// Enum list for each Game State
    /// </summary>
    public enum DOTA_GameState
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// Disconnected
        /// </summary>
        DOTA_GAMERULES_STATE_DISCONNECT,

        /// <summary>
        /// Game is in progress
        /// </summary>
        DOTA_GAMERULES_STATE_GAME_IN_PROGRESS,

        /// <summary>
        /// Players are currently selecting heroes
        /// </summary>
        DOTA_GAMERULES_STATE_HERO_SELECTION,

        /// <summary>
        /// Game is starting
        /// </summary>
        DOTA_GAMERULES_STATE_INIT,

        /// <summary>
        /// Game is ending
        /// </summary>
        DOTA_GAMERULES_STATE_LAST,

        /// <summary>
        /// Game has ended, post game scoreboard
        /// </summary>
        DOTA_GAMERULES_STATE_POST_GAME,

        /// <summary>
        /// Game has started, pre game preparations
        /// </summary>
        DOTA_GAMERULES_STATE_PRE_GAME,

        /// <summary>
        /// Players are selecting/banning heroes
        /// </summary>
        DOTA_GAMERULES_STATE_STRATEGY_TIME,

        /// <summary>
        /// Waiting for everyone to connect and load
        /// </summary>
        DOTA_GAMERULES_STATE_WAIT_FOR_PLAYERS_TO_LOAD,

        /// <summary>
        /// Game is a custom game
        /// </summary>
        DOTA_GAMERULES_STATE_CUSTOM_GAME_SETUP
    }

    /// <summary>
    /// Enum list for each player team
    /// </summary>
    public enum PlayerTeam
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// No team
        /// </summary>
        None,

        /// <summary>
        /// Dire team
        /// </summary>
        Dire,

        /// <summary>
        /// Radiant team
        /// </summary>
        Radiant
    }

    /// <summary>
    /// Class representing information about the map
    /// </summary>
    public class Map : Node
    {
        /// <summary>
        /// Name of the current map
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Match ID of the current game
        /// </summary>
        public readonly long MatchID;

        /// <summary>
        /// Game time
        /// </summary>
        public readonly int GameTime;

        /// <summary>
        /// Clock time (time shown at the top of the game hud)
        /// </summary>
        public readonly int ClockTime;

        /// <summary>
        /// A boolean representing whether it is daytime
        /// </summary>
        public readonly bool IsDaytime;

        /// <summary>
        /// A boolean representing whether Nightstalker forced night time
        /// </summary>
        public readonly bool IsNightstalker_Night;

        /// <summary>
        /// Current game state
        /// </summary>
        public readonly DOTA_GameState GameState;

        /// <summary>
        /// A boolean representing if paused or not
        /// </summary>
        public readonly Paused;

        /// <summary>
        /// The winning team
        /// </summary>
        public readonly PlayerTeam Win_team;

        /// <summary>
        /// The name of the custom game
        /// </summary>
        public readonly string CustomGameName;

        /// <summary>
        /// The cooldown on ward purchases
        /// </summary>
        public readonly int Ward_Purchase_Cooldown;

        internal Map(string json_data) : base(json_data)
        {
            Name = GetString("name");
            MatchID = GetLong("matchid");
            GameTime = GetInt("game_time");
            ClockTime = GetInt("clock_time");
            IsDaytime = GetBool("daytime");
            IsNightstalker_Night = GetBool("nightstalker_night");
            GameState = GetEnum<DOTA_GameState>("game_state");
            Paused = GetBool("paused");
            Win_team = GetEnum<PlayerTeam>("win_team");
            CustomGameName = GetString("customgamename");
            Ward_Purchase_Cooldown = GetInt("ward_purchase_cooldown");
        }
    }
}
