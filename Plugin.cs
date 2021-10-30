﻿using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace CustomSongColor
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        private static Harmony? _harmony;

        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("CustomSongColor initialized.");
        }

        #region BSIPA Config
        //Uncomment to use BSIPA's config
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        */
        #endregion

        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("OnApplicationStart");
            Log.Info("CustomSongColor enabled");
            //new GameObject("CustomSongColorController").AddComponent<CustomSongColorController>();

            _harmony = new Harmony("com.Izuzu.BeatSaber.CustomSongColor");
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");

        }
    }
}
