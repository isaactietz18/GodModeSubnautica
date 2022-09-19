using System.Reflection;
using HarmonyLib;
using QModManager.API.ModLoading;
using Logger = QModManager.Utility.Logger;
// sml
using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;
using SMLHelper.V2.Handlers;
using static OVRHaptics;
using SMLHelper.V2.Options;

namespace ConfigurableGodMode
{
    [QModCore]
    public static class QMod
    {
        // sml
        internal static Config Config { get; } = OptionsPanelHandler.Main.RegisterModOptions<Config>();

        [QModPatch]
        public static void Patch()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var modName = ($"ikibobble_{assembly.GetName().Name}");
            Logger.Log(Logger.Level.Info, $"Patching {modName}");
            Harmony harmony = new Harmony(modName);
            harmony.PatchAll(assembly);
            Logger.Log(Logger.Level.Info, "Patched successfully!");
        }
    }
    // sml
    [Menu("Configurable God Mode")]
    public class Config : ConfigFile
    {
        [Toggle("Player Invincibility"), OnChange(nameof(playerCheckboxToggleEvent))]
        public bool playerInvincibility;
        [Toggle("Vehicle Invincibility"), OnChange(nameof(playerCheckboxToggleEvent))]
        public bool vehicleInvincibility;

        private void playerCheckboxToggleEvent(ToggleChangedEventArgs e)
        {
            Logger.Log(Logger.Level.Info, "Checkbox value was changed!");
            Logger.Log(Logger.Level.Info, $"{e.Value}");
        }
    }
}