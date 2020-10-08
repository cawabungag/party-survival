using System;
using UnityEditor;
using UnityEngine;

namespace InstallerGenerator {
	public partial class EcsInstallerGeneratorWindow {
		private static readonly GUILayoutOption[] OrderStyle = {GUILayout.MaxWidth(50), GUILayout.MinWidth(50)};
		private static readonly GUILayoutOption[] ButtonsStyle = {GUILayout.MaxWidth(70), GUILayout.MinWidth(70)};
		private static readonly GUILayoutOption[] HeaderStyle = {GUILayout.MaxWidth(100), GUILayout.MinWidth(100)};
		private static readonly GUILayoutOption[] LabelStyle = {GUILayout.MinWidth(100)};
		private static readonly GUILayoutOption[] IgnoreStyle = {GUILayout.MaxWidth(50), GUILayout.MinWidth(50)};

		private static bool Button(string label, GUILayoutOption[] style)
			=> GUILayout.Button(label, EditorStyles.toolbarDropDown, style);

		private static Enum Enum(Enum value) => EditorGUILayout.EnumPopup(value, EditorStyles.miniButton, ButtonsStyle);
		private void SortOrderIncrease() => _sortOrder = _sortOrder == 0 ? 1 : _sortOrder == 1 ? -1 : 0;

		private static Rect GetDropArea() {
			var rect = GUILayoutUtility.GetRect(0.0f, 30.0f, GUILayout.ExpandWidth(true));
			GUILayout.Space(5f);
			return rect;
		}
	}
}
