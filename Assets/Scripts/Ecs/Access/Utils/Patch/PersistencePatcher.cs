using System;
using System.Collections.Generic;
using Core.Utils.PlayerPrefs;
using Version = Core.Utils.AppVersion.Version;

namespace Ecs.Access.Utils.Patch
{
	public class PersistencePatcher
	{
		private const string AppVersionPatchKey = "AppVersionPatchKey";
		private readonly List<IPersistencePatch> _patches;

		private readonly IPlayerPrefsManager _playerPrefs;

		public PersistencePatcher(List<IPersistencePatch> patches, IPlayerPrefsManager playerPrefs)
		{
			_patches = patches;
			_playerPrefs = playerPrefs;
		}

		public void ApplyAllPatches()
		{
			_patches.Sort(new PatchComparer());
			var lastApplyPatchVersion = GetLastApplyPatchVersion();
			foreach (var patch in _patches)
			{
				if (!patch.Version.IsGreaterThan(lastApplyPatchVersion)) continue;
				patch.ApplyPatch();
				_playerPrefs.SetValue(AppVersionPatchKey, patch.Version.ToString());
			}

			_playerPrefs.Save();
		}

		private Version GetLastApplyPatchVersion()
		{
			var versionStr = _playerPrefs.GetValue(AppVersionPatchKey, "0.0.0");
			return Version.FromString(versionStr);
		}

		private class PatchComparer : IComparer<IPersistencePatch>
		{
			public int Compare(IPersistencePatch x, IPersistencePatch y)
			{
				if (x == null) throw new NullReferenceException("x is null");
				if (y == null) throw new NullReferenceException("y is null");
				return x.Version.CompareTo(y.Version);
			}
		}
	}
}