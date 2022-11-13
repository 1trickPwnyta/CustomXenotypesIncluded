using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Verse;

namespace CustomXenotypesIncluded
{
    [HarmonyPatch(typeof(WindowStack))]
    [HarmonyPatch(nameof(WindowStack.Add))]
    public static class Patch_WindowStack_Add
    {
        public static bool Prefix(Window window)
        {
            FloatMenu floatMenu = window as FloatMenu;
            if (floatMenu != null)
            {
                FieldInfo optionsField = AccessTools.Field(typeof(FloatMenu), "options");
                List<FloatMenuOption> options = optionsField.GetValue(floatMenu) as List<FloatMenuOption>;

                FloatMenuOption customOption = options.Where(option => option.Label == "CustomXenotypesIncluded_Custom").FirstOrFallback();
                if (customOption != null)
                {
                    options.Remove(customOption);
                }
            }

            return true;
        }
    }
}
