using System;
using System.Collections.Generic;
using System.Linq;
using EXILED.Extensions;
using GameCore;
using MEC;
using Log = EXILED.Log;

namespace LuckySlots
{
	public class Methods
	{
		private readonly Plugin plugin;
		public Methods(Plugin plugin) => this.plugin = plugin;

		public List<ItemType> ParseItemSettings(string types)
		{
			string[] list = types.Split(',');
			List<ItemType> items = new List<ItemType>();
			foreach (string s in list)
			{
				try
				{
					items.Add((ItemType) Enum.Parse(typeof(ItemType), s));
				}
				catch (Exception)
				{
					Log.Error($"Failed to parse ItemType: {s}");
				}
			}

			return items;
		}

		public List<RoleType> ParseRoleBlacklist(string types)
		{
			string[] list = types.Split(',');
			List<RoleType> roles = new List<RoleType>();
			foreach (string s in list)
			{
				try
				{
					roles.Add((RoleType) Enum.Parse(typeof(RoleType), s));
				}
				catch (Exception)
				{
					Log.Error($"Failed to parse RoleType: {s}");
				}
			}

			return roles;
		}

		public IEnumerator<float> RunSlotsTimer()
		{
			for (;;)
			{
				yield return Timing.WaitForSeconds(plugin.Timer);
				
				Timing.RunCoroutine(DoSlotsThing());
			}
		}

		public IEnumerator<float> DoSlotsThing()
		{
			PlayerManager.localPlayer.gameObject.GetComponent<Broadcast>().RpcAddElement(plugin.Rolling, 2, false);
			yield return Timing.WaitForSeconds(2f);
			foreach (ReferenceHub hub in Player.GetHubs())
			{
				if (plugin.BlacklistedRoles.Contains(hub.characterClassManager.CurClass) || hub.characterClassManager.CurClass == RoleType.Spectator || !hub.characterClassManager.IsHuman()) 
					continue;
				
				if (plugin.Gen.Next(100) < plugin.Chance)
				{
					int r = plugin.Gen.Next(plugin.Items.Count);
					hub.GiveItem(plugin.Items[r], 60);
					hub.gameObject.GetComponent<Broadcast>().TargetAddElement(hub.scp079PlayerScript.connectionToClient, plugin.Lucky.Replace("$ITEM", plugin.Items[r].ToString()), 5, false);
				}
				else
					hub.gameObject.GetComponent<Broadcast>().TargetAddElement(hub.scp079PlayerScript.connectionToClient, plugin.UnLucky, 5, false);
			}
		}
	}
}