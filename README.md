# Dota 2 GSI (Game State Integration)
A C# library to interface the Game State Integration found in Dota 2.

## What is Game State Integration

Game State Integration hasn't been officially released for Dota 2, but it has been available for Counter-Strike: Global Offensive for a few months now. The concept is the same as CSGO's, you can read about [Counter-Strike Game State Integration here](https://developer.valvesoftware.com/wiki/Counter-Strike:_Global_Offensive_Game_State_Integration).

## About Dota 2 GSI

This library provides easy means of implementing Game State Integration from Dota 2 into C# applications. Library listens for HTTP POST requests made by the game on a specific address and port. Upon receiving a request, the game state is parsed and can be used.

JSON parsing is done though help of Newtonsoft's [JSON.Net Framework](http://www.newtonsoft.com/json).

After starting the `GameStateListener` instance, it will continuously listen for incoming HTTP requests. Upon a received request, the contents will be parsed into a `GameState` object.


## Installation
Via NuGet:

```
Install-Package Dota2GSI
```

Manual installation:

1. Get the [latest binaries](https://github.com/antonpup/Dota2GSI/releases/latest)  
2. Get the [JSON Framework .dll by Newtonsoft](https://github.com/JamesNK/Newtonsoft.Json/releases)  
3. Extract Newtonsoft.Json.dll from `Bin\Net45\Newtonsoft.Json.dll`  
4. Add a reference to both Dota2GSI.dll and Newtonsoft.Json.dll in your project  

## Usage
1. Create a `GameStateListener` instance by providing a port or passing a specific URI:

```C#
GameStateListener gsl = new GameStateListener(3000); //http://localhost:3000/
GameStateListener gsl = new GameStateListener("http://127.0.0.1:81/");
```

**Please note**: If your application needs to listen to a URI other than `http://localhost:*/` (for example `http://192.168.2.2:100/`), you need to ensure that it is run with administrator privileges.  
In this case, `http://127.0.0.1:*/` is **not** equivalent to `http://localhost:*/`.

2. Create a handler:

```C#
void OnNewGameState(GameState gs)
{
    //do stuff
}
```

3. Subscribe to the `NewGameState` event:

```C#
gsl.NewGameState += new NewGameStateHandler(OnNewGameState);
```

4. Use `GameStateListener.Start()` to start listening for HTTP POST requests from the game client. This method will return `false` if starting the listener fails (most likely due to insufficient privileges).

## TODO
Add Buildings
Add Wearables
Update layout

## Layout

```
GameState
+-- Auth
    +-- Token
+-- Provider
    +-- Name
    +-- AppID
    +-- Version
    +-- TimeStamp
+-- Map
    +-- Name
    +-- MatchID
    +-- GameTime
    +-- ClockTime
    +-- IsDaytime
    +-- IsNightstalker_Night
    +-- GameState
    +-- Paused
    +-- Win_team
    +-- CustomGameName
    +-- Ward_Purchase_Cooldown
    +-- Radiant_Ward_Purchase_Cooldown (SPECTATOR ONLY)
    +-- Dire_Ward_Purchase_Cooldown (SPECTATOR ONLY)
    +-- Roshan_State (SPECTATOR ONLY)
    +-- RoshanStateEndTime (SPECTATOR ONLY)
    +-- Radiant_Win_Chance (SPECTATOR ONLY)
+-- Player
    +-- SteamID
    +-- Name
    +-- ProName
    +-- Activity
    +-- Kills
    +-- Deaths
    +-- Assists
    +-- LastHits
    +-- Denies
    +-- KillStreak
    +-- KillList[]
        +-- id
        +-- value
    +-- CommandsIssued
    +-- Team
    +-- Gold
    +-- GoldReliable
    +-- GoldUnreliable
    +-- GoldFromHeroKills
    +-- GoldFromCreepKills
    +-- GoldFromIncome
    +-- GoldFromShared
    +-- GoldPerMinute
    +-- ExperiencePerMinute
    +-- NetWorth (SPECTATOR ONLY)
    +-- HeroDamage (SPECTATOR ONLY)
    +-- WardsPurchased (SPECTATOR ONLY)
    +-- WardsPlaced (SPECTATOR ONLY)
    +-- WardsDestroyed (SPECTATOR ONLY)
    +-- RunesActivated (SPECTATOR ONLY)
    +-- CampsStacked (SPECTATOR ONLY)
    +-- SupportGoldSpent (SPECTATOR ONLY)
    +-- GoldLostToDeath (SPECTATOR ONLY)
    +-- GoldSpentOnBuybacks (SPECTATOR ONLY)
+-- Hero
    +-- Location (X,Y)
    +-- ID
    +-- Name
    +-- Level
    +-- IsAlive
    +-- SecondsToRespawn
    +-- BuybackCost
    +-- BuybackCooldown
    +-- Health
    +-- MaxHealth
    +-- HealthPercent
    +-- Mana
    +-- MaxMana
    +-- ManaPercent
    +-- IsSilenced
    +-- IsStunned
    +-- IsDisarmed
    +-- IsMagicImmune
    +-- IsHexed
    +-- IsMuted
    +-- IsBreak
    +-- HasAghanimsScepter
    +-- HasAghanimsShard
    +-- HasDebuff
    +-- SelectedUnit (SPECTATOR ONLY)
    +-- TalentTreeSpec[]
+-- Abilities
    +-- Count
    +-- Attributes
    +-- Ability[]
        +-- Name
        +-- Level
        +-- CanCast
        +-- IsPassive
        +-- IsActive
        +-- Cooldown
        +-- IsUltimate
+-- Items
    +-- CountInventory
    +-- GetInventoryAt( index )
    +-- InventoryContains( itemname )
    +-- InventoryIndexOf( itemname )
    +-- CountStash
    +-- GetStashAt( index )
    +-- StashContains( itemname )
    +-- StashIndexOf( itemname )
    +-- GetTeleport
    +-- GetNeutral
    +-- NeutralContains
+-- Previously (Previous information from Game State)
+-- Added (Added information to the new Game State)
```

### Item, and Hero names
Item and hero names are presented in their "internal name" format. A full list of item names can be found [here](http://dota2.gamepedia.com/Cheats#Item_names) and a full list of heroes can be located [here](http://dota2.gamepedia.com/Cheats#Hero_names).

##### Examples:
```C#
int Health = gs.Hero.Health; // 560
int MaxHealth = gs.Hero.MaxHealth; // 560
string HeroName = gs.Hero.Name; //npc_dota_hero_omniknight
int Level = gs.Hero.Level; //1

Console.WriteLine("You are playing as " + HeroName + " with " + Health + "/" + MaxHealth + " health and level " + Level);
//You are playing as npc_dota_hero_omniknight with 560/560 health and level 1

```

## Null value handling

In case the JSON did not contain the requested information, these values will be returned:

Type|Default value
----|-------------
int|-1
string| String.Empty

All Enums have a value `enum.Undefined` that serves the same purpose.

## Credits
Special thanks to [rakijah](https://github.com/rakijah) for his CSGO Game State Integration library.

Thanks to [judge2020](https://github.com/judge2020) for providing an example program.
