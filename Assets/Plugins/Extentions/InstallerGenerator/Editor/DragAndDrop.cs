using UnityEditor;
using UnityEngine;

namespace InstallerGenerator
{
	public partial class EcsInstallerGeneratorWindow
	{
		private void DropArea()
		{
			var current = Event.current;

			GUILayout.Label("Drag and drop area:", EditorStyles.boldLabel);

			GUILayout.BeginHorizontal();
			GUILayout.Space(5f);

			var dropClient = GetDropArea();
			var dropCommon = GetDropArea();
			var dropServer = GetDropArea();

			GUILayout.EndHorizontal();
			GUILayout.Space(5f);

			if (current.type == EventType.Repaint)
			{
				GUI.Box(dropClient, "Client");
				GUI.Box(dropCommon, "Common");
				GUI.Box(dropServer, "Server");
			}

//			switch (current.type) {
//				case EventType.DragUpdated:
//				case EventType.DragPerform:
//					var drop = false;
//
//					if (dropClient.Contains(current.mousePosition)) {
//						drop  = true;
//						_type = ExecutionType.Client;
//					}
//					else if (dropCommon.Contains(current.mousePosition)) {
//						drop  = true;
//						_type = ExecutionType.Common;
//					}
//					else if (dropServer.Contains(current.mousePosition)) {
//						drop  = true;
//						_type = ExecutionType.Server;
//					}
//
//					if (!drop)
//						return;
//
//					DragAndDrop.visualMode = DragAndDropVisualMode.Link;
//
//					if (current.type == EventType.DragPerform) {
//						var scripts = new List<MonoScript>();
//						var paths   = new List<string>();
//						for (var i = 0; i < DragAndDrop.objectReferences.Length; i++) {
//							var draggedObject = DragAndDrop.objectReferences[i];
//							var script        = (MonoScript) draggedObject;
//							if (script == null)
//								continue;
//							scripts.Add(script);
//							paths.Add(DragAndDrop.paths[i]);
//						}
//						if (scripts.Count > 0) {
//							DragAndDrop.AcceptDrag();
//							var path = paths.ToArray();
//							for (var i = 0; i < path.Length; i++)
//								AddAttribute(path[i], _type, _default.Name, _default.Priority, _default.Order);
//							AssetDatabase.Refresh();
//						}
//					}
//					break;
//			}
		}
	}
}