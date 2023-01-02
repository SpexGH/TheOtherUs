# Modifiers
## Bloody

If killed, the Bloody Modifier will leave a trail for x-seconds on their killer. The trail will have the color of the killed person.\
\
**NOTE**
- Impostor, Neutral or Crewmate roles can have this Modifier

### Game Options
| Name | Description |
|----------|:-------------:|
| Bloody Spawn Chance | -
| Bloody Quantity | -
| Trail duration | -
-----------------------

## AntiTeleport

The Anti Teleport Modifier prevents the player from getting teleported to the Meeting Table if a body gets reported or an Emergency Meeting is called.\
The player will start the round where the previous one ended (Emergency Meeting Call/Body Report).\
\
**NOTE**
- Impostor, Neutral or Crewmate roles can have this Modifier

### Game Options
| Name | Description |
|----------|:-------------:|
| Anti Teleport Spawn Chance | -
| Anti Teleport Quantity | -
-----------------------

## TieBreaker

If the Voting ends in a tie, the Tie Breaker takes place and the player with the Tie Breaker Modifier gets an extra vote thats not visible to anyone.\
Everyone will know if the Tie Breaker was involved in the Meeting or not.\
\
**NOTE**
- Impostor, Neutral or Crewmate roles can have this Modifier
- There can only be on player with this Modifier

### Game Options
| Name | Description |
|----------|:-------------:|
| Tie Breaker Spawn Chance | -
-----------------------

## Bait

The Bait forces the killer to self report the body (you can configure a delay in the options).\
There can be more than one Bait.

**NOTE:**
- If the Sheriff has the Bait Modifier and dies while trying to kill a Crewmate, the Sheriff will *NOT* report themself.
- Impostor, Neutral or Crewmate roles can have this Modifier

### Game Options
| Name | Description
|----------|:-------------:|
| Bait Spawn Chance | -
| Bait Quantity | -
| Bait Report Delay Min | -
| Bait Report Delay Max | -
| Warn The Killer With A Flash | -
-----------------------

## Lovers

There are always two Lovers which are linked together.\
Their primary goal is it to stay alive together until the end of the game.\
If one Lover dies (and the option is activated), the other Lover suicides.\
You can specify the chance of one Lover being an Impostor.\
The Lovers never know the role of their partner, they only see who their partner is.\
The Lovers win, if they are both alive when the game ends. They can also win with their original team (e.g. a dead Impostor Lover can win with the Impostors, an Arsonist Lover can still achieve an Arsonist win).\
If one of the Lovers is a killer (i.e. Jackal/Sidekick/Impostor), they can achieve a "Lovers solo win" where only the Lovers win.\
If there is no killer among the Lovers (e.g. an Arsonist Lover + Crewmate Lover) and they are both alive when the game ends, they win together with the Crewmates.\
If there's an Impostor/Jackal + Crewmate Lover in the game, the tasks of a Crewmate Lover won't be counted (for a task win) as long as they're alive.\
If the Lover dies, their tasks will also be counted.\
You can enable an exclusive chat only for Lovers.

**NOTE:**
In a 2 Crewmates vs 2 Impostors (or 2 members of team Jackal) and the Lovers are not in the same team, the game is not automatically over since the Lovers can still achieve a solo win. E.g. if there are the following roles Impostor + ImpLover + Lover + Crewmate left, the game will not end and the next kill will decide if the Impostors or Lovers win.

### Game Options
| Name | Description |
|----------|:-------------:|
| Lovers Spawn Chance | -
| Chance That One Lover Is Impostor | -
| Both Lovers Die | Whether the second Lover suicides, if the first one dies
| Enable Lover Chat | -
-----------------------

**NOTE:**
- The Modifier **Lover** can't be guessed, you'll have to guess the primary role of one of the Lovers, to kill both of them.

## Sunglasses

The Sunglasses will lower the Crewmate's vision by a small percentage. The percentage is configurable in the options.\
The vision will also be affected when lights out.

**NOTE:**
- Sunglasses only affects Crewmates.
- If you have the Sunglasses Modifier and get sidekicked, you will lose the Modifier.

### Game Options
| Name | Description
|----------|:-------------:|
| Sunglasses Spawn Chance | -
| Sunglasses Quantity | -
| Vision with sunglasses | -
-----------------------

## Mini

The Mini's character is smaller and hence visible to everyone in the game.\
The Mini cannot be killed until it turns 18 years old, however it can be voted out.

**Impostor/Jackal Mini:**
- While growing up the kill cooldown is doubled. When it's fully grown up its kill cooldown is 2/3 of the default one.
- If it gets thrown out of the ship, everything is fine.

