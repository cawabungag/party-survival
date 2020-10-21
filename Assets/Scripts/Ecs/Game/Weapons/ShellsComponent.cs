using Entitas;

[Game]
public class ShellsComponent : IComponent
{
   public float Value;

   public override string ToString()
   {
      return Value.ToString();
   }
}
