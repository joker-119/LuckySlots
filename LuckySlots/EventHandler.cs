using Exiled.Events.EventArgs;
using MEC;

namespace LuckySlots
{
    internal sealed class EventHandler
    {
        public void onRoundStarted() => Plugin.Singleton.slotsCoroutine = Timing.RunCoroutine(Plugin.Singleton.RunSlots());
        public void onRoundEnded(RoundEndedEventArgs ev) => Timing.KillCoroutines(Plugin.Singleton.slotsCoroutine);
        public void onWaitingForPlayers() => Timing.KillCoroutines(Plugin.Singleton.slotsCoroutine);
    }
}
