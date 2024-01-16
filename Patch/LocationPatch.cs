using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using static JustBuildEverywhere.Plugin;

namespace JustBuildEverywhere;

[HarmonyPatch]
internal class LocationPatch
{
    [HarmonyPatch(typeof(Location), nameof(Location.IsInsideNoBuildLocation)), HarmonyPrefix]
    public static bool Patch(ref bool __result)
    {
        __result = false;
        return false;
    }
}