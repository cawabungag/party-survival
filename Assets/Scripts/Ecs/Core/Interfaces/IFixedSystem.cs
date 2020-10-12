﻿using Entitas;

namespace Ecs.Core.Interfaces
{
    public interface IFixedSystem : ISystem
    {
        void Fixed();
    }
}