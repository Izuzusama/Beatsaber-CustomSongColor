using CustomSongColor.Data;
using HarmonyLib;
using Newtonsoft.Json;
using System.IO;

namespace CustomSongColor.HarmonyPatches
{
    [HarmonyPatch(typeof(StandardLevelScenesTransitionSetupDataSO))]
    [HarmonyPatch("Init", MethodType.Normal)]
    internal class SceneTransitionPatch
    {
        private static void Prefix(ref IDifficultyBeatmap difficultyBeatmap, ref ColorScheme? overrideColorScheme)
        {
            FileInfo customColorJsonFile;
            // Only process custom level
            if (difficultyBeatmap.level is CustomPreviewBeatmapLevel customLevel)
            {
                var path = Path.Combine(customLevel.customLevelPath, "customColor.json");
                customColorJsonFile = new FileInfo(path);
            }
            else
            {
                // Not custom level
                return;
            }
            Plugin.Log.Debug($"Checking if {difficultyBeatmap.level.songName} has customColor.json");
            var environmentInfoSO = difficultyBeatmap.GetEnvironmentInfo();
            var fallbackScheme = overrideColorScheme ?? new ColorScheme(environmentInfoSO.colorScheme);
            if (customColorJsonFile == null || !customColorJsonFile.Exists)
            {
                Plugin.Log.Debug($"{customColorJsonFile.FullName} Not found. Skipping.");
                return;
            }
            var customColorData = JsonConvert.DeserializeObject<CustomColor>(File.ReadAllText(customColorJsonFile.FullName));
            Plugin.Log.Info($"Using color from: {customColorJsonFile.FullName}");

            var saberLeft = customColorData._colorLeft == null ? fallbackScheme.saberAColor : ColorFromMapColor(customColorData._colorLeft);
            var saberRight = customColorData._colorRight == null ? fallbackScheme.saberBColor : ColorFromMapColor(customColorData._colorRight);
            var envLeft = customColorData._envColorLeft == null
                ? customColorData._colorLeft == null ? fallbackScheme.environmentColor0 : ColorFromMapColor(customColorData._colorLeft)
                : ColorFromMapColor(customColorData._envColorLeft);
            var envRight = customColorData._envColorRight == null
                ? customColorData._colorRight == null ? fallbackScheme.environmentColor1 : ColorFromMapColor(customColorData._colorRight)
                : ColorFromMapColor(customColorData._envColorRight);
            var envLeftBoost = customColorData._envColorLeftBoost == null ? envLeft : ColorFromMapColor(customColorData._envColorLeftBoost);
            var envRightBoost = customColorData._envColorRightBoost == null ? envRight : ColorFromMapColor(customColorData._envColorRightBoost);
            var obstacle = customColorData._obstacleColor == null ? fallbackScheme.obstaclesColor : ColorFromMapColor(customColorData._obstacleColor);
            overrideColorScheme = new ColorScheme("CustomSongColorMapColorScheme", "CustomSongColor Map Color Scheme", true, "CustomSongColor Map Color Scheme", false, saberLeft, saberRight, envLeft,
                envRight, true, envLeftBoost, envRightBoost, obstacle);
        }
        private static UnityEngine.Color ColorFromMapColor(MapColor? mapColor)
        {
            return new UnityEngine.Color(mapColor.r, mapColor.g, mapColor.b);
        }
    }
}
