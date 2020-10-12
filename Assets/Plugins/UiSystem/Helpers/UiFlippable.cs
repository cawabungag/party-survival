using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditorInternal;
#endif

namespace SimpleUi.Helpers
{
	[RequireComponent(typeof(RectTransform), typeof(Graphic))]
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/Levels/Extensions/Flippable")]
	public class UiFlippable : BaseMeshEffect
	{
		[FormerlySerializedAs("Horizontal")] public bool Horizontal;
		[FormerlySerializedAs("Vertical")] public bool Vertical;

		private RectTransform _rectTransform;

		protected override void Awake()
		{
#if UNITY_EDITOR
			OnValidate();
#endif
			_rectTransform = transform as RectTransform;
		}

		public override void ModifyMesh(VertexHelper verts)
		{
			for (var i = 0; i < verts.currentVertCount; ++i)
			{
				var uiVertex = new UIVertex();
				verts.PopulateUIVertex(ref uiVertex, i);

				var rect = _rectTransform.rect;
				uiVertex.position = new Vector3(Horizontal
						? uiVertex.position.x + (rect.center.x - uiVertex.position.x) * 2
						: uiVertex.position.x,
					Vertical
						? uiVertex.position.y + (rect.center.y - uiVertex.position.y) * 2
						: uiVertex.position.y,
					uiVertex.position.z);

				verts.SetUIVertex(uiVertex, i);
			}
		}

#if UNITY_EDITOR
		protected override void OnValidate()
		{
			var components = gameObject.GetComponents(typeof(BaseMeshEffect));
			foreach (var comp in components)
				if (comp.GetType() != typeof(UiFlippable))
					ComponentUtility.MoveComponentUp(this);
				else break;
			GetComponent<Graphic>().SetVerticesDirty();
			base.OnValidate();
		}
#endif
	}
}