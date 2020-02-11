using System;
using System.Collections.Generic;
using EXILED;
using MEC;

namespace LuckySlots
{
	public class Plugin : EXILED.Plugin
	{
		public Methods Functions { get; private set; }
		public EventHandlers EventHandlers { get; private set; }
		public Commands Commands { get; private set; }
		public Random Gen = new Random();
		public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

		public bool Enabled;
		public float Timer;
		public float Chance;
		public List<ItemType> Items = new List<ItemType>();
		public List<RoleType> BlacklistedRoles = new List<RoleType>();
		public string Rolling;
		public string Lucky;
		public string UnLucky;

		public override void OnEnable()
		{
			Functions = new Methods(this);
			ReloadConfig();
			if (!Enabled)
				return;
			
			EventHandlers = new EventHandlers(this);
			Commands = new Commands(this);

			Events.WaitingForPlayersEvent += EventHandlers.OnWaitingForPlayers;
			Events.RoundStartEvent += EventHandlers.OnRoundStart;
			Events.RoundEndEvent += EventHandlers.OnRoundEnd;
			Events.RemoteAdminCommandEvent += Commands.OnRaCommand;
		}

		public override void OnDisable()
		{
			Events.WaitingForPlayersEvent -= EventHandlers.OnWaitingForPlayers;
			Events.RoundStartEvent -= EventHandlers.OnRoundStart;
			Events.RoundEndEvent -= EventHandlers.OnRoundEnd;
			Events.RemoteAdminCommandEvent -= Commands.OnRaCommand;

			EventHandlers = null;
			Functions = null;
			Commands = null;
		}

		public override void OnReload()
		{
		}

		public override string getName { get; } = "LuckySlots";

		private void ReloadConfig()
		{
			Log.Info("Loading Configs..");
			Enabled = Config.GetBool("LuckySlots_enabled", true);
			Timer = Config.GetFloat("LuckySlots_timer", 300f);
			Chance = Config.GetFloat("LuckySlots_chance", 30f);

			Items = Functions.ParseItemSettings(Config.GetString("LuckySlots_items"));
			if (Items.Count == 0)
				Log.Warn("No items were parsed from the config.");

			BlacklistedRoles = Functions.ParseRoleBlacklist(Config.GetString("LuckySlots_blacklisted_roles"));
			if (BlacklistedRoles.Count == 0)
				Log.Warn("No roles were parsed from the config.");

			Rolling = Config.GetString("LuckySlots_rolling", "The Lucky Slots are rolling..!");
			Lucky = Config.GetString("LuckySlots_lucky", "You got Lucky and received a $ITEM");
			UnLucky = Config.GetString("LuckySlots_unlucky", "Aww, better luck next time!");
		}
	}
}