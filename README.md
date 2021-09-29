# LuckySlots
======
Original by Joker119\
Continued by Marco15453

# Description
Will run a 'slot machine' on a configurable timer (5 mins by default) that will give each player a (configurable) chance of receiving an item from a (configurable) list of possible choices.
Players will be informed when the slots are rolling and whether they were lucky or unlucky with configurable messages.
Supports blacklisting specific roles to not receive items.
Will never try to give SCP's and Spectators Items.

# Commands
Name | Permission | Description | CommandType
---- | ---------- | ----------- | -----------
roll | -/- | Causes an immediate roll of the slots without resetting the current timer. | RemoteAdmin

# Config
Name | Type | Description | Default Value
---- | ---- | ----------- | -------------
is_enabled | bool | Weather or not the plugin should be enabled? | true
timer | float | Time, in seconds, between each automatic slots roll. | 300
chance | float | The % chance each player has of receiving an item from the list each roll. | 30
items | HashSet | A list of ItemTypes seperated by comma (no spaces) of every item you want players to be able to receive. If you want a specific item to have a higher chance than others, include it multiple times in the list. | KeycardJanitor, Painkillers, Medkit
blacklisted_roles | HashSet | A list of RoleTypes, seperated by comma (no spaces) of the roles you don't want to be able to receive an item. (will never attempt to give items to SCP's or Spectators). | Tutorial
rolling | string | | The Lucky Slots are rolling..!
lucky | string | The message played when a player receives an item, $ITEM will always be replaced with the Item's name. | You got Lucky and received a $ITEM
unlucky | string | The message played when a player is eligable for an item, but did not receive one. | Aww, better luck next time.

# Default Config
```yml
lucky_slots:
  # Weather or not the plugin should be enabled?
  is_enabled: true
  # Time, in seconds, between each automatic slots roll.
  timer: 300
  # The % chance each player has of receiving an item from the list each roll.
  chance: 30
  # A list of ItemTypes seperated by comma (no spaces) of every item you want players to be able to receive. If you want a specific item to have a higher chance than others, include it multiple times in the list.
  items:
  - KeycardJanitor
  - Painkillers
  - Medkit
  # A list of RoleTypes, seperated by comma (no spaces) of the roles you don't want to be able to receive an item. (will never attempt to give items to SCP's or Spectators).
  blacklisted_roles:
  - Tutorial
  # The message to be played to people when the slot machine is rolling.
  rolling: The Lucky Slots are rolling..!
  # The message played when a player receives an item, $ITEM will always be replaced with the Item's name.
  lucky: You got Lucky and received a $ITEM
  # The message played when a player is eligable for an item, but did not receive one.
  unlucky: Aww, better luck next time.
```