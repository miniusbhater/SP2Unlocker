using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP2Unlocker
{
    [BepInPlugin(PluginInfoSteamPatch.GUID, PluginInfoSteamPatch.Name, PluginInfoSteamPatch.Version)]
    public class SteamPatch : BaseUnityPlugin

    {
        private void Awake()
        {
            var harmony = new Harmony("com.miniusbhater.steamdrmbypass");
            harmony.PatchAll();
            Logger.LogInfo("Skipping steam");
        }
    }

    [HarmonyPatch(typeof(SteamAPI), "RestartAppIfNecessary")]
    class Patch_RestartAppIfNecessary
    {
        static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(UnityEngine.Application), "Quit", new System.Type[0])]
    class Patch_ApplicationQuit
    {
        static bool Prefix()
        {
            return false; 
        }
    }

}
