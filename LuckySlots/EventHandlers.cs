using EXILED;
using MEC;

namespace LuckySlots
{
	public class EventHandlers
	{
		private readonly Plugin plugin;
		public EventHandlers(Plugin plugin) => this.plugin = plugin;

		public void OnWaitingForPlayers()
		{
			foreach (CoroutineHandle handle in plugin.Coroutines)
				Timing.KillCoroutines(handle);
		}

		public void OnRoundStart()
		{
			plugin.Coroutines.Add(Timing.RunCoroutine(plugin.Functions.RunSlotsTimer()));
		}

		public void OnRoundEnd()
		{
			foreach (CoroutineHandle handle in plugin.Coroutines)
				Timing.KillCoroutines(handle);
		}
	}
}