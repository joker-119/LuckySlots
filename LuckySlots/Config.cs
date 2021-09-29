using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace LuckySlots
{
    public sealed class Config : IConfig
    {
        [Description("Weather or not the plugin should be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Time, in seconds, between each automatic slots roll.")]
        public float Timer { get; set; } = 300f;

        [Description("The % chance each player has of receiving an item from the list each roll.")]
        public float Chance { get; set; } = 30f;

        [Description("A list of ItemTypes seperated by comma (no spaces) of every item you want players to be able to receive. If you want a specific item to have a higher chance than others, include it multiple times in the list.")]
        public HashSet<ItemType> Items { get; set; } = new HashSet<ItemType>()
        {
            ItemType.KeycardJanitor,
            ItemType.Painkillers,
            ItemType.Medkit
        };

        [Description("A list of RoleTypes, seperated by comma (no spaces) of the roles you don't want to be able to receive an item. (will never attempt to give items to SCP's or Spectators).")]
        public HashSet<RoleType> BlacklistedRoles { get; set; } = new HashSet<RoleType>
        {
            RoleType.Tutorial
        };

        [Description("The message to be played to people when the slot machine is rolling.")]
        public string Rolling { get; set; } = "The Lucky Slots are rolling..!";

        [Description("The message played when a player receives an item, $ITEM will always be replaced with the Item's name.")]
        public string Lucky { get; set; } = "You got Lucky and received a $ITEM";

        [Description("The message played when a player is eligable for an item, but did not receive one.")]
        public string Unlucky { get; set; } = "Aww, better luck next time.";
    }
}
