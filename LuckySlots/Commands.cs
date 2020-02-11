using EXILED;
using EXILED.Extensions;
using MEC;

namespace LuckySlots
{
	public class Commands
	{
		private readonly Plugin plugin;
		public Commands(Plugin plugin) => this.plugin = plugin;

		public void OnRaCommand(ref RACommandEvent ev)
		{
			string[] args = ev.Command.Split(' ');

			switch (args[0].ToLower())
			{
				case "roll":
					ev.Allow = false;
					Timing.RunCoroutine(plugin.Functions.DoSlotsThing());
					ev.Sender.RAMessage("Rolling..");
					break;
			}
		}
	}
}