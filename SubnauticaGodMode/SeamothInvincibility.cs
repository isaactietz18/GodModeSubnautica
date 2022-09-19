using HarmonyLib;
using Logger = QModManager.Utility.Logger;

namespace ConfigurableGodMode
{
    class VehicleInvincibility
    {
        [HarmonyPatch(typeof(Vehicle))]
        [HarmonyPatch("EnterVehicle")]
        internal class PatchVehicleEnterVehicle
        {
            [HarmonyPostfix]
            public static void Postfix(Vehicle __instance)
            {
              // from checkbox
              bool vehicleInvincibility = QMod.Config.vehicleInvincibility;

              // Turn vehicle invincible
              __instance.liveMixin.invincible = vehicleInvincibility;

              // log
              Logger.Log(Logger.Level.Info, $"Vehicle Invincibility: {vehicleInvincibility}", null, true);
            }
        }
    }
}