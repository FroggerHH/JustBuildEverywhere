using BepInEx;
using HarmonyLib;

namespace JustBuildEverywhere;

[BepInPlugin(ModGUID, ModName, ModVersion)]
internal class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        _self = this;

        harmony.PatchAll();

        //1730069260
    }

    #region values

    internal const string ModName = "JustBuildEverywhere", ModVersion = "1.1.0", ModGUID = "com.Frogger." + ModName;
    internal static Harmony harmony = new(ModGUID);

    internal static Plugin _self;

    #endregion

    #region tools

    public static void Debug(string msg, bool localize = false)
    {
        if (Localization.instance != null && localize)
            _self.Logger.LogInfo(Localization.instance.Localize(msg));
        else
            _self.Logger.LogInfo(msg);
    }

    public void DebugError(string msg, bool showWriteToDev)
    {
        if (showWriteToDev) msg += "Write to the developer and moderator if this happens often.";

        Logger.LogError(msg);
    }

    public void DebugWarning(string msg, bool showWriteToDev)
    {
        if (showWriteToDev) msg += "Write to the developer and moderator if this happens often.";

        Logger.LogWarning(msg);
    }

    #endregion
}