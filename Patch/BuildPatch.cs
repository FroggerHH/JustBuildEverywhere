using HarmonyLib;
using static Player.PlacementStatus;

namespace JustBuildEverywhere;

[HarmonyPatch]
internal class BuildPatch
{
    [HarmonyPatch(typeof(Player), nameof(Player.UpdatePlacementGhost))] [HarmonyPostfix]
    public static void Patch(Player __instance)
    {
        if (Player.m_localPlayer != __instance) return;
        if (__instance.m_placementStatus == Invalid) return; 
        if (!__instance.m_placementGhost) return;
        __instance.m_placementStatus = Valid;
        __instance.SetPlacementGhostValid(true);
    }
}