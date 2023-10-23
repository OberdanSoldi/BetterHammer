using HarmonyLib;
using UnityEngine;

namespace BetterHammer.Scripts {
	[HarmonyPatch]
	public static class AddHammerFunctionalities {
		[HarmonyPostfix]
		[HarmonyPatch(typeof(Player), nameof(Player.UpdatePlacementGhost))]
		public static void SelectRecipe(Player __instance) {
			var hoveringPiece = __instance.GetHoveringPiece();
			if (hoveringPiece == null) return;
			if (Input.GetKey(KeyCode.Q)) {
				__instance.SetSelectedPiece(hoveringPiece);
			}
		}

		[HarmonyPostfix]
		[HarmonyPatch(typeof(Player), nameof(Player.UpdatePlacementGhost))]
		public static void RemoveSelectedPiece(Player __instance) {
			if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Q)) {
				__instance.SetSelectedPiece(new Vector2Int(0, 0));
			}
		}
	}
}