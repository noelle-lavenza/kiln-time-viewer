using System;
using System.Text;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace KilnTimeViewer {
	[HarmonyPatch]
	public static class PitKilnTimePatch
	{
		[HarmonyPostfix]
		[HarmonyPatch(typeof(BlockEntityPitKiln), nameof(BlockEntityPitKiln.GetBlockInfo))]
		public static void GetBlockInfoPatch(BlockEntityPitKiln __instance, StringBuilder dsc, InventoryGeneric ___inventory)
		{
			if (!__instance.Lit || ___inventory.Empty)
			{
				return;
			}
			var timeRemaining = __instance.BurningUntilTotalHours - __instance.Api.World.Calendar.TotalHours;
			// todo: Lang.Get("Will finish in {0}", Lang.Get("{0} hours", Math.Round(timeRemaining));)
			// requires figuring out custom per-mod localization
			dsc.AppendLine($"Will finish in {Math.Round(timeRemaining)} hours");
		}
	}
}