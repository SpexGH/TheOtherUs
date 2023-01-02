# Neutral Roles
## Jester
### **Team: Neutral**
The Jester does not have any tasks. They win the game as a solo, if they get voted out during a meeting.

### Game Options
| Name | Description |
|----------|:-------------:|
| Jester Spawn Chance | -
| Jester Can Call Emergency Meeting | Option to disable the emergency button for the Jester
| Jester Can Hide in Vent | -
| Jester Has Imposter Vision | -
-----------------------

## Arsonist
### **Team: Neutral**
The Arsonist does not have any tasks, they have to win the game as a solo.\
The Arsonist can douse other players by pressing the douse button and remaining next to the player for a few seconds.\
If the player that the Arsonist douses walks out of range, the cooldown will reset to 0.\
After dousing everyone alive the Arsonist can ignite all the players which results in an Arsonist win.

### Game Options
| Name | Description |
|----------|:-------------:|
| Arsonist Spawn Chance | -
| Arsonist Countdown | -
| Arsonist Douse Duration | The time it takes to douse a player
-----------------------

## Jackal
### **Team: Jackal**
The Jackal is part of an extra team, that tries to eliminate all the other players.\
The Jackal has no tasks and can kill Impostors, Crewmates and Neutrals.\
The Jackal (if allowed by the options) can select another player to be their Sidekick.
Creating a Sidekick removes all tasks of the Sidekick and adds them to the team Jackal. The Sidekick loses their current role (except if they're a Lover, then they play in two teams).
The "Create Sidekick Action" may only be used once per Jackal or once per game (depending on the options).
The Jackal can also promote Impostors to be their Sidekick, but depending on the options the Impostor will either really turn into the Sidekick and leave the team Impostors or they will just look like the Sidekick to the Jackal and remain as they were.\
Also if a Spy or Impostor gets sidekicked, they still will appear red to the Impostors.

The team Jackal enables multiple new outcomes of the game, listing some examples here:
- The Impostors could be eliminated and then the crew plays against the team Jackal.
- The Crew could be eliminated, then the Team Jackal fight against the Impostors (The Crew can still make a task win in this scenario)

The priority of the win conditions is the following:
1. Crewmate Mini lose by vote
2. Jester wins by vote
3. Arsonist win
4. Team Impostor wins by sabotage
5. Team Crew wins by tasks (also possible if the whole Crew is dead)
6. Lovers among the last three players win
7. Team Jackal wins by outnumbering (When the team Jackal contains an equal or greater amount of players than the Crew and there are 0 Impostors left and team Jackal contains no Lover)
8. Team Impostor wins by outnumbering (When the team Impostors contains an equal or greater amount of players than the Crew and there are 0 players of the team Jackal left and team Impostors contains no Lover)
9. Team Crew wins by outnumbering (When there is no player of the team Jackal and the team Impostors left)

**NOTE:**
- The Jackal (and their Sidekick) may be killed by a Sheriff.
- A Jackal cannot target the Mini, while it's growing up. After that they can kill it or select it as its Sidekick.
- The Crew can still win, even if all of their members are dead, if they finish their tasks fast enough (That's why converting the last Crewmate with tasks left into a Sidekick results in a task win for the crew.)

If both Impostors and Jackals are in the game, the game continues even if all Crewmates are dead. Crewmates may still win in this case by completing their tasks. Jackal and Impostor have to kill each other.

### Game Options
| Name | Description
|----------|:-------------:|
| Jackal Spawn Chance | - |
| Jackal/Sidekick Kill Cooldown | Kill cooldown |
| Jackal Create Sidekick Cooldown | Cooldown before a Sidekick can be created |
| Jackal can use vents | Yes/No |
| Jackal can create a Sidekick | Yes/No |
| Jackals promoted from Sidekick can create a Sidekick | Yes/No (to prevent the Jackal team from growing) |
| Jackals can make an Impostor to their Sidekick | Yes/No (to prevent a Jackal from turning an Impostor into a Sidekick, if they use the ability on an Impostor they see the Impostor as Sidekick, but the Impostor isn't converted to Sidekick. If this option is set to "No" Jackal and Sidekick can kill each other.) |
| Kill A Failed Sidekick Attempt | Yes/No |
| Jackal and Sidekick have Impostor vision | - |
-----------------------

## Sidekick
### **Team: Jackal**
Gets assigned to a player during the game by the "Create Sidekick Action" of the Jackal and joins the Jackal in their quest to eliminate all other players.\
Upon the death of the Jackal (depending on the options), they might get promoted to Jackal themself and potentially even assign a Sidekick of their own.\
\
**NOTE:**
- A player that converts into a Sidekick loses their previous role and tasks (if they had one).
- The Sidekick may be killed by a Sheriff.
- The Sidekick cannot target the Mini, while it's growing up.

### Game Options
| Name | Description
|----------|:-------------:|
| Jackal/Sidekick Kill Cooldown | Uses the same kill cooldown setting as the Jackal |
| Sidekick gets promoted to Jackal on Jackal death |  Yes/No |
| Sidekick can kill | Yes/No |
| Sidekick can use vents | Yes/No |
-----------------------

## Vulture
### **Team: Neutral**

The Vulture does not have any tasks, they have to win the game as a solo.\
The Vulture is a neutral role that must eat a specified number of corpses (depending on the options) in order to win.\
Depending on the options, when a player dies, the Vulture gets an arrow pointing to the corpse.\
If there is a Vulture in the game, there can't be a Cleaner.

**NOTE**
- If the corpse is on a different floor on Submerged, the arrow will always point to the elevator

### Game Options
| Name | Description |
|----------|:-------------:|
| Vulture Spawn Chance | -
| Vulture Countdown | -
| Number Of Corpses Needed To Be Eaten | Corpes needed to be eaten to win the game
| Vulture Can Use Vents | -
| Show Arrows Pointing Towards The Corpes | -
-----------------------

## Lawyer
### **Team: Neutral**
The Lawyer is a neutral role that has a client.\
The client might be an Impostor or Jackal which is no Lover.\
Depending on the options, the client can also be a Jester.\
The Lawyer needs their client to win in order to win the game.\
Their client doesn't know that it is their client.\
If their client gets voted out, the Lawyer dies with the client.\
If their client dies, the Lawyer changes their role and becomes the [Pursuer](#pursuer), which has a different goal to win the game.\
\
How the Lawyer wins:
- Lawyer dead/alive, client alive and client wins: The Lawyer wins together with the team of the client.
- If their client is Jester and the Jester gets voted out, the Lawyer wins together with the Jester.

**NOTE:**
- If the client disconnects, the Lawyer will also turn into the Pursuer.
- The Lawyer needs to figure out the role of their client depending on the options.
- The tasks only count, if the Lawyer gets promoted to Pursuer.
- If the Lawyer dies before their client, they will lose all their tasks and will get the overview immediately.

### Game Options
| Name | Description |
|----------|:-------------:|
| Lawyer Spawn Chance | - 
| Lawyer Target Knows | - Lawyer Target Knows that they have a Lawyer, but they don't know who
| Lawyer Target Can Be The Jester | -
| Lawyer Vision | Pursuer has normal vision
| Lawyer Knows Target Role | -
-----------------------

## Pursuer
### **Team: Neutral**
The Pursuer is still a neutral role, but has a different goal to win the game; they have to be alive when the game ends and the Crew wins.\
In order to achieve this goal, the Pursuer has an ability called "Blank", where they can fill a killer's (this also includes the Sheriff) weapon with a blank. So, if the killer attempts to kill someone, the killer will miss their target, and their cooldowns will be triggered as usual.\
If the killer fires the "Blank", shields (e.g. Medic shield or Time Master shield) will not be triggered.\
The Pursuer has tasks (which can already be done while being a Lawyer/Prosecutor), that count towards the task win for the Crewmates. If the Pursuer dies, their tasks won't be counted anymore.

### Game Options
| Name | Description |
|----------|:-------------:|
| Pursuer Blank Cooldown | -
| Pursuer Number Of Blanks | -
-----------------------

## Thief
### **Team: Neutral**
The Thief has to kill another killer (Impostor, Jackal/Sidekick and if enabled Sheriff)
in order to have a win condition.\
If the Thief doesn't kill another killer they will lose the game.\
If the Thief kills one of the other killers, the Thief overtakes their role (e.g. Ninja) and joins their team (in this case
team Impostor). They then have the new Role's win condition (e.g. Impostor-Win).\
If the Thief tries to kill any non-killing role (Crewmate or Neutral), they die similar to a misfiring Sheriff.\
\
**NOTE**
- If the option "Thief Can Kill Sheriff" is On, the Thief has tasks which will ONLY begin to count, if they kill
the Sheriff. While the Thief hasn't fired, their tasks do not count towards the taskwin.
- If the option "Thief Can Kill Sheriff" is Off, the Thief will not have tasks. 

### Game Options
| Name | Description |
|----------|:-------------:|
| Thief Spawn Chance | -
| Thief Countdown | -
| Thief Can Kill Sheriff | -
| Thief Has Impostor Vision | -
| Thief Can Use Vents | -
-----------------------

## Executioner
### **Team: Neutral**
The Executioner is still a neutral role, but has a different goal to win the game; they have to vote out a specific player.\
In order to achieve this goal, they will always be able to see their targets name, even when names are hidden. They will also see the skin of their target on their intro screen.\
There are a few things to note about how the Executioners role can change.\
If the target is killed: Executioner -> [Pursuer](#pursuer)\
If the taget disconnects: Executioner -> [Pursuer](#pursuer)\
If the target is sidekicked: Executioner -> [Lawyer](#Lawyer) (Client: Target)\
\
The target of a Executioner cannot be the following: Impostor, [Jackal](#jackal), [Mayor](#mayor), [Sheriff](#sheriff), [Spy](#spy), [Swapper](#swapper), or a [Lover](#lovers)

## Amnesiac
### **Team: Neutral**
The Amesiac has no win condition and cannot win the game as Amnesiac.\
In order to gain a win condition, they must take a role from a dead body.\
There are a few things to note about how the Amnesiacs role can change.\
If the target is Bounty Hunter: Amnesiac -> Impostor (Red flash to signafy this)\
If the taget is Arsonist: Red Flash; Arsonist cannot be taken\
If the target body was on a team with Jackal or Impostor, that player will still be on that team.

### Game Options
| Name | Description |
|----------|:-------------:|
| Amnesiac Spawn Chance | -
| Show arrows to dead bodies | If set to true, the Amnesiac will get arrows to dead bodies when they die.
| Reset role when taken | If set to true, the role that is taken will be fully reset, allowing the abilities to be reused. Note: Weird stuff might happen with this setting off.

## Swooper
### **Team: Neutral**
The Swooper is a solo nuetral killer with the option to replace the Jackal.\

If it is not an Alternate Jackal, it is on it's own team, and must eliminate all opposing factions.
The Swooper uses the [Jackal](#jackal) kill cooldown.

### Game Options
| Name | Description |
|----------|:-------------:|
| Swooper Spawn Chance | -
| Spawn as Alternate Jackal | false
| Swoop Cooldown | -
| Swoop Duration | -
| Has Impostor Vision | true
-----------------------

## Werewolf
### **Team: Neutral**
The Werewolf is a Neutral role with its own win condition.\
Although the Werwolf has a kill button, they can't use it unless they are Rampaged.\
Once the Werewolf rampages they gain Impostor vision and the ability to kill.\
However, unlike most killers their kill cooldown is really short.\
The Werewolf needs to be the last killer alive to win the game.


### Game Options
| Name | Description |
|----------|:-------------:|
| Werewolf Spawn Chance | -
| Rampage Cooldown | -
| Rampage Duration | -
| Kiil Cooldown | - Kill Cooldown when rampaged