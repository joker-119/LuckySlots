# LuckySlots
======
made by Joker 119
## Description
Will run a 'slot machine' on a configurable timer (5 mins by default) that will give each player a (configurable) chance of receiving an item from a (configurable) list of possible choices.
Players will be informed when the slots are rolling and whether they were lucky or unlucky with configurable messages.
Supports blacklisting specific roles to not receive items.
Will never try to give SCP's and Spectators Items.


### Config Settings
Config option | Config Type | Default Value | Description
:---: | :---: | :---: | :------
LuckySlots_enabled | bool | true | If the plugin should load or not.
LuckySlots_timer | float | 300 | Time, in seconds, between each automatic slots roll.
LuckySlots_chance | int | 30 | The % chance each player has of receiving an item from the list each roll.
LuckySlots_items | StringList | empty | A list of ItemNames seperated by comma (no spaces) of every item you want players to be able to receive. If you want a specific item to have a higher chance than others, include it multiple times in the list.
LuckySlots_blacklisted_roles | StringList | empty | A list of RoleNames, seperated by comma (no spaces) of the roles you don't want to be able to receive an item. (will never attempt to give items to SCP's or Spectators).
LuckySlots_rolling | string | The Lucky Slots are rolling..! | The message to be played to people when the slot machine is rolling.
LuckySlots_lucky | string | You got Lucky and received a $ITEM | The message played when a player receives an item, ``$ITEM`` will always be replaced with the Item's name.
LuckySlots_unlucky | string | Aww, better luck next time. | The message played when a player is eligable for an item, but did not receive one.

### Commands
  Command |  |  | Description
:---: | :---: | :---: | :------
roll | | | Causes an immediate roll of the slots without resetting the current timer.
