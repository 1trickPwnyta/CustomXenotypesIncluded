﻿namespace CustomXenotypesIncluded
{
    public static class Debug
    {
        public static void Log(string message)
        {
#if DEBUG
            Verse.Log.Message($"[{CustomXenotypesIncludedMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
