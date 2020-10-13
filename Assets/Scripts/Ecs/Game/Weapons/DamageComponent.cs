using Entitas;

[Game]
public class DamageComponent : IComponent
{
  public float Value;
  
  public override string ToString()
  {
    return Value.ToString();
  }
}
