using DB.Units.MovementType.MovementSpeedType.Impls;

namespace DB.Units.MovementType.MovementSpeedType
{
    public interface IMovementSpeedType
    {
        MovementSpeedTypeVo GetMovementSpeed(EMovementType moveSpeed);
    }
}