using System;
using System.Collections.Generic;
using System.Reflection;
using InstallerGenerator.Attributes;
using InstallerGenerator.Enums;
using InstallerGenerator.Models;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace InstallerGenerator
{
	public partial class EcsInstallerGeneratorWindow : EditorWindow
	{
		private readonly List<AttributeRecord> _attributes = new List<AttributeRecord>();
		private readonly List<AttributeRecord> _current = new List<AttributeRecord>();

		private const string SaveKeyPath = "Ecs.InstallerGenerator.Path";
		private const string SaveKeySearchFolder = "Ecs.InstallerGenerator.SearchFolder";
		private const string SaveKeyDefault = "Ecs.InstallerGenerator.Default";

		private const string DefaultJson =
			"{\"Changed\":false,\"Type\":0,\"Priority\":2,\"Order\":100000,\"Name\":\"\"}";

		private string _savePath;
		private string _searchPath;
		private Vector2 _scroll;
		private int _filterPriority;
		private int _filterType;
		private int _sortOrder;
		private Sort _sorting;
		private int _counter;
		private string _search;
		private bool _options;
		private AttributeChanges _default;

		[MenuItem("Tools/Entitas/Installer Generator Properties")]
		public static void Open()
		{
			var window = GetWindow<EcsInstallerGeneratorWindow>("Installer Generator");
			window.Show();
		}

		private void OnEnable()
		{
			wantsMouseEnterLeaveWindow = true;
			_options = false;
			_savePath = EditorPrefs.GetString(SaveKeyPath, "Ecs/Installers/");
			_searchPath = EditorPrefs.GetString(SaveKeySearchFolder, "Ecs/");
			_default = JsonUtility.FromJson<AttributeChanges>(EditorPrefs.GetString(SaveKeyDefault, DefaultJson));

			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (var i = 0; i < assemblies.Length; i++)
			{
				var types = assemblies[i].GetTypes();
				for (var j = 0; j < types.Length; j++)
				{
					var type = types[j];
					if (!type.IsDefined(typeof(InstallAttribute), false))
						continue;
					var attribute = type.GetCustomAttribute(typeof(InstallAttribute), false) as InstallAttribute;
					_attributes.Add(new AttributeRecord(type, attribute));
				}
			}

			ProcessSort();
		}

		private void OnGUI()
		{
			Header();
			Options();
			Search();
			ListHeader();
			List();
			DropArea();
		}

		private void Header()
		{
			GUILayout.Space(5);
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Options", EditorStyles.toolbarButton, ButtonsStyle))
				_options = !_options;
			GUILayout.Label("", EditorStyles.toolbarButton, GUILayout.ExpandWidth(true));
			if (GUILayout.Button("Generate", EditorStyles.toolbarButton, ButtonsStyle))
				Generate();
			GUILayout.EndHorizontal();
			GUILayout.Space(5);
		}

		private void Options()
		{
			if (!_options)
				return;
			GUILayout.Label("Options", EditorStyles.boldLabel);

			EditorGUI.BeginChangeCheck();

			GUILayout.Label("Paths", EditorStyles.boldLabel);
			_savePath = EditorGUILayout.TextField("Installers", _savePath);
			_searchPath = EditorGUILayout.TextField("Search scripts", _searchPath);

			GUILayout.Label("Default values", EditorStyles.boldLabel);
			_default.Name = EditorGUILayout.TextField("Label", _default.Name);
			_default.Priority = (ExecutionPriority) EditorGUILayout.EnumPopup("Priority", _default.Priority);
			_default.Order = EditorGUILayout.IntField("Order", _default.Order);

			if (EditorGUI.EndChangeCheck())
			{
				EditorPrefs.SetString(SaveKeyPath, _savePath);
				EditorPrefs.SetString(SaveKeySearchFolder, _searchPath);
				EditorPrefs.SetString(SaveKeyDefault, JsonUtility.ToJson(_default, false));
			}

			GUILayout.Space(10);
		}

		private void Search()
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label("Search:", EditorStyles.toolbarButton, ButtonsStyle);
			EditorGUI.BeginChangeCheck();
			_search = GUILayout.TextField(_search, EditorStyles.toolbarTextField, GUILayout.ExpandWidth(true));
			if (EditorGUI.EndChangeCheck())
				ProcessSort();
			GUILayout.Label($"{_current.Count}/{_attributes.Count}", EditorStyles.toolbarButton, ButtonsStyle);
			GUILayout.EndHorizontal();
		}


		private void ListHeader()
		{
			GUILayout.BeginHorizontal();

			PriorityButton();

			if (Button($"Order {_sortOrder}", ButtonsStyle))
			{
				_sorting = Sort.Order;
				SortOrderIncrease();
				ProcessSort();
			}

			TypeButton();

			if (Button("Name", LabelStyle))
			{
				_sorting = Sort.Name;
				SortOrderIncrease();
				ProcessSort();
			}

			if (Button("Label", HeaderStyle))
			{
				_sorting = Sort.Label;
				SortOrderIncrease();
				ProcessSort();
			}

			if (Button("I", IgnoreStyle))
			{
			}

			GUILayout.EndHorizontal();
		}

		private void PriorityButton()
		{
			var label = "Priority";
			var delimiter = (int) ExecutionPriority.None + 2;
			if (_filterPriority % delimiter != 0)
				label = $"{(ExecutionPriority) (_filterPriority % delimiter - 1)}";
			if (!Button(label, ButtonsStyle))
				return;
			_filterPriority++;
			ProcessSort();
		}

		private void TypeButton()
		{
			var label = "Type";
			if (_filterType % 4 != 0)
				label = ((ExecutionType) (_filterType % ((int) ExecutionType.Game + 1) - 1)).ToString();
			if (!Button(label, OrderStyle))
				return;
			_filterType++;
			ProcessSort();
		}

		private void List()
		{
			_scroll = GUILayout.BeginScrollView(_scroll, false, true);
			foreach (var attribute in _current) Row(attribute);
			GUILayout.EndScrollView();
		}

		private void Row(AttributeRecord record)
		{
			GUILayout.BeginHorizontal();
			EditorGUI.BeginChangeCheck();

			record.Changes.Priority = (ExecutionPriority) Enum(record.Changes.Priority);
			record.Changes.Order =
				EditorGUILayout.IntField(record.Changes.Order, EditorStyles.miniTextField, OrderStyle);
			record.Changes.Type = (ExecutionType) Enum(record.Changes.Type);
			if (GUILayout.Button(record.Type.Name, EditorStyles.miniButton, GUILayout.ExpandWidth(true)))
			{
				GUI.changed = false;
				var selection = AssetDatabase.LoadAssetAtPath(FindFileForSelection(record.Type.Name), typeof(Object));
				Selection.activeObject = selection;
				EditorGUIUtility.PingObject(selection);
			}

			record.Changes.Name = GUILayout.TextArea(record.Changes.Name, EditorStyles.miniTextField, HeaderStyle);

			if (EditorGUI.EndChangeCheck())
			{
				record.Changes.Changed = true;
			}

			if (record.Changes.Changed)
			{
				if (GUILayout.Button("Save", EditorStyles.miniButton, IgnoreStyle))
				{
					ReplaceAttribute(
						FindFileForClass(record.Type.Name),
						record.Changes.Type,
						record.Changes.Name,
						record.Changes.Priority,
						record.Changes.Order
					);
					record.Changes.Changed = false;
				}
			}
			else if (GUILayout.Button("Remove", EditorStyles.miniButton, IgnoreStyle))
			{
				Remove(FindFileForClass(record.Type.Name));
				AssetDatabase.Refresh();
			}

			GUILayout.EndHorizontal();
		}

		private void ProcessSort()
		{
			// Sorting
			switch (_sorting)
			{
				case Sort.Name:
					_attributes.Sort((a, b) =>
					{
						if (_sortOrder != 0)
							return string.Compare(a.Type.Name, b.Type.Name, StringComparison.Ordinal) * _sortOrder;
						var priority = a.Attribute.Priority.CompareTo(b.Attribute.Priority);
						return priority == 0
							? string.Compare(b.Type.Name, a.Type.Name, StringComparison.Ordinal)
							: priority;
					});
					break;
				case Sort.Order:
					_attributes.Sort((a, b) =>
					{
						if (_sortOrder != 0) return a.Attribute.Order.CompareTo(b.Attribute.Order) * _sortOrder;
						var priority = a.Attribute.Priority.CompareTo(b.Attribute.Priority);
						return priority == 0 ? a.Attribute.Order.CompareTo(b.Attribute.Order) : priority;
					});
					break;
				case Sort.Label:
					_attributes.Sort((a, b) =>
					{
						if (_sortOrder != 0)
							return string.Compare(a.Attribute.Name, b.Attribute.Name, StringComparison.Ordinal) *
							       _sortOrder;
						var priority = a.Attribute.Priority.CompareTo(b.Attribute.Priority);
						return priority == 0
							? string.Compare(b.Attribute.Name, a.Attribute.Name, StringComparison.Ordinal)
							: priority;
					});
					break;
			}

			// Priority/Type and Searching
			// Filtering
			_current.Clear();
			foreach (var attribute in _attributes)
			{
				var a = attribute.Attribute;
				// Type
				var delimiter = (int) ExecutionType.Game + 2;
				if (_filterType % delimiter != 0)
					if (a.Type != (ExecutionType) (_filterType % delimiter - 1))
						continue;

				// Priority
				delimiter = (int) ExecutionPriority.None + 2;
				if (_filterPriority % delimiter != 0)
					if (a.Priority != (ExecutionPriority) (_filterPriority % delimiter - 1))
						continue;

				_current.Add(attribute);
			}

			if (!string.IsNullOrEmpty(_search))
			{
				var search = _search.ToLower();
				_current.RemoveAll(x => !x.Type.Name.ToLower().Contains(search));
			}
		}

		private static bool _inProgress;

		[MenuItem("Tools/Entitas/Generate Installers &g")]
		public static void Generate()
		{
			if (_inProgress)
				return;

			EditorUtility.DisplayProgressBar("Ecs Installer", "Generate...", .1f);

			try
			{
				_inProgress = true;
				var installerTemplates = EcsInstallerGenerator.Generate();
				var path = EditorPrefs.GetString(SaveKeyPath, "Ecs/Installers/");

				foreach (var template in installerTemplates)
				{
					SaveToFile(template.GeneratedInstallerCode, $"{template.Name}.cs", path);
				}
			}
			finally
			{
				_inProgress = false;
				EditorUtility.ClearProgressBar();
			}

			AssetDatabase.Refresh();
		}
	}
}