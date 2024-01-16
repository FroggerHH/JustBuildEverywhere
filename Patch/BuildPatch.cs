using BepInEx.Bootstrap;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using static JustBuildEverywhere.Plugin;

namespace JustBuildEverywhere;

[HarmonyPatch]
internal class BuildPatch
{
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake)), HarmonyPostfix]
    public static void Patch(ZNetScene __instance)
    {
        foreach (var prefab in __instance.m_prefabs)
        {
            if(!prefab.TryGetComponent(out Piece piece)) continue;
            
            piece.m_groundOnly = false;
            piece.m_canBeRemoved = true;
            piece.m_allowedInDungeons = true;
            piece.m_noInWater = false;
            piece.m_notOnFloor = false;
            piece.m_notOnWood = false;
            piece.m_spaceRequirement = 0;
            piece.m_vegetationGroundOnly = false;
            piece.m_cultivatedGroundOnly = false;
            piece.m_notOnTiltingSurface = false;
            piece.m_inCeilingOnly = false;
            piece.m_onlyInTeleportArea = false;
        }
    }
}