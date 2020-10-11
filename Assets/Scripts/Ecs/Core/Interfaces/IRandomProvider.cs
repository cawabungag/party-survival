using UnityEngine;

namespace Ecs.Core.Interfaces
{
    public interface IRandomProvider
    {
        float Value { get; }
        int Range(int min, int max);
        float Range(float min, float max);
        Vector2 GetVector2();
    }
}