using System;
using System.Linq;
using HarmonyLib;
using TheOtherRoles.Utilities;
using static TheOtherRoles.TheOtherRoles;
using UnityEngine;

namespace TheOtherRoles.Patches {

    [HarmonyPatch(typeof(ShipStatus))]
    public class ShipStatusPatch 
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.CalculateLightRadius))]
        public static bool Prefix(ref float __result, ShipStatus __instance, [HarmonyArgument(0)] GameData.PlayerInfo player) {
            if (!__instance.Systems.ContainsKey(SystemTypes.Electrical)) return true;

            // If player is Lighter with ability active
            if (Lighter.lighter != null && Lighter.lighter.PlayerId == player.PlayerId && Lighter.lighterTimer > 0f) {
                float unlerped = Mathf.InverseLerp(__instance.MinLightRadius, __instance.MaxLightRadius, GetNeutralLightRadius(__instance, false));
                __result = Mathf.Lerp(__instance.MaxLightRadius * Lighter.lighterModeLightsOffVision, __instance.MaxLightRadius * Lighter.lighterModeLightsOnVision, unlerped);
            }

            // If there is a Trickster with their ability active
            else if (Trickster.trickster != null && Trickster.lightsOutTimer > 0f) {
                float lerpValue = 1f;
                if (Trickster.lightsOutDuration - Trickster.lightsOutTimer < 0.5f) {
                    lerpValue = Mathf.Clamp01((Trickster.lightsOutDuration - Trickster.lightsOutTimer) * 2);
                } else if (Trickster.lightsOutTimer < 0.5) {
                    lerpValue = Mathf.Clamp01(Trickster.lightsOutTimer * 2);
                }

                __result = Mathf.Lerp(__instance.MinLightRadius, __instance.MaxLightRadius, 1 - lerpValue) * PlayerControl.GameOptions.CrewLightMod;
            }

            // If player is Lawyer, apply Lawyer vision modifier
            else if (Lawyer.lawyer != null && Lawyer.lawyer.PlayerId == player.PlayerId) {
                float unlerped = Mathf.InverseLerp(__instance.MinLightRadius, __instance.MaxLightRadius, GetNeutralLightRadius(__instance, false));
                __result = Mathf.Lerp(__instance.MinLightRadius, __instance.MaxLightRadius * Lawyer.vision, unlerped);
                return false;
            }

            else if (Madmate.madmate != null && Madmate.madmate.PlayerId == player.PlayerId && Madmate.hasImpostorVision)
            {
                __result = __instance.MaxLightRadius * PlayerControl.GameOptions.ImpostorLightMod;
            }

            // Default light radius
            else {
                __result = GetNeutralLightRadius(__instance, false);
            }
            if (Sunglasses.sunglasses.FindAll(x => x.PlayerId == player.PlayerId).Count > 0) // Sunglasses
                __result *= 1f - Sunglasses.vision * 0.1f;

            var switchSystem = __instance.Systems[SystemTypes.Electrical].Cast<SwitchSystem>(); //TESTING
            var t = switchSystem.Value / 255f;
            if (Torch.torch.FindAll(x => x.PlayerId == player.PlayerId).Count > 0) t = 1;
            __result = Mathf.Lerp(__instance.MinLightRadius, __instance.MaxLightRadius, t) *
                       PlayerControl.GameOptions.CrewLightMod;

            return false;
        }

        public static float GetNeutralLightRadius(ShipStatus shipStatus, bool isImpostor) {
            if (isImpostor) return shipStatus.MaxLightRadius * PlayerControl.GameOptions.ImpostorLightMod;

            SwitchSystem switchSystem = MapUtilities.Systems[SystemTypes.Electrical].CastFast<SwitchSystem>();
            float lerpValue = switchSystem.Value / 255f;

            return Mathf.Lerp(shipStatus.MinLightRadius, shipStatus.MaxLightRadius, lerpValue) * PlayerControl.GameOptions.CrewLightMod;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.IsGameOverDueToDeath))]
        public static void Postfix2(ShipStatus __instance, ref bool __result)
        {
            __result = false;
        }

        private static int originalNumCommonTasksOption = 0;
        private static int originalNumShortTasksOption = 0;
        private static int originalNumLongTasksOption = 0;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Begin))]
        public static bool Prefix(ShipStatus __instance)
        {
            var commonTaskCount = __instance.CommonTasks.Count;
            var normalTaskCount = __instance.NormalTasks.Count;
            var longTaskCount = __instance.LongTasks.Count;
            originalNumCommonTasksOption = PlayerControl.GameOptions.NumCommonTasks;
            originalNumShortTasksOption = PlayerControl.GameOptions.NumShortTasks;
            originalNumLongTasksOption = PlayerControl.GameOptions.NumLongTasks;
            if(PlayerControl.GameOptions.NumCommonTasks > commonTaskCount) PlayerControl.GameOptions.NumCommonTasks = commonTaskCount;
            if(PlayerControl.GameOptions.NumShortTasks > normalTaskCount) PlayerControl.GameOptions.NumShortTasks = normalTaskCount;
            if(PlayerControl.GameOptions.NumLongTasks > longTaskCount) PlayerControl.GameOptions.NumLongTasks = longTaskCount;
            return true;
        }


        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.RepairSystem))]
        class RepairSystemPatch {
            public static bool Prefix(ShipStatus __instance, [HarmonyArgument(0)] SystemTypes systemType, [HarmonyArgument(1)] PlayerControl player, [HarmonyArgument(2)] byte amount) {

                // Mechanic expert repairs
                if (Engineer.engineer != null && Engineer.engineer == player && Engineer.expertRepairs) {
                    switch (systemType) {
                        case SystemTypes.Reactor:
                            if (amount == 64 || amount == 65) {
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 67);
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 66);
                            }
                            if (amount == 16 || amount == 17) {
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 19);
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.Reactor, 18);
                            }
                            break;
                        case SystemTypes.Laboratory:
                            if (amount == 64 || amount == 65) {
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.Laboratory, 67);
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.Laboratory, 66);
                            }
                            break;
                        case SystemTypes.LifeSupp:
                            if (amount == 64 || amount == 65) {
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.LifeSupp, 67);
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.LifeSupp, 66);
                            }
                            break;
                        case SystemTypes.Comms:
                            if (amount == 16 || amount == 17) {
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 19);
                                ShipStatus.Instance.RpcRepairSystem(SystemTypes.Comms, 18);
                            }
                            break;
                    }
                }
                
                return true;
            }
        }
            
        [HarmonyPatch(typeof(SwitchSystem), nameof(SwitchSystem.RepairDamage))]
        class SwitchSystemRepairPatch
        {
            public static void Postfix(SwitchSystem __instance, [HarmonyArgument(0)] PlayerControl player, [HarmonyArgument(1)] byte amount) {
                
                // Mechanic expert lights repairs
                if (Engineer.engineer != null && Engineer.engineer == player && Engineer.expertRepairs) {

                    if (amount >= 0 && amount <= 4) {
                        __instance.ActualSwitches = 0;
                        __instance.ExpectedSwitches = 0;
                    }

                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ShipStatus), nameof(ShipStatus.Begin))]
        public static void Postfix3(ShipStatus __instance)
        {
            // Restore original settings after the tasks have been selected
            PlayerControl.GameOptions.NumCommonTasks = originalNumCommonTasksOption;
            PlayerControl.GameOptions.NumShortTasks = originalNumShortTasksOption;
            PlayerControl.GameOptions.NumLongTasks = originalNumLongTasksOption;
        }
    }
}
