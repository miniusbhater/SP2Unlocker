using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
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
    class PatchRestartAppIfNecessary
    {
        static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(UnityEngine.Application), "Quit", new System.Type[0])]
   class PatchApplicationQuit
   {
       static bool Prefix()
       {
           return false;
       }
   }


    [HarmonyPatch(typeof(SteamAPI), "init")]
    class PatchSteamInit
    {
        static bool prefix(ref bool __result)
        {
            Steamworks.SteamAPI.RestartAppIfNecessary(new AppId_t(480));
            __result = true;
            return false;
        }
    }
}