**Crewmate Mini:**
- The Crewmate Mini aims to play out the strength its invincibility in the early game.
- If it gets thrown out of the ship before it turns 18, everyone loses. So think twice before you vote out a Mini.

**Neutral Mini:**
- The cooldown is not effected, except for the Team Jackal/Sidekick.
- If it gets thrown out of the ship, everything is fine except for the Jester.
- If the Jester Mini gets voted out the game will end in a Jester win.

**NOTE:**
- If the Sheriff tries to kill the Mini before it's fully grown, nothing happens.
- The Sheriff can kill the Impostor/Neutral Mini, but only if it's fully grown up.
- If the Mini's primary role is guessed correctly, it dies like every other role and nothing further happens.

### Game Options
| Name | Description |
|----------|:-------------:|
| Mini Spawn Chance | -
| Mini  | Mini Growing Up Duration
| Mini Grows Up In Meeting | -
-----------------------

## VIP

An Impostor, Jackal or Crewmate can be affected by the VIP (Very Important Player) Modifier.\
The VIP will show everyone when he dies with a flash similar to the Seer Flash.\
If the option Show Team Color is On, then everyone will get a flash in the color of the team the player was part of.

Teams:
- Impostor = Red
- Neutral = Blue
- Crewmate = White

### Game Options
| Name | Description
|----------|:-------------:|
| VIP Spawn Chance | -
| VIP Quantity | -
| Show Team Color | -
-----------------------

## Invert

The Invert Modifier inverts your controls (no matter if keyboard or mouse).\
\
**NOTE**
- Impostor, Neutral or Crewmate roles can have this Modifier

### Game Options
| Name | Description
|----------|:-------------:|
| Invert Spawn Chance | -
| Invert Quantity | -
-----------------------

## Chameleon

The Chameleon becomes (partially or fully) invisible when standing still for x-seconds (depends on the settings).\
\
**NOTE**
- You can use abilities while being invisible, only moving will make you visible again
- Impostor, Neutral or Crewmate roles can have this Modifier

### Game Options
| Name | Description
|----------|:-------------:|
| Chameleon Spawn Chance | -
| Chameleon Quantity | -
| Time Until Fading Starts | -
| Fade Duration | - 
| Minimum Visibility | -
-----------------------

## Fanatic

The Fanatic modifier is a Crewmate only modifier. If the Impostor attempts to kill the Fanatic, the Impostor is instantly blanked and the Fanatic joins team Impostor.

### Game Options
| Name | Description
|----------|:-------------:|
| Fanatic Spawn Chance | -
-----------------------

## Tunneler

The Tunneler modifier is a Crewmate only modifier. When the Tunneler is done with their tasks, they gain the abilty to vent.

### Game Options
| Name | Description
|----------|:-------------:|
| Fanatic Spawn Chance | -
-----------------------

## Indomitable

Indomitable is a modifier that keeps you protected from the Assassin.
If the Assassin attempts to guess an Indomitable player, the guess will fail instantly, and the Indomitable will be alerted.

### Game Options
| Name | Description
|----------|:-------------:|
| Indomitable Spawn Chance | -
-----------------------

## Blind

The Blind Modifier prevents your report button from lighting up. You can still click it to report, and you can still click a body to report it.
The Blind can affect all teams (Impostor, Neutral, Crewmate).

### Game Options
| Name | Description
|----------|:-------------:|
| Blind Spawn Chance | -
-----------------------

## Sleuth

The Sleuth Modifier tells you the roles of bodies you report.\
The Sleuth can affect all teams (Impostor, Neutral, Crewmate).

### Game Options
| Name | Description
|----------|:-------------:|
| Sleuth Spawn Chance | -
-----------------------

## Torch

The Torch Modifier is a crewmate modifier that makes it so that the players vision doesn't get reduced when the lights are sabotaged.

### Game Options
| Name | Description
|----------|:-------------:|
| Torch Spawn Chance | -
| Torch Quantity | -
-----------------------

## Watcher

The Watcher modifier allows the player to see everyone's votes during meetings.

### Game Options
| Name | Description
|----------|:-------------:|
| Watcher Spawn Chance | -
-----------------------

## Multitasker

The Multitasker modifier is a Crewmate only modifier. This modifiers makes all the players tasks transparent.

### Game Options
| Name | Description
|----------|:-------------:|
| Multitasker Spawn Chance | -
| Multitasker Quantity | -
-----------------------

## Disperser

The Disperser modifier is an Impostor only modifier. This modifier gives the impostor a 1 time use ability to send all players to a random location on the map.\
\
**NOTE:**
- Players with Anti Teleport are not effected by a disperse.

### Game Options
| Name | Description
|----------|:-------------:|
| Disperser Spawn Chance | -

-----------------------