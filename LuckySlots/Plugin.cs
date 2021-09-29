using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using MEC;

using Server = Exiled.Events.Handlers.Server;

namespace LuckySlots
{
	public class Plugin : Plugin<Config>
	{
        internal static Plugin Singleton;

        public override string Name => "Lucky Slots";
        public override string Author => "Original By Joker119, Continued by Marco15453";
        public override Version Version => new Version(1, 2, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

		private EventHandler eventHandler;
        private Random rnd = new Random();

        public CoroutineHandle slotsCoroutine;

        public override void OnEnabled()
        {
            Singleton = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

		private void RegisterEvents()
        {
			eventHandler = new EventHandler();

			Server.RoundStarted += eventHandler.onRoundStarted;
			Server.RoundEnded += eventHandler.onRoundEnded;
			Server.WaitingForPlayers += eventHandler.onWaitingForPlayers;
        }

		private void UnregisterEvents()
        {
            Server.RoundStarted -= eventHandler.onRoundStarted;
            Server.RoundEnded -= eventHandler.onRoundEnded;
            Server.WaitingForPlayers -= eventHandler.onWaitingForPlayers;

            eventHandler = null;
        }

        public IEnumerator<float> RunSlotsLoop()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(Config.Timer);
                Map.Broadcast(5, Config.Rolling, Broadcast.BroadcastFlags.Normal, true);
                yield return Timing.WaitForSeconds(2f);

                foreach (Player ply in Player.List)
                {
                    if (Config.BlacklistedRoles.Contains(ply.Role) || ply.Role == RoleType.Spectator || !ply.IsHuman)
                        continue;

                    if (rnd.Next(100) < Config.Chance)
                    {
                        ItemType item = Config.Items.ElementAt(rnd.Next(Config.Items.Count));
                        ply.AddItem(item);
                        ply.Broadcast(5, Config.Lucky.Replace("$ITEM", item.ToString()), Broadcast.BroadcastFlags.Normal, true);
                    }
                    else ply.Broadcast(5, Config.Unlucky, Broadcast.BroadcastFlags.Normal, true);
                }
            }
        }

        public IEnumerator<float> RunSlots()
        {
            Map.Broadcast(5, Config.Rolling, Broadcast.BroadcastFlags.Normal, true);
            yield return Timing.WaitForSeconds(2f);

            foreach (Player ply in Player.List)
            {
                if (Config.BlacklistedRoles.Contains(ply.Role) || ply.Role == RoleType.Spectator || !ply.IsHuman)
                    continue;

                if (rnd.Next(100) < Config.Chance)
                {
                    ItemType item = Config.Items.ElementAt(rnd.Next(Config.Items.Count));
                    ply.AddItem(item);
                    ply.Broadcast(5, Config.Lucky.Replace("$ITEM", item.ToString()), Broadcast.BroadcastFlags.Normal, true);
                }
                else ply.Broadcast(5, Config.Unlucky, Broadcast.BroadcastFlags.Normal, true);
            }
        }
    }
}