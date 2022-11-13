using HarmonyLib;
using Verse;

namespace CustomXenotypesIncluded
{
    public class CustomXenotypesIncludedMod : Mod
    {
        public const string PACKAGE_ID = "customxenotypesincluded.1trickPwnyta";
        public const string PACKAGE_NAME = "Custom Xenotypes Included";

        public CustomXenotypesIncludedMod(ModContentPack content) : base(content)
        {
            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }
    }
}
