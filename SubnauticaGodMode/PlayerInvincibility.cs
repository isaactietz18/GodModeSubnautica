using HarmonyLib;
using Logger = QModManager.Utility.Logger;

namespace ConfigurableGodMode
{
    class PlayerInvincibility
    {
        [HarmonyPatch(typeof(Player))]
        [HarmonyPatch("Awake")]
        internal class PatchPlayerAwake
        {
            [HarmonyPostfix]
            public static void Postfix(Player __instance)
            {
                // Check to see if this is the player
                if (__instance.GetType() == typeof(Player))
                {
                    //from checkbox
                    bool playerInvincibility = QMod.Config.playerInvincibility;

                    // Turn player invincible
                    __instance.liveMixin.invincible = playerInvincibility;

                    // log
                    Logger.Log(Logger.Level.Info, $"Player Invincibility: {playerInvincibility}", null, true);
                }
            }
        }
    }
}