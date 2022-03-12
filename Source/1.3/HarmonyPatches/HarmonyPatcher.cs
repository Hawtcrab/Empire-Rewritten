﻿using Empire_Rewritten.Utils;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;

namespace Empire_Rewritten.HarmonyPatches
{
    public static class HarmonyPatcher
    {
        /// <summary>
        ///     Runs our harmony patches.
        /// </summary>
        public static void DoPatches()
        {
            Harmony harmony = new Harmony("EmpireRewritten.HarmonyPatches");
            harmony.Patch(typeof(Settlement).GetMethod(nameof(Settlement.GetGizmos)), null, new HarmonyMethod(typeof(SettlementGizmoPatch), nameof(SettlementGizmoPatch.GizmoPatch)));
            harmony.Patch(typeof(PlaySettings).GetMethod(nameof(PlaySettings.DoPlaySettingsGlobalControls)), null,
                          new HarmonyMethod(typeof(PlaySettingsControlsPatch), nameof(PlaySettingsControlsPatch.Postfix)));
            harmony.Patch(typeof(SettleUtility).GetMethod(nameof(SettleUtility.AddNewHome)), null, new HarmonyMethod(typeof(SettleUtilityPatch), nameof(SettleUtilityPatch.Postfix)));

            Logger.Log("Patches completed!");
        }
    }
}