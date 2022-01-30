﻿using Verse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;

namespace Empire_Rewritten
{
    /// <summary>
    /// The class that should handle all out startup needs
    /// </summary>
    [StaticConstructorOnStartup]
    public static class Startup
    {
        /// <summary>
        /// Gets called on startup
        /// </summary>
        static Startup()
        {
            AppendActionsToWorldStart();
        }

        /// <summary>
        /// Appends functions to when the world is finalized
        /// </summary>
        private static void AppendActionsToWorldStart()
        {
            Log.Message($"<color=orange>[Empire]</color> Attaching actions to world start");
            UpdateController.AddFinalizeInitHook(AddFactionControllerIfMissing);
        }

        /// <summary>
        /// Adds a FactionController to the <c>UpdateController</c> class if one is missing
        /// </summary>
        /// <param name="controller"></param>
        private static void AddFactionControllerIfMissing(FactionController controller)
        {
            if (UpdateController.GetUpdateController.HasFactionController) return;
            UpdateController.GetUpdateController.FactionController = new FactionController(FactionSettlementData.CreateFactionSettlementDatas());
        }
    }
}
