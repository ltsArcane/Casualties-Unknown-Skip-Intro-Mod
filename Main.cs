using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using UnityEngine;
using UnityEngine.UI;

[BepInPlugin("com.example.skiptro", "Skiptro Mod", "1.0.0")]
public class Main : BaseUnityPlugin
{
    public static ManualLogSource BaseLogger = null!;
    public static PrefixedLogger LoggerInstance = null!;
    private bool skipped = false;

    void Awake()
    {
        BaseLogger = Logger;
        LoggerInstance = new PrefixedLogger(BaseLogger, this);
    }

    public void Start()
    {
        LoggerInstance.LogMessage($"For more log info, set LogLevels to All.\n");
        LoggerInstance.LogMessage($"Skiptro is now active.");

        LoggerInstance.LogInfo($"Initialising Harmony loggers..."); // Important to do this before using Harmony, so that the loggers are ready to go.
        LoggerInstance.LogDebug($"> PreRunScriptTryLore...");
        PreRunScriptTryLorePrefix.InitializeLogger();
        LoggerInstance.LogInfo($"Harmony logs successfully initialised.\n");

        LoggerInstance.LogInfo($"Creating Harmony patches and patching necessary methods...");
        LoggerInstance.LogDebug($"> PreRunScriptTryLore...");
        Harmony.CreateAndPatchAll(typeof(PreRunScriptTryLorePrefix));
        LoggerInstance.LogInfo($"Harmony patches successful.\n");

        LoggerInstance.LogMessage($"Skiptro successfully initialised.\n");
    }

    void Update()
    {
        if (skipped) return;

        if (GameObject.Find("Warning")?.GetComponent<Button>() is Button button)
        {
            LoggerInstance.LogInfo("Found 'Warning' button, invoking click...");
            button.onClick.Invoke();
            skipped = true;
        }
        else LoggerInstance.LogWarning("Found 'Warning' object, but no Button component attached, or no warning object found.\n");
    }
}

[HarmonyPatch(typeof(PreRunScript), nameof(PreRunScript.TryLore))]
public class PreRunScriptTryLorePrefix
{
    private static PrefixedLogger LoggerInstance = null!;
    public static void InitializeLogger() => LoggerInstance = new PrefixedLogger(Main.BaseLogger, typeof(PreRunScriptTryLorePrefix));
    static bool Prefix()
    {
        LoggerInstance.LogInfo($"Skipping intro lore...\n");
        return false;
    }
}