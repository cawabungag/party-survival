using System;
using UnityEngine;

namespace Ecs.Game.Camera
{
    public class CameraView : MonoBehaviour, ICameraView
    {
        public UnityEngine.Camera GetCamera()
        {
            return UnityEngine.Camera.main;
        }
    }
}