using System.IO;
using FileGenerator;
using UnityEditor;
using UnityEngine;

namespace Ecs.ComponentAccessor
{
	public class ComponentAccessorWindowEditor : EditorWindow
	{
		private const string DAFUALT_PATH = "Generated/ComponentAccessor";
		private const string GENERATION_PATH_KEY = "ComponentAccessor.GenerationPath";
		private static string _generationPath;

		[MenuItem("Tools/ComponentAccessor/Settings")]
		public static void OpenWindow()
		{
			var window = GetWindowWithRect<ComponentAccessorWindowEditor>(new Rect(0, 0, 300, 50), false, "ComponentAccessor");
			window.Show();
		}

		[MenuItem("Tools/ComponentAccessor/Generate %&q")]
		public static void Generate()
		{
			_generationPath = EditorPrefs.GetString(GENERATION_PATH_KEY, DAFUALT_PATH);
			if (string.IsNullOrEmpty(_generationPath))
			{
				UnityEngine.Debug.LogError("[ProxifierWindowEditor] Generation path can't be empty!");
				return;
			}

			var directory = new DirectoryInfo(Path.Combine(Application.dataPath, _generationPath));
			var files = ComponentAccessGenerator.GenerateProxy(directory);
			GeneratorSerializer.Save(files);
			AssetDatabase.Refresh();
		}

		private void OnEnable()
		{
			_generationPath = EditorPrefs.GetString(GENERATION_PATH_KEY, DAFUALT_PATH);
		}

		private void OnGUI()
		{
			DrawGenerationPath();
			DrawGenerateButton();
		}

		private void DrawGenerationPath()
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label("GenerationPath");
			_generationPath = GUILayout.TextField(_generationPath);
			GUILayout.EndHorizontal();
		}

		private void DrawGenerateButton()
		{
			if (!GUILayout.Button("Generate"))
				return;
			Generate();
		}

		private void OnDisable()
		{
			EditorPrefs.SetString(GENERATION_PATH_KEY, _generationPath);
		}
	}
}