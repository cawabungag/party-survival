using Entitas;

namespace Ecs.ComponentAccessor
{
	public interface IComponentAccess<TEntity, TComponent>
		where TEntity : class, IEntity
		where TComponent : IComponent
	{
		IMatcher<TEntity> Matcher { get; }
		
		bool HasComponent(TEntity entity);

		TComponent Create(TEntity entity);
		
		TComponent Get(TEntity entity);

		void Remove(TEntity entity);

		void Replace(TEntity entity, TComponent component);
	}
}