using CommandSystem;
using System;
using MEC;

namespace LuckySlots
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class RollCommand : ICommand
    {
        public string Command { get; } = "roll";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Causes an immediate roll of the slots without resetting the current timer.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Timing.RunCoroutine(Plugin.Singleton.RunSlots());
            response = "Rolling...";
            return true;
        }
    }
}
