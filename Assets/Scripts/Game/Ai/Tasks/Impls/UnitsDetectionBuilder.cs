using CleverCrow.Fluid.BTs.Trees;
using Services.Items;
using Zenject;

namespace Game.Ai.Tasks.Impls
{
 public class UnitDetectionBuilder : ABTreeBuilder
 {
  private static readonly ListPool<GameEntity> GameEntitiesListPool = ListPool<GameEntity>.Instance;
  private readonly GameContext _game;
  private readonly IItemService _itemService;

  public override string Name => TaskNames.DETECTION;

  public UnitDetectionBuilder(
   GameContext game,
   IItemService itemService
  )
  {
   _game = game;
   _itemService = itemService;
  }

  public override void Fill(BehaviorTreeBuilder builder, GameEntity entity)
   => builder.Condition(Name, () =>
   {
    if (!entity.hasEcsGameUnitsRangeView || !entity.hasEcsGamePosition)
     return false;
    var group = _game.GetGroup(
     GameMatcher.AllOf(GameMatcher.EcsGameFlagsUnit).NoneOf(GameMatcher.EcsGameFlagsDestroyed)); //проверить
    var buffer = GameEntitiesListPool.Spawn();
    group.GetEntities(buffer);
    if (buffer.Count == 0)
     return false;

    var position = entity.ecsGamePosition.value;
    var rangeView = entity.ecsGameUnitsRangeView.Value;
    var entityType = entity.ecsGameObjectType.Value;
    var rangeViewSqr = rangeView * rangeView;

    GameEntity closestFood = null;
    float closestFoodSqrDistance = int.MaxValue;

    foreach (var food in buffer)
    {
     if (!food.hasEcsGamePosition)
      continue;

     var foodPosition = food.ecsGamePosition.value;
     var foodDistance = foodPosition - position;
     var foodDistanceSqr = foodDistance.sqrMagnitude;
     if (foodDistanceSqr > rangeViewSqr || closestFoodSqrDistance < foodDistanceSqr)
      continue;

     closestFoodSqrDistance = foodDistanceSqr;
     closestFood = food;
    }

    if (closestFood == null)
     return false;
    
    
    return true;

   });
 }
}