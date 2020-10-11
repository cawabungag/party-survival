using Entitas;

namespace Ecs.Core.Interfaces
{
    public interface ILateFixedSystem : ISystem
    {
        void LateFixed();
    }
}