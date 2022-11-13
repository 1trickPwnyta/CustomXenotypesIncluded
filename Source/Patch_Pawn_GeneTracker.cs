using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using Verse;

namespace CustomXenotypesIncluded
{
    [HarmonyPatch(typeof(Pawn_GeneTracker))]
    [HarmonyPatch(nameof(Pawn_GeneTracker.SetXenotype))]
    public static class Patch_Pawn_GeneTracker_SetXenotype
    {
        public static void Postfix(Pawn_GeneTracker __instance, XenotypeDef xenotype)
        {
            if (xenotype == DefDatabase<XenotypeDef>.GetNamed("CustomXenotypesIncluded_Custom"))
            {
                MethodInfo customXenotypesMethod = AccessTools.Method(typeof(CharacterCardUtility), "get_CustomXenotypes");
                List<CustomXenotype> customXenotypes = customXenotypesMethod.Invoke(null, new object[] { }) as List<CustomXenotype>;

                CustomXenotype customXenotype = customXenotypes.RandomElement();

                if (customXenotype != null)
                {
                    __instance.xenotypeName = customXenotype.name;
                    __instance.iconDef = customXenotype.IconDef;
                    foreach (GeneDef gene in customXenotype.genes)
                    {
                        __instance.AddGene(gene, !customXenotype.inheritable);
                    }
                }
            }
        }
    }
}
