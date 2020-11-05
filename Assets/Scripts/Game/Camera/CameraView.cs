using UnityEngine;

namespace Game.Camera
{
	public class CameraView : MonoBehaviour, ICameraView
	{
		[SerializeField] private UnityEngine.Camera _camera;
		public UnityEngine.Camera GetCamera() => _camera;
	}
}