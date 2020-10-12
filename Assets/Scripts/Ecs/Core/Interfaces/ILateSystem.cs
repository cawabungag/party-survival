using Entitas;

namespace Ecs.Core.Interfaces
{
    public interface ILateSystem : ISystem
    {
        void Late();
    }
}