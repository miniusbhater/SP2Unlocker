﻿using Assets.Scripts.UI;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Rewired;
using Steamworks;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace SP2Unlocker
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {

        void Awake()
        {
            GameObject gobject = new GameObject("SP2UnlockerGUI");
            gobject.hideFlags = HideFlags.HideAndDontSave;
            gobject.AddComponent<GUIBehaviour>();
        }

        void Start()
        {
            Logger.LogInfo("SP2Unlocker 1.0.0 by miniusbhater");


        }
        //User Interface/Main Menu UI/Empty (Clone)/Empty (Clone)/File (Clone)/Empty (Clone)/Empty (Clone)/Playtest Panel

        void Update()
        {
            GameObject playtestPanel = GameObject.Find("PlaytestPanel");
            GameObject.Destroy(playtestPanel);
            //GameObject demoSpace = GameObject.Find("DemoSpace");
            //GameObject.Destroy(demoSpace);

        }

        public class GUIBehaviour : MonoBehaviour
        {
            bool showWindow = true;
            void OnGUI()
            {
                GUIStyle sp2style = new GUIStyle();
                GUIStyle sp2style2 = new GUIStyle();
                sp2style2.fontSize = 18;
                sp2style2.normal.textColor = Color.white;
                sp2style.fontSize = 30;
                sp2style.normal.textColor = Color.white;
                if (!showWindow)
                    return;
                int boxWidth = 600;
                int boxHeight = 400;
                int x = (Screen.width / 2) - (boxWidth / 2);
                int y = (Screen.height / 2) - (boxHeight / 2);
                GUI.Box(new Rect(x, y, boxWidth, boxHeight), "SP2Unlocker");
                GUI.Label(new Rect(x + 20, y + 50, boxWidth - 40, boxHeight - 60), "Thanks for using SP2Unlocker <3", sp2style);
                GUI.Label(new Rect(x + 20, y + 100, boxWidth - 40, boxHeight - 60), "SP2Unlocker is intended so that you can bypass the time limit of the\nSimplePlanes 2 playtest. This mod is only so us players can enjoy\nSP2 until its official release.\nSP2Unlocker removes the time limit and steam requirement.\nThis mod does break the in-game close button.\n\nSP2Unlocker made by miniusbhater :p", sp2style2);
                if (GUI.Button(new Rect(x + boxWidth - 65, y + 5, 60, 20), "Close"))
                {
                    showWindow = false;
                }
            }
        }
    }
}

    

