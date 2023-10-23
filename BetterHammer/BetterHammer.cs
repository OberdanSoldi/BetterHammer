using BepInEx;
using HarmonyLib;
using Jotunn;
using Jotunn.Utils;

namespace BetterHammer {
	[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
	[BepInDependency(Main.ModGuid)]
	[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
	internal class BetterHammer : BaseUnityPlugin {
		public const string PluginGuid = "com.oberdan.BetterHammer";
		public const string PluginName = "BetterHammer";
		public const string PluginVersion = "0.0.1";

		private Harmony _h;
		
		private void Awake() {
			this._h = new Harmony("mod.betterhammer");
			this._h.PatchAll();
		}

		private void OnDestroy() {
			this._h.UnpatchSelf();
		}
	}
}

